using System.IO;
using System.Linq;

namespace GSV
{
    internal static class ConfigurationSettings
    {
        private const string SettingsFileName = "gsv-settings.txt";
        private const string DefaultGitExecutablePath = @"C:\Program Files\Git\bin\git.exe";

        private static string _gitExecutablePath;
        private static string _gitRepositoryPath;

        public static string GitExecutablePath
        {
            get
            {
                if (_gitExecutablePath == null)
                {
                    Load();
                }

                return _gitExecutablePath;
            }
            set
            {
                _gitExecutablePath = value ?? string.Empty;
                Save();
            }
        }

        public static string GitRepositoryPath
        {
            get
            {
                if (_gitRepositoryPath == null)
                {
                    Load();
                }

                return _gitRepositoryPath;
            }
            set
            {
                _gitRepositoryPath = value ?? string.Empty;
                Save();
            }
        }

        private static void Load()
        {
            _gitExecutablePath = string.Empty;
            _gitRepositoryPath = string.Empty;

            if (File.Exists(SettingsFileName))
            {
                var settings = File.ReadLines(SettingsFileName).ToList();

                if (settings.Count >= 1)
                {
                    _gitExecutablePath = settings[0] ?? string.Empty;
                }

                if (settings.Count >= 2)
                {
                    _gitRepositoryPath = settings[1] ?? string.Empty;
                }
            }

            if (!File.Exists(_gitExecutablePath))
            {
                _gitExecutablePath = File.Exists(DefaultGitExecutablePath) 
                    ? DefaultGitExecutablePath 
                    : string.Empty;
            }

            if (!Directory.Exists(_gitRepositoryPath))
            {
                _gitRepositoryPath = string.Empty;
            }

            Save();
        }

        private static void Save()
        {
            File.WriteAllLines(SettingsFileName, new[]
                                                     {
                                                         _gitExecutablePath ?? string.Empty, 
                                                         _gitRepositoryPath ?? string.Empty
                                                     });
        }
    }
}