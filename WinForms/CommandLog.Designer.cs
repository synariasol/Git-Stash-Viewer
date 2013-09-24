namespace GSV
{
    partial class CommandLog
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
            this.CommandLogViewer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CommandLogViewer
            // 
            this.CommandLogViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandLogViewer.BackColor = System.Drawing.Color.White;
            this.CommandLogViewer.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.CommandLogViewer.Location = new System.Drawing.Point(12, 12);
            this.CommandLogViewer.Multiline = true;
            this.CommandLogViewer.Name = "CommandLogViewer";
            this.CommandLogViewer.ReadOnly = true;
            this.CommandLogViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandLogViewer.Size = new System.Drawing.Size(550, 387);
            this.CommandLogViewer.TabIndex = 0;
            this.CommandLogViewer.WordWrap = false;
            // 
            // CommandLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 411);
            this.Controls.Add(this.CommandLogViewer);
            this.Name = "CommandLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Command Log";
            this.Load += new System.EventHandler(this.CommandLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommandLogViewer;
    }
}