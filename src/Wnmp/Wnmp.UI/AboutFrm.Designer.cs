namespace Wnmp.Wnmp.UI
{
    partial class AboutFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutFrm));
            this.aboutTabCtrl = new System.Windows.Forms.TabControl();
            this.versionTabPage = new System.Windows.Forms.TabPage();
            this.wnmpWebsiteLabel = new System.Windows.Forms.LinkLabel();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wnmpDescription = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.licenseTabPage = new System.Windows.Forms.TabPage();
            this.licenseRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.aboutTabCtrl.SuspendLayout();
            this.versionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.licenseTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutTabCtrl
            // 
            this.aboutTabCtrl.Controls.Add(this.versionTabPage);
            this.aboutTabCtrl.Controls.Add(this.licenseTabPage);
            this.aboutTabCtrl.Location = new System.Drawing.Point(9, 13);
            this.aboutTabCtrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.aboutTabCtrl.Name = "aboutTabCtrl";
            this.aboutTabCtrl.SelectedIndex = 0;
            this.aboutTabCtrl.Size = new System.Drawing.Size(776, 318);
            this.aboutTabCtrl.TabIndex = 3;
            // 
            // versionTabPage
            // 
            this.versionTabPage.Controls.Add(this.wnmpWebsiteLabel);
            this.versionTabPage.Controls.Add(this.copyrightLabel);
            this.versionTabPage.Controls.Add(this.pictureBox1);
            this.versionTabPage.Controls.Add(this.wnmpDescription);
            this.versionTabPage.Controls.Add(this.versionLabel);
            this.versionTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.versionTabPage.Location = new System.Drawing.Point(4, 24);
            this.versionTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.versionTabPage.Name = "versionTabPage";
            this.versionTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.versionTabPage.Size = new System.Drawing.Size(768, 290);
            this.versionTabPage.TabIndex = 0;
            this.versionTabPage.Text = "Version";
            this.versionTabPage.UseVisualStyleBackColor = true;
            // 
            // wnmpWebsiteLabel
            // 
            this.wnmpWebsiteLabel.AutoSize = true;
            this.wnmpWebsiteLabel.Location = new System.Drawing.Point(250, 227);
            this.wnmpWebsiteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wnmpWebsiteLabel.Name = "wnmpWebsiteLabel";
            this.wnmpWebsiteLabel.Size = new System.Drawing.Size(246, 20);
            this.wnmpWebsiteLabel.TabIndex = 6;
            this.wnmpWebsiteLabel.TabStop = true;
            this.wnmpWebsiteLabel.Text = "https://wnmp.x64architecture.com";
            this.wnmpWebsiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wnmpWebsiteLabel_LinkClicked);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyrightLabel.Location = new System.Drawing.Point(223, 196);
            this.copyrightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(378, 18);
            this.copyrightLabel.TabIndex = 4;
            this.copyrightLabel.Text = "Copyright (c) 2012 - {CURRENTYEAR} by Kurt Cancemi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(149, 148);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(149, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 148);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // wnmpDescription
            // 
            this.wnmpDescription.AutoSize = true;
            this.wnmpDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wnmpDescription.Location = new System.Drawing.Point(166, 98);
            this.wnmpDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wnmpDescription.Name = "wnmpDescription";
            this.wnmpDescription.Size = new System.Drawing.Size(148, 16);
            this.wnmpDescription.TabIndex = 2;
            this.wnmpDescription.Text = "WNMP_DESCRIPTION";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.versionLabel.Location = new System.Drawing.Point(7, 17);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(143, 18);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "WNMP_VERSION";
            // 
            // licenseTabPage
            // 
            this.licenseTabPage.Controls.Add(this.licenseRichTextBox);
            this.licenseTabPage.Location = new System.Drawing.Point(4, 24);
            this.licenseTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.licenseTabPage.Name = "licenseTabPage";
            this.licenseTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.licenseTabPage.Size = new System.Drawing.Size(768, 290);
            this.licenseTabPage.TabIndex = 2;
            this.licenseTabPage.Text = "License";
            this.licenseTabPage.UseVisualStyleBackColor = true;
            // 
            // licenseRichTextBox
            // 
            this.licenseRichTextBox.BackColor = System.Drawing.Color.White;
            this.licenseRichTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.licenseRichTextBox.Location = new System.Drawing.Point(7, 3);
            this.licenseRichTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.licenseRichTextBox.Name = "licenseRichTextBox";
            this.licenseRichTextBox.ReadOnly = true;
            this.licenseRichTextBox.Size = new System.Drawing.Size(752, 361);
            this.licenseRichTextBox.TabIndex = 0;
            this.licenseRichTextBox.Text = resources.GetString("licenseRichTextBox.Text");
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(698, 338);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(88, 27);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 375);
            this.Controls.Add(this.aboutTabCtrl);
            this.Controls.Add(this.CloseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutFrm";
            this.Text = "About";
            this.aboutTabCtrl.ResumeLayout(false);
            this.versionTabPage.ResumeLayout(false);
            this.versionTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.licenseTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl aboutTabCtrl;
        private System.Windows.Forms.TabPage versionTabPage;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label wnmpDescription;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TabPage licenseTabPage;
        private System.Windows.Forms.RichTextBox licenseRichTextBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.LinkLabel wnmpWebsiteLabel;
    }
}