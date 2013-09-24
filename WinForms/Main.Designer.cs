namespace GSV
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.DiffGroup = new System.Windows.Forms.GroupBox();
            this.DiffViewer = new System.Windows.Forms.RichTextBox();
            this.StashGroup = new System.Windows.Forms.GroupBox();
            this.StashDescriptionLabel = new System.Windows.Forms.TextBox();
            this.StashFileList = new System.Windows.Forms.ListView();
            this.FileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChangeStatusImages = new System.Windows.Forms.ImageList(this.components);
            this.StashNameCombo = new System.Windows.Forms.ComboBox();
            this.GitGroup = new System.Windows.Forms.GroupBox();
            this.GitViewCommandLog = new System.Windows.Forms.Button();
            this.GitRefresh = new System.Windows.Forms.Button();
            this.GitRepositoryBrowse = new System.Windows.Forms.Button();
            this.GitExecutableLabel = new System.Windows.Forms.Label();
            this.GitExecutableBrowse = new System.Windows.Forms.Button();
            this.GitRepositoryInput = new System.Windows.Forms.TextBox();
            this.GitExecutableInput = new System.Windows.Forms.TextBox();
            this.GitRepositoryLabel = new System.Windows.Forms.Label();
            this.GitExecutableDialog = new System.Windows.Forms.OpenFileDialog();
            this.GitRepositoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.MainStatusLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainPanel.SuspendLayout();
            this.DiffGroup.SuspendLayout();
            this.StashGroup.SuspendLayout();
            this.GitGroup.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.DiffGroup);
            this.MainPanel.Controls.Add(this.StashGroup);
            this.MainPanel.Controls.Add(this.GitGroup);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1010, 563);
            this.MainPanel.TabIndex = 0;
            // 
            // DiffGroup
            // 
            this.DiffGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiffGroup.Controls.Add(this.DiffViewer);
            this.DiffGroup.Location = new System.Drawing.Point(331, 12);
            this.DiffGroup.Name = "DiffGroup";
            this.DiffGroup.Size = new System.Drawing.Size(665, 527);
            this.DiffGroup.TabIndex = 2;
            this.DiffGroup.TabStop = false;
            this.DiffGroup.Text = "Diff";
            // 
            // DiffViewer
            // 
            this.DiffViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiffViewer.BackColor = System.Drawing.Color.White;
            this.DiffViewer.DetectUrls = false;
            this.DiffViewer.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.DiffViewer.Location = new System.Drawing.Point(16, 19);
            this.DiffViewer.Name = "DiffViewer";
            this.DiffViewer.ReadOnly = true;
            this.DiffViewer.Size = new System.Drawing.Size(633, 492);
            this.DiffViewer.TabIndex = 2;
            this.DiffViewer.Text = "";
            this.DiffViewer.WordWrap = false;
            // 
            // StashGroup
            // 
            this.StashGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StashGroup.Controls.Add(this.StashDescriptionLabel);
            this.StashGroup.Controls.Add(this.StashFileList);
            this.StashGroup.Controls.Add(this.StashNameCombo);
            this.StashGroup.Location = new System.Drawing.Point(12, 181);
            this.StashGroup.Name = "StashGroup";
            this.StashGroup.Size = new System.Drawing.Size(313, 358);
            this.StashGroup.TabIndex = 12;
            this.StashGroup.TabStop = false;
            this.StashGroup.Text = "Stash";
            // 
            // StashDescriptionLabel
            // 
            this.StashDescriptionLabel.BackColor = System.Drawing.Color.White;
            this.StashDescriptionLabel.Location = new System.Drawing.Point(12, 56);
            this.StashDescriptionLabel.Multiline = true;
            this.StashDescriptionLabel.Name = "StashDescriptionLabel";
            this.StashDescriptionLabel.ReadOnly = true;
            this.StashDescriptionLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StashDescriptionLabel.Size = new System.Drawing.Size(289, 46);
            this.StashDescriptionLabel.TabIndex = 11;
            // 
            // StashFileList
            // 
            this.StashFileList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.StashFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StashFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileNameHeader});
            this.StashFileList.FullRowSelect = true;
            this.StashFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.StashFileList.HideSelection = false;
            this.StashFileList.Location = new System.Drawing.Point(11, 115);
            this.StashFileList.MultiSelect = false;
            this.StashFileList.Name = "StashFileList";
            this.StashFileList.ShowGroups = false;
            this.StashFileList.Size = new System.Drawing.Size(291, 226);
            this.StashFileList.SmallImageList = this.ChangeStatusImages;
            this.StashFileList.TabIndex = 10;
            this.StashFileList.UseCompatibleStateImageBehavior = false;
            this.StashFileList.View = System.Windows.Forms.View.Details;
            this.StashFileList.SelectedIndexChanged += new System.EventHandler(this.StashFileList_SelectedIndexChanged);
            // 
            // ChangeStatusImages
            // 
            this.ChangeStatusImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ChangeStatusImages.ImageStream")));
            this.ChangeStatusImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ChangeStatusImages.Images.SetKeyName(0, "Add");
            this.ChangeStatusImages.Images.SetKeyName(1, "Delete");
            this.ChangeStatusImages.Images.SetKeyName(2, "Modify");
            // 
            // StashNameCombo
            // 
            this.StashNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StashNameCombo.FormattingEnabled = true;
            this.StashNameCombo.Location = new System.Drawing.Point(9, 26);
            this.StashNameCombo.Name = "StashNameCombo";
            this.StashNameCombo.Size = new System.Drawing.Size(293, 21);
            this.StashNameCombo.TabIndex = 2;
            this.StashNameCombo.SelectedIndexChanged += new System.EventHandler(this.StashNameCombo_SelectedIndexChanged);
            // 
            // GitGroup
            // 
            this.GitGroup.Controls.Add(this.GitViewCommandLog);
            this.GitGroup.Controls.Add(this.GitRefresh);
            this.GitGroup.Controls.Add(this.GitRepositoryBrowse);
            this.GitGroup.Controls.Add(this.GitExecutableLabel);
            this.GitGroup.Controls.Add(this.GitExecutableBrowse);
            this.GitGroup.Controls.Add(this.GitRepositoryInput);
            this.GitGroup.Controls.Add(this.GitExecutableInput);
            this.GitGroup.Controls.Add(this.GitRepositoryLabel);
            this.GitGroup.Location = new System.Drawing.Point(12, 12);
            this.GitGroup.Name = "GitGroup";
            this.GitGroup.Size = new System.Drawing.Size(313, 163);
            this.GitGroup.TabIndex = 10;
            this.GitGroup.TabStop = false;
            this.GitGroup.Text = "Git";
            // 
            // GitViewCommandLog
            // 
            this.GitViewCommandLog.Location = new System.Drawing.Point(11, 126);
            this.GitViewCommandLog.Name = "GitViewCommandLog";
            this.GitViewCommandLog.Size = new System.Drawing.Size(291, 23);
            this.GitViewCommandLog.TabIndex = 12;
            this.GitViewCommandLog.Text = "View Command Log";
            this.GitViewCommandLog.UseVisualStyleBackColor = true;
            this.GitViewCommandLog.Click += new System.EventHandler(this.GitViewCommandLog_Click);
            // 
            // GitRefresh
            // 
            this.GitRefresh.Location = new System.Drawing.Point(11, 97);
            this.GitRefresh.Name = "GitRefresh";
            this.GitRefresh.Size = new System.Drawing.Size(291, 23);
            this.GitRefresh.TabIndex = 11;
            this.GitRefresh.Text = "Refresh";
            this.GitRefresh.UseVisualStyleBackColor = true;
            this.GitRefresh.Click += new System.EventHandler(this.GitRefresh_Click);
            // 
            // GitRepositoryBrowse
            // 
            this.GitRepositoryBrowse.Location = new System.Drawing.Point(231, 57);
            this.GitRepositoryBrowse.Name = "GitRepositoryBrowse";
            this.GitRepositoryBrowse.Size = new System.Drawing.Size(75, 23);
            this.GitRepositoryBrowse.TabIndex = 10;
            this.GitRepositoryBrowse.Text = "Browse";
            this.GitRepositoryBrowse.UseVisualStyleBackColor = true;
            this.GitRepositoryBrowse.Click += new System.EventHandler(this.BranchRepositoryBrowse_Click);
            // 
            // GitExecutableLabel
            // 
            this.GitExecutableLabel.AutoSize = true;
            this.GitExecutableLabel.Location = new System.Drawing.Point(6, 31);
            this.GitExecutableLabel.Name = "GitExecutableLabel";
            this.GitExecutableLabel.Size = new System.Drawing.Size(60, 13);
            this.GitExecutableLabel.TabIndex = 3;
            this.GitExecutableLabel.Text = "Executable";
            // 
            // GitExecutableBrowse
            // 
            this.GitExecutableBrowse.Location = new System.Drawing.Point(231, 27);
            this.GitExecutableBrowse.Name = "GitExecutableBrowse";
            this.GitExecutableBrowse.Size = new System.Drawing.Size(75, 23);
            this.GitExecutableBrowse.TabIndex = 9;
            this.GitExecutableBrowse.Text = "Browse";
            this.GitExecutableBrowse.UseVisualStyleBackColor = true;
            this.GitExecutableBrowse.Click += new System.EventHandler(this.GitExecutablePathBrowse_Click);
            // 
            // GitRepositoryInput
            // 
            this.GitRepositoryInput.Enabled = false;
            this.GitRepositoryInput.Location = new System.Drawing.Point(67, 59);
            this.GitRepositoryInput.Name = "GitRepositoryInput";
            this.GitRepositoryInput.Size = new System.Drawing.Size(158, 20);
            this.GitRepositoryInput.TabIndex = 1;
            // 
            // GitExecutableInput
            // 
            this.GitExecutableInput.Enabled = false;
            this.GitExecutableInput.Location = new System.Drawing.Point(67, 28);
            this.GitExecutableInput.Name = "GitExecutableInput";
            this.GitExecutableInput.Size = new System.Drawing.Size(158, 20);
            this.GitExecutableInput.TabIndex = 0;
            // 
            // GitRepositoryLabel
            // 
            this.GitRepositoryLabel.AutoSize = true;
            this.GitRepositoryLabel.Location = new System.Drawing.Point(6, 62);
            this.GitRepositoryLabel.Name = "GitRepositoryLabel";
            this.GitRepositoryLabel.Size = new System.Drawing.Size(57, 13);
            this.GitRepositoryLabel.TabIndex = 4;
            this.GitRepositoryLabel.Text = "Repository";
            // 
            // GitExecutableDialog
            // 
            this.GitExecutableDialog.FileName = "git.exe";
            this.GitExecutableDialog.InitialDirectory = "C:\\";
            this.GitExecutableDialog.Title = "Git Executable";
            // 
            // GitRepositoryDialog
            // 
            this.GitRepositoryDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.GitRepositoryDialog.ShowNewFolderButton = false;
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainStatusLoading});
            this.MainStatus.Location = new System.Drawing.Point(0, 542);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(1008, 22);
            this.MainStatus.SizingGrip = false;
            this.MainStatus.TabIndex = 1;
            // 
            // MainStatusLoading
            // 
            this.MainStatusLoading.Name = "MainStatusLoading";
            this.MainStatusLoading.Size = new System.Drawing.Size(59, 17);
            this.MainStatusLoading.Text = "Loading...";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 564);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Git Stash Viewer";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainPanel.ResumeLayout(false);
            this.DiffGroup.ResumeLayout(false);
            this.StashGroup.ResumeLayout(false);
            this.StashGroup.PerformLayout();
            this.GitGroup.ResumeLayout(false);
            this.GitGroup.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox GitGroup;
        private System.Windows.Forms.Label GitExecutableLabel;
        private System.Windows.Forms.Button GitExecutableBrowse;
        private System.Windows.Forms.Label GitRepositoryLabel;
        private System.Windows.Forms.ComboBox StashNameCombo;
        private System.Windows.Forms.TextBox GitRepositoryInput;
        private System.Windows.Forms.TextBox GitExecutableInput;
        private System.Windows.Forms.OpenFileDialog GitExecutableDialog;
        private System.Windows.Forms.Button GitRepositoryBrowse;
        private System.Windows.Forms.GroupBox StashGroup;
        private System.Windows.Forms.GroupBox DiffGroup;
        private System.Windows.Forms.RichTextBox DiffViewer;
        private System.Windows.Forms.FolderBrowserDialog GitRepositoryDialog;
        private System.Windows.Forms.Button GitRefresh;
        private System.Windows.Forms.ListView StashFileList;
        private System.Windows.Forms.ImageList ChangeStatusImages;
        private System.Windows.Forms.ColumnHeader FileNameHeader;
        private System.Windows.Forms.Button GitViewCommandLog;
        private System.Windows.Forms.TextBox StashDescriptionLabel;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel MainStatusLoading;

    }
}

