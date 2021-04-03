namespace Wnmp.Updater
{
    partial class UpdatePromptFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePromptFrm));
            this.viewChangelogLabel = new System.Windows.Forms.LinkLabel();
            this.wouldYouLikeToLabel = new System.Windows.Forms.Label();
            this.newVersionLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.noButton = new System.Windows.Forms.Button();
            this.latestVersionLabel = new System.Windows.Forms.Label();
            this.yourVersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewChangelogLabel
            // 
            this.viewChangelogLabel.AutoSize = true;
            this.viewChangelogLabel.Location = new System.Drawing.Point(86, 59);
            this.viewChangelogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.viewChangelogLabel.Name = "viewChangelogLabel";
            this.viewChangelogLabel.Size = new System.Drawing.Size(93, 15);
            this.viewChangelogLabel.TabIndex = 16;
            this.viewChangelogLabel.TabStop = true;
            this.viewChangelogLabel.Text = "View Changelog";
            this.viewChangelogLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewChangelogLabel_LinkClicked);
            // 
            // wouldYouLikeToLabel
            // 
            this.wouldYouLikeToLabel.AutoSize = true;
            this.wouldYouLikeToLabel.Location = new System.Drawing.Point(18, 85);
            this.wouldYouLikeToLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wouldYouLikeToLabel.Name = "wouldYouLikeToLabel";
            this.wouldYouLikeToLabel.Size = new System.Drawing.Size(223, 15);
            this.wouldYouLikeToLabel.TabIndex = 13;
            this.wouldYouLikeToLabel.Text = "Would you like to download this update?";
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.AutoSize = true;
            this.newVersionLabel.Location = new System.Drawing.Point(121, 24);
            this.newVersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(0, 15);
            this.newVersionLabel.TabIndex = 15;
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(21, 117);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(88, 27);
            this.yesButton.TabIndex = 9;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AutoSize = true;
            this.currentVersionLabel.Location = new System.Drawing.Point(121, 9);
            this.currentVersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentVersionLabel.Name = "currentVersionLabel";
            this.currentVersionLabel.Size = new System.Drawing.Size(0, 15);
            this.currentVersionLabel.TabIndex = 14;
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(166, 117);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(88, 27);
            this.noButton.TabIndex = 11;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // latestVersionLabel
            // 
            this.latestVersionLabel.AutoSize = true;
            this.latestVersionLabel.Location = new System.Drawing.Point(14, 24);
            this.latestVersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.latestVersionLabel.Name = "latestVersionLabel";
            this.latestVersionLabel.Size = new System.Drawing.Size(82, 15);
            this.latestVersionLabel.TabIndex = 12;
            this.latestVersionLabel.Text = "Latest version:";
            // 
            // yourVersionLabel
            // 
            this.yourVersionLabel.AutoSize = true;
            this.yourVersionLabel.Location = new System.Drawing.Point(14, 9);
            this.yourVersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yourVersionLabel.Name = "yourVersionLabel";
            this.yourVersionLabel.Size = new System.Drawing.Size(75, 15);
            this.yourVersionLabel.TabIndex = 10;
            this.yourVersionLabel.Text = "Your version:";
            // 
            // UpdatePromptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 158);
            this.Controls.Add(this.viewChangelogLabel);
            this.Controls.Add(this.wouldYouLikeToLabel);
            this.Controls.Add(this.newVersionLabel);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.currentVersionLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.latestVersionLabel);
            this.Controls.Add(this.yourVersionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePromptFrm";
            this.Text = "New Version Found!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel viewChangelogLabel;
        private System.Windows.Forms.Label wouldYouLikeToLabel;
        public System.Windows.Forms.Label newVersionLabel;
        private System.Windows.Forms.Button yesButton;
        public System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label latestVersionLabel;
        private System.Windows.Forms.Label yourVersionLabel;
    }
}