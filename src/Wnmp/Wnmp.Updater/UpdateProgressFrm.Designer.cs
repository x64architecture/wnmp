namespace Wnmp.Updater
{
    partial class UpdateProgressFrm
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
            if (disposing && (components != null)) {
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
            this.progressLabel = new System.Windows.Forms.Label();
            this.cancelDownloadButton = new System.Windows.Forms.Button();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(293, 18);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(17, 15);
            this.progressLabel.TabIndex = 9;
            this.progressLabel.Text = "%";
            // 
            // cancelDownloadButton
            // 
            this.cancelDownloadButton.Location = new System.Drawing.Point(279, 85);
            this.cancelDownloadButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelDownloadButton.Name = "cancelDownloadButton";
            this.cancelDownloadButton.Size = new System.Drawing.Size(88, 27);
            this.cancelDownloadButton.TabIndex = 7;
            this.cancelDownloadButton.Text = "Cancel";
            this.cancelDownloadButton.Click += new System.EventHandler(this.CancelDownloadButton_Click);
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(79, 18);
            this.downloadLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(195, 15);
            this.downloadLabel.TabIndex = 8;
            this.downloadLabel.Text = "Download in progress, please wait...";
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Location = new System.Drawing.Point(22, 47);
            this.updateProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(323, 27);
            this.updateProgressBar.TabIndex = 6;
            // 
            // UpdateProgressFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 126);
            this.ControlBox = false;
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.cancelDownloadButton);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.updateProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UpdateProgressFrm";
            this.Text = "Downloading Update...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button cancelDownloadButton;
        public System.Windows.Forms.Label downloadLabel;
        public System.Windows.Forms.ProgressBar updateProgressBar;
    }
}