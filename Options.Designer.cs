/*
This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.label1 = new System.Windows.Forms.Label();
            this.editorTB = new System.Windows.Forms.TextBox();
            this.selecteditor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.suwnmpcb = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.suap = new System.Windows.Forms.CheckBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Wnmp on start up?:";
            // 
            // suwnmpcb
            // 
            this.suwnmpcb.AutoSize = true;
            this.suwnmpcb.Location = new System.Drawing.Point(168, 54);
            this.suwnmpcb.Name = "suwnmpcb";
            this.suwnmpcb.Size = new System.Drawing.Size(15, 14);
            this.suwnmpcb.TabIndex = 4;
            this.suwnmpcb.UseVisualStyleBackColor = true;
            this.suwnmpcb.CheckedChanged += new System.EventHandler(this.suwnmpcb_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start all programs on start up?:";
            // 
            // suap
            // 
            this.suap.AutoSize = true;
            this.suap.Location = new System.Drawing.Point(168, 79);
            this.suap.Name = "suap";
            this.suap.Size = new System.Drawing.Size(15, 14);
            this.suap.TabIndex = 7;
            this.suap.UseVisualStyleBackColor = true;
            this.suap.CheckedChanged += new System.EventHandler(this.suap_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 101);
            this.Controls.Add(this.suap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.suwnmpcb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selecteditor);
            this.Controls.Add(this.editorTB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 139);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 139);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox suwnmpcb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox suap;

    }
}