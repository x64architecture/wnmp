namespace Wnmp.UI
{
    partial class UpdatePrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePrompt));
            this.Yes = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewchange = new System.Windows.Forms.LinkLabel();
            this.newversion = new System.Windows.Forms.Label();
            this.currentversion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Yes
            // 
            this.Yes.Location = new System.Drawing.Point(51, 126);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(75, 23);
            this.Yes.TabIndex = 1;
            this.Yes.Text = "Yes";
            this.Yes.UseVisualStyleBackColor = true;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // No
            // 
            this.No.Location = new System.Drawing.Point(175, 126);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(75, 23);
            this.No.TabIndex = 2;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Would wou like to download this update?";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.viewchange);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.newversion);
            this.panel2.Controls.Add(this.Yes);
            this.panel2.Controls.Add(this.currentversion);
            this.panel2.Controls.Add(this.No);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(303, 165);
            this.panel2.TabIndex = 4;
            // 
            // viewchange
            // 
            this.viewchange.AutoSize = true;
            this.viewchange.Location = new System.Drawing.Point(101, 75);
            this.viewchange.Name = "viewchange";
            this.viewchange.Size = new System.Drawing.Size(84, 13);
            this.viewchange.TabIndex = 7;
            this.viewchange.TabStop = true;
            this.viewchange.Text = "View Changelog";
            this.viewchange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.viewchange_LinkClicked);
            // 
            // newversion
            // 
            this.newversion.AutoSize = true;
            this.newversion.Location = new System.Drawing.Point(111, 47);
            this.newversion.Name = "newversion";
            this.newversion.Size = new System.Drawing.Size(67, 13);
            this.newversion.TabIndex = 5;
            this.newversion.Text = "New Version";
            // 
            // currentversion
            // 
            this.currentversion.AutoSize = true;
            this.currentversion.Location = new System.Drawing.Point(111, 34);
            this.currentversion.Name = "currentversion";
            this.currentversion.Size = new System.Drawing.Size(79, 13);
            this.currentversion.TabIndex = 4;
            this.currentversion.Text = "Current Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Newest version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Your version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "New version found!";
            // 
            // UpdatePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 165);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePrompt";
            this.Text = "Check For Updates";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Yes;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label currentversion;
        public System.Windows.Forms.Label newversion;
        private System.Windows.Forms.LinkLabel viewchange;
    }
}