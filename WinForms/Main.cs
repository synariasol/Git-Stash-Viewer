using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GSV
{
    public partial class Main : Form
    {
        private IEnumerable<StashInfo> Stashes = new List<StashInfo>(); 

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            HideLoader();

            Git.CommandLog.Add("Settings:");

            GitExecutableDialog.FileName = Git.ExecutablePath;
            GitRepositoryDialog.SelectedPath = Git.RepositoryPath;

            UpdateControl(GitExecutableInput, c => c.Text = Git.ExecutablePath);
            UpdateControl(GitRepositoryInput, c => c.Text = Git.RepositoryPath);

            Git.CommandLog.Add(
                    string.Format("     Executable: {0}", Git.ExecutablePath)
                );
            
            Git.CommandLog.Add(
                    string.Format("     Repository: {0}", Git.RepositoryPath)
                );

            if (!string.IsNullOrWhiteSpace(Git.ExecutablePath))
            {
                LoadStashes();
            }

            Git.ErrorHandler = HandleError;
        }

        private void GitExecutablePathBrowse_Click(object sender, EventArgs e)
        {
            if (GitExecutableDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Git.ExecutablePath = GitExecutableDialog.FileName;
            UpdateControl(GitExecutableInput, c => c.Text = Git.ExecutablePath);

            if (!string.IsNullOrWhiteSpace(Git.RepositoryPath))
            {
                LoadStashes();
            }
        }

        private void BranchRepositoryBrowse_Click(object sender, EventArgs e)
        {
            if (GitRepositoryDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Git.RepositoryPath = GitRepositoryDialog.SelectedPath;
            UpdateControl(GitRepositoryInput, c => c.Text = Git.RepositoryPath);

            LoadStashes();
        }

        private void GitRefresh_Click(object sender, EventArgs e)
        {
            LoadStashes();
        }

        private void GitViewCommandLog_Click(object sender, EventArgs e)
        {
            var form = new CommandLog();

            form.ShowDialog();
        }

        private void StashNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stash = (from s in Stashes
                         where s.Name == StashNameCombo.Text
                         select s).FirstOrDefault();

            UpdateControl(StashDescriptionLabel, c => c.Text = string.Empty);
            UpdateControl(StashFileList, c => c.Items.Clear());
            UpdateControl(DiffViewer, c => c.Clear());

            if (stash == null)
            {
                return;
            }

            UpdateControl(StashDescriptionLabel, c => c.Text = stash.Description);
            LoadFiles(stash);
        }

        private void StashFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StashFileList.SelectedItems.Count <= 0)
            {
                return;
            }

            var stash = (from s in Stashes
                         where s.Name == StashNameCombo.Text
                         select s).FirstOrDefault();

            UpdateControl(DiffViewer, c => c.Clear());

            if (stash == null)
            {
                return;
            }

            var selected = StashFileList.SelectedItems.Cast<ListViewItem>();
            var file = (from f in stash.Files
                        let s = selected.First()
                        where f.Name == Convert.ToString(s.Name)
                        select f).FirstOrDefault();

            if (file != null)
            {
                LoadFileDiff(stash, file);
            }
        }

        private void LoadStashes()
        {
            ShowLoader();
            
            UpdateControl(StashNameCombo, c => c.Items.Clear());
            UpdateControl(StashDescriptionLabel, c => c.Text = string.Empty);
            UpdateControl(StashFileList, c => c.Items.Clear());
            UpdateControl(DiffViewer, c => c.Clear());

            var stashes = Git.GetStashes();

            if (stashes != null)
            {
                Stashes = stashes.ToList();

                if (Stashes.Any())
                {
                    StashNameCombo.Items.Add(string.Empty);

                    foreach (var stash in Stashes)
                    {
                        StashNameCombo.Items.Add(stash.Name);
                    }
                }
            }

            HideLoader();
        }

        private void LoadFiles(StashInfo stash)
        {
            ShowLoader();

            UpdateControl(StashFileList, c => c.Items.Clear());
            UpdateControl(DiffViewer, c => c.Clear());

            if (!string.IsNullOrWhiteSpace(StashNameCombo.Text))
            {
                var files = new List<StashFileInfo>().AsEnumerable();

                if (stash.Files == null)
                {
                    files = Git.GetStashFiles(stash);
                }

                if (files != null)
                {
                    stash.Files = files;

                    foreach (var file in stash.Files.OrderBy(f => f.Name))
                    {
                        var imageKey = "Add";

                        switch (file.ChangeStatus)
                        {
                            case StashFileInfo.ChangeStatusTypes.Modified:
                                imageKey = "Modify";
                                break;
                            case StashFileInfo.ChangeStatusTypes.Deleted:
                                imageKey = "Delete";
                                break;
                        }

                        StashFileList.Items.Add(file.Name, file.Name, imageKey);
                    }

                    StashFileList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }

            HideLoader();
        }

        private void LoadFileDiff(StashInfo stash, StashFileInfo file)
        {
            ShowLoader();

            UpdateControl(DiffViewer, c => c.Clear());

            if (file.Diff == null)
            {
                file.Diff = Git.GetFileDiff(stash, file);
            }

            if (file.Diff != null)
            {
                var lines = file.Diff.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    if (line.StartsWith("+"))
                    {
                        DiffViewer.SelectionBackColor = Color.LightGreen;
                    }
                    else if (line.StartsWith("-"))
                    {
                        DiffViewer.SelectionBackColor = Color.LightCoral;
                    }
                    else if (line.StartsWith("@@"))
                    {
                        DiffViewer.SelectionBackColor = Color.Gainsboro;
                    }

                    DiffViewer.AppendText(line + "\r\n");
                }
            }

            HideLoader();
        }

        private void ShowLoader()
        {
            MainPanel.Enabled = false;
            MainStatusLoading.Text = "Loading...";
            MainStatus.Refresh();
        }

        private void HideLoader()
        {
            MainPanel.Enabled = true;
            MainStatusLoading.Text = string.Empty;
            MainStatus.Refresh();

            UpdateControl(StashNameCombo);
            UpdateControl(StashDescriptionLabel);
            UpdateControl(StashFileList);
            UpdateControl(DiffViewer);
        }

        private static void UpdateControl<TControl>(TControl control, Action<TControl> updateThunk = null)
            where TControl : Control
        {
            if (updateThunk != null)
            {
                updateThunk(control);
            }

            control.Refresh();
        }

        private static bool HandleError(string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}
