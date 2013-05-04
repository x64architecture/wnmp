namespace Wnmp
{
    partial class Options
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
            this.label1 = new System.Windows.Forms.Label();
            this.editorTB = new System.Windows.Forms.TextBox();
            this.selecteditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editor:";
            // 
            // editorTB
            // 
            this.editorTB.Location = new System.Drawing.Point(55, 19);
            this.editorTB.Name = "editorTB";
            this.editorTB.ReadOnly = true;
            this.editorTB.Size = new System.Drawing.Size(161, 20);
            this.editorTB.TabIndex = 1;
            // 
            // selecteditor
            // 
            this.selecteditor.Location = new System.Drawing.Point(222, 19);
            this.selecteditor.Name = "selecteditor";
            this.selecteditor.Size = new System.Drawing.Size(31, 21);
            this.selecteditor.TabIndex = 2;
            this.selecteditor.Text = "..";
            this.selecteditor.UseVisualStyleBackColor = true;
            this.selecteditor.Click += new System.EventHandler(this.selecteditor_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 53);
            this.Controls.Add(this.selecteditor);
            this.Controls.Add(this.editorTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(276, 91);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(276, 91);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editorTB;
        private System.Windows.Forms.Button selecteditor;

    }
}