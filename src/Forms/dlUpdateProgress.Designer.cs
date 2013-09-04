namespace Wnmp.Forms
{
    partial class dlUpdateProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlUpdateProgress));
            this.Canceldl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Canceldl
            // 
            this.Canceldl.Location = new System.Drawing.Point(248, 75);
            this.Canceldl.Name = "Canceldl";
            this.Canceldl.Size = new System.Drawing.Size(75, 23);
            this.Canceldl.TabIndex = 3;
            this.Canceldl.Text = "Cancel";
            this.Canceldl.Click += new System.EventHandler(this.Canceldl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download in progress, please wait...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(277, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "%";
            // 
            // dlUpdateProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 110);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Canceldl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(351, 148);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(351, 148);
            this.Name = "dlUpdateProgress";
            this.Text = "Downloading Update...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Canceldl;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.Label label2;
    }
}