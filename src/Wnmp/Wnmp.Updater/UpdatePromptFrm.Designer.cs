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
            this.label1 = new System.Windows.Forms.Label();
            this.newVersionLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.currentVersionLabel = new System.Windows.Forms.Label();
            this.noButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewChangelogLabel
            // 
            this.viewChangelogLabel.AutoSize = true;
            this.viewChangelogLabel.Location = new System.Drawing.Point(74, 51);
            this.viewChangelogLabel.Name = "viewChangelogLabel";
            this.viewChangelogLabel.Size = new System.Drawing.Size(84, 13);
            this.viewChangelogLabel.TabIndex = 16;
            this.viewChangelogLabel.TabStop = true;
            this.viewChangelogLabel.Text = "View Changelog";
            this.viewChangelogLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewChangelogLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Would wou like to download this update?";
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.AutoSize = true;
            this.newVersionLabel.Location = new System.Drawing.Point(104, 21);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(0, 13);
            this.newVersionLabel.TabIndex = 15;
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(18, 101);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 9;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // currentVersionLabel
            // 
            this.currentVersionLabel.AutoSize = true;
            this.currentVersionLabel.Location = new System.Drawing.Point(104, 8);
            this.currentVersionLabel.Name = "currentVersionLabel";
            this.currentVersionLabel.Size = new System.Drawing.Size(0, 13);
            this.currentVersionLabel.TabIndex = 14;
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(142, 101);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 11;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Newest version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Your version:";
            // 
            // UpdatePromptFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 137);
            this.Controls.Add(this.viewChangelogLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newVersionLabel);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.currentVersionLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePromptFrm";
            this.Text = "New Version Found!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel viewChangelogLabel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label newVersionLabel;
        private System.Windows.Forms.Button yesButton;
        public System.Windows.Forms.Label currentVersionLabel;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}