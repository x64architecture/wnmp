namespace Wnmp.UI
{
    partial class UpdateProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateProgress));
            this.cancelDownload = new System.Windows.Forms.Button();
            this.dowloadTxt = new System.Windows.Forms.Label();
            this.updatebarProgress = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelDownload
            // 
            this.cancelDownload.Location = new System.Drawing.Point(248, 75);
            this.cancelDownload.Name = "cancelDownload";
            this.cancelDownload.Size = new System.Drawing.Size(75, 23);
            this.cancelDownload.TabIndex = 3;
            this.cancelDownload.Text = "Cancel";
            this.cancelDownload.Click += new System.EventHandler(this.cancelDownload_Click);
            // 
            // dowloadTxt
            // 
            this.dowloadTxt.AutoSize = true;
            this.dowloadTxt.Location = new System.Drawing.Point(75, 21);
            this.dowloadTxt.Name = "dowloadTxt";
            this.dowloadTxt.Size = new System.Drawing.Size(177, 13);
            this.dowloadTxt.TabIndex = 4;
            this.dowloadTxt.Text = "Download in progress, please wait...";
            // 
            // updatebarProgress
            // 
            this.updatebarProgress.Location = new System.Drawing.Point(26, 46);
            this.updatebarProgress.Name = "updatebarProgress";
            this.updatebarProgress.Size = new System.Drawing.Size(277, 23);
            this.updatebarProgress.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(258, 21);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(15, 13);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "%";
            // 
            // UpdateProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 109);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.cancelDownload);
            this.Controls.Add(this.dowloadTxt);
            this.Controls.Add(this.updatebarProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(351, 148);
            this.Name = "UpdateProgress";
            this.Text = "Downloading Update...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelDownload;
        public System.Windows.Forms.Label dowloadTxt;
        public System.Windows.Forms.ProgressBar updatebarProgress;
        public System.Windows.Forms.Label progressLabel;
    }
}