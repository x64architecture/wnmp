namespace Wnmp.UI
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.Closebtn = new System.Windows.Forms.Button();
            this.AboutTabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.wnmpwebsiteLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wnmpcpversionLabel = new System.Windows.Forms.Label();
            this.wnmpversionLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.License = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.AboutTabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.License.SuspendLayout();
            this.SuspendLayout();
            // 
            // Closebtn
            // 
            this.Closebtn.Location = new System.Drawing.Point(602, 363);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(75, 23);
            this.Closebtn.TabIndex = 0;
            this.Closebtn.Text = "Close";
            this.Closebtn.UseVisualStyleBackColor = true;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // AboutTabCtrl
            // 
            this.AboutTabCtrl.Controls.Add(this.tabPage1);
            this.AboutTabCtrl.Controls.Add(this.tabPage2);
            this.AboutTabCtrl.Controls.Add(this.License);
            this.AboutTabCtrl.Location = new System.Drawing.Point(12, 12);
            this.AboutTabCtrl.Name = "AboutTabCtrl";
            this.AboutTabCtrl.SelectedIndex = 0;
            this.AboutTabCtrl.Size = new System.Drawing.Size(665, 345);
            this.AboutTabCtrl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.wnmpwebsiteLabel);
            this.tabPage1.Controls.Add(this.copyrightLabel);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.wnmpcpversionLabel);
            this.tabPage1.Controls.Add(this.wnmpversionLabel);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Version";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // wnmpwebsiteLabel
            // 
            this.wnmpwebsiteLabel.AutoSize = true;
            this.wnmpwebsiteLabel.Location = new System.Drawing.Point(240, 271);
            this.wnmpwebsiteLabel.Name = "wnmpwebsiteLabel";
            this.wnmpwebsiteLabel.Size = new System.Drawing.Size(186, 20);
            this.wnmpwebsiteLabel.TabIndex = 5;
            this.wnmpwebsiteLabel.Text = "https://www.getwnmp.org";
            this.wnmpwebsiteLabel.Click += new System.EventHandler(this.wnmpwebsiteLabel_Click);
            this.wnmpwebsiteLabel.MouseLeave += new System.EventHandler(this.wnmpwebsiteLabel_MouseLeave);
            this.wnmpwebsiteLabel.MouseHover += new System.EventHandler(this.wnmpwebsiteLabel_MouseHover);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.Location = new System.Drawing.Point(190, 241);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(290, 18);
            this.copyrightLabel.TabIndex = 4;
            this.copyrightLabel.Text = "Copyright (C) 2012 - 2016 by Kurt Cancemi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 117);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Wnmp is an easy Nginx, MariaDB, and PHP environment for Windows.";
            // 
            // wnmpcpversionLabel
            // 
            this.wnmpcpversionLabel.AutoSize = true;
            this.wnmpcpversionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wnmpcpversionLabel.Location = new System.Drawing.Point(6, 54);
            this.wnmpcpversionLabel.Name = "wnmpcpversionLabel";
            this.wnmpcpversionLabel.Size = new System.Drawing.Size(231, 18);
            this.wnmpcpversionLabel.TabIndex = 1;
            this.wnmpcpversionLabel.Text = "Wnmp Control Panel Version:";
            // 
            // wnmpversionLabel
            // 
            this.wnmpversionLabel.AutoSize = true;
            this.wnmpversionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wnmpversionLabel.Location = new System.Drawing.Point(6, 15);
            this.wnmpversionLabel.Name = "wnmpversionLabel";
            this.wnmpversionLabel.Size = new System.Drawing.Size(123, 18);
            this.wnmpversionLabel.TabIndex = 0;
            this.wnmpversionLabel.Text = "Wnmp Version:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Developers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(651, 313);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "Developers\n=========\nKurt Cancemi <kurt@x64architecture.com>";
            // 
            // License
            // 
            this.License.Controls.Add(this.richTextBox1);
            this.License.Location = new System.Drawing.Point(4, 22);
            this.License.Name = "License";
            this.License.Padding = new System.Windows.Forms.Padding(3);
            this.License.Size = new System.Drawing.Size(657, 319);
            this.License.TabIndex = 2;
            this.License.Text = "License";
            this.License.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(645, 313);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 396);
            this.Controls.Add(this.AboutTabCtrl);
            this.Controls.Add(this.Closebtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(697, 434);
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.AboutTabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.License.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.TabControl AboutTabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label wnmpcpversionLabel;
        private System.Windows.Forms.Label wnmpversionLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label wnmpwebsiteLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.TabPage License;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}