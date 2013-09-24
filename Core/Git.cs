using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GSV
{
    public static class Git
    {
        private const string StashListCommand = "stash list";
        private const string StashFilesCommand = @"diff -M -C -z --name-status ""{0}^"" ""{0}""";
        private const string UntrackedHashCommand = @"log ""{0}^3"" --pretty=format:""%T"" --max-count=1";
        private const string UntrackedFilesCommand = @"ls-tree -r ""{0}""";
        private const string FileDiffCommand = @"diff --unified=3 -M -C ""{0}^"" ""{0}"" -- ""{1}""";
        private const string UntrackedFileBlobCommand = @"cat-file blob ""{0}""";

        static Git()
        {
            CommandLog = new List<string>();
        }
        
        public static Func<string, bool> ErrorHandler { get; set; }

        public static IList<string> CommandLog { get; private set; }

        public static string ExecutablePath
        {
            get { return ConfigurationSettings.GitExecutablePath; }
            set
            {
                LogAction("Settings:");
                CommandLog.Add(
                        string.Format("     Git Executable: {0}", value)
                    );

                ConfigurationSettings.GitExecutablePath = value;
            }
        }

        public static string RepositoryPath
        {
            get { return ConfigurationSettings.GitRepositoryPath; }
            set
            {
                LogAction("Settings:");
                CommandLog.Add(
                        string.Format("     Git Repository: {0}", value)
                    );

                ConfigurationSettings.GitRepositoryPath = value;
            }
        }

        public static IEnumerable<StashInfo> GetStashes()
        {
            var error = string.Empty;
            var stashes = new List<string>();

            LogAction("Stashes:");

            ExecuteGitCommand(StashListCommand,
                              d =>
                              {
                                  if (d != null)
                                  {
                                      stashes.Add(d);
                                  }
                              },
                              e =>
                              {
                                  if (e != null)
                                  {
                                      error = e;
                                  }
                              });

            if (HandleError(error))
            {
                return null;
            }

            return (from s in stashes
                    let p = s.IndexOf(':')
                    let n = s.Substring(0, p)
                    let d = s.Substring(p + 1)
                    select new StashInfo
                               {
                                   Name = n.Trim(),
                                   Description = d.Trim()
                               }).ToList();
        }

        public static IEnumerable<StashFileInfo> GetStashFiles(StashInfo stash)
        {
            LogAction(
                    string.Format("Stash: {0}", stash.Name)
                );

            var stashedFiles = GetStashFilesInternal(stash);

            if (stashedFiles != null)
            {
                var untrackedFiles = GetUntrackedFiles(stash);

                if (untrackedFiles != null)
                {
                    return stashedFiles.Union(untrackedFiles);
                }
            }

            return null;
        }

        private static IEnumerable<StashFileInfo> GetStashFilesInternal(StashInfo stash)
        {
            var error = string.Empty;
            var files = string.Empty;

            ExecuteGitCommand(string.Format(StashFilesCommand, stash.Name),
                              d =>
                              {
                                  if (d != null)
                                  {
                                      files = d;
                                  }
                              },
                              e =>
                              {
                                  if (e != null)
                                  {
                                      error = e;
                                  }
                              });

            if (HandleError(error))
            {
                return null;
            }

            var fileList = files.Split('\0');
            var stashFiles = new List<StashFileInfo>();

            for (var index = 0; index < fileList.Length; index += 2)
            {
                if (string.IsNullOrWhiteSpace(fileList[index]))
                {
                    break;
                }

                var changeState = fileList[index];
                var name = fileList[index + 1].Trim('"');
                var fileInfo = new StashFileInfo { Name = name };

                switch (changeState)
                {
                    case "A":
                        fileInfo.ChangeStatus = StashFileInfo.ChangeStatusTypes.Added;
                        break;
                    case "M":
                        fileInfo.ChangeStatus = StashFileInfo.ChangeStatusTypes.Modified;
                        break;
                    case "D":
                        fileInfo.ChangeStatus = StashFileInfo.ChangeStatusTypes.Deleted;
                        break;
                }

                stashFiles.Add(fileInfo);
            }

            return stashFiles;
        }

        private static IEnumerable<StashFileInfo> GetUntrackedFiles(StashInfo stash)
        {
            var untrackedHash = GetUntrackedHash(stash);

            if (string.IsNullOrWhiteSpace(untrackedHash))
            {
                return new List<StashFileInfo>();
            }

            var error = string.Empty;
            var files = new List<string>();

            ExecuteGitCommand(string.Format(UntrackedFilesCommand, untrackedHash),
                              d =>
                              {
                                  if (d != null)
                                  {
                                      files.Add(d);
                                  }
                              },
                              e =>
                              {
                                  if (e != null)
                                  {
                                      error = e;
                                  }
                              });

            if (HandleError(error))
            {
                return null;
            }

            return (from f in files
                    let s = f.IndexOf(' ', 7)
                    let h = f.Substring(s + 1, 40)
                    let n = f.Substring(s + 42)
                    select new StashFileInfo
                               {
                                   Name = n.Trim(' ', '"'),
                                   Hash = h,
                                   ChangeStatus = StashFileInfo.ChangeStatusTypes.Untracked
                               });
        }

        private static string GetUntrackedHash(StashInfo stashInfo)
        {
            var hash = string.Empty;
            var error = string.Empty;

            ExecuteGitCommand(string.Format(UntrackedHashCommand, stashInfo.Name),
                                  d =>
                                  {
                                      if (d != null)
                                      {
                                          hash = d;
                                      }
                                  },
                                  e =>
                                  {
                                      if (e != null)
                                      {
                                          error = e;
                                      }
                                  });

            return HandleError(error) ? null : hash;
        }

        public static string GetFileDiff(StashInfo stash, StashFileInfo file)
        {
            var error = string.Empty;
            var diff = new StringBuilder();
            var command = file.ChangeStatus == StashFileInfo.ChangeStatusTypes.Untracked
                ? string.Format(UntrackedFileBlobCommand, file.Hash)
                : string.Format(FileDiffCommand, stash.Name, file.Name);

            LogAction(
                    string.Format("File Diff: {0}", file.Name)
                );
            
            ExecuteGitCommand(command,
                              d =>
                              {
                                  if (d != null)
                                  {
                                      diff.AppendLine(d);
                                  }
                              },
                              e =>
                              {
                                  if (e != null)
                                  {
                                      error = e;
                                  }
                              });

            return HandleError(error) ? null : diff.ToString();
        }

        private static void ExecuteGitCommand(string arguments, Action<string> dataThunk, Action<string> errorThunk)
        {
            if (!File.Exists(ExecutablePath))
            {
                HandleError("Invalid Git executable path.");
            }

            var gitInfo = new ProcessStartInfo
                              {
                                  CreateNoWindow = true,
                                  RedirectStandardError = true,
                                  RedirectStandardOutput = true,
                                  FileName = ExecutablePath,
                                  Arguments = arguments,
                                  WorkingDirectory = RepositoryPath,
                                  UseShellExecute = false
                              };

            var gitProcess = new Process { StartInfo = gitInfo };

            CommandLog.Add(
                    string.Concat("     ", arguments)
                );

            gitProcess.OutputDataReceived += (sender, args) => dataThunk(args.Data);
            gitProcess.ErrorDataReceived += (sender, args) => errorThunk(args.Data);

            gitProcess.Start();
            gitProcess.BeginOutputReadLine();
            gitProcess.BeginErrorReadLine();
            gitProcess.WaitForExit();
            gitProcess.Close();
        }

        private static void LogAction(string message)
        {
            CommandLog.Add(
                    string.Concat("\r\n", message)
                );
        }

        private static bool HandleError(string error)
        {
            return ErrorHandler != null && ErrorHandler(error);
        }
    }
}