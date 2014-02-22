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
            this.label4 = new System.Windows.Forms.Label();
            this.mwttb = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.autoupdate = new System.Windows.Forms.CheckBox();
            this.autoupdateopt = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
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
            this.suwnmpcb.Location = new System.Drawing.Point(182, 54);
            this.suwnmpcb.Name = "suwnmpcb";
            this.suwnmpcb.Size = new System.Drawing.Size(15, 14);
            this.suwnmpcb.TabIndex = 4;
            this.suwnmpcb.UseVisualStyleBackColor = true;
            this.suwnmpcb.CheckedChanged += new System.EventHandler(this.suwnmpcb_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 48);
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
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start all programs on launch?:";
            // 
            // suap
            // 
            this.suap.AutoSize = true;
            this.suap.Location = new System.Drawing.Point(182, 78);
            this.suap.Name = "suap";
            this.suap.Size = new System.Drawing.Size(15, 14);
            this.suap.TabIndex = 7;
            this.suap.UseVisualStyleBackColor = true;
            this.suap.CheckedChanged += new System.EventHandler(this.suap_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minimize Wnmp to the tray?:";
            // 
            // mwttb
            // 
            this.mwttb.AutoSize = true;
            this.mwttb.Location = new System.Drawing.Point(182, 104);
            this.mwttb.Name = "mwttb";
            this.mwttb.Size = new System.Drawing.Size(15, 14);
            this.mwttb.TabIndex = 9;
            this.mwttb.UseVisualStyleBackColor = true;
            this.mwttb.CheckedChanged += new System.EventHandler(this.mwttb_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Automatically check for updates?:";
            // 
            // autoupdate
            // 
            this.autoupdate.AutoSize = true;
            this.autoupdate.Location = new System.Drawing.Point(182, 128);
            this.autoupdate.Name = "autoupdate";
            this.autoupdate.Size = new System.Drawing.Size(15, 14);
            this.autoupdate.TabIndex = 11;
            this.autoupdate.UseVisualStyleBackColor = true;
            this.autoupdate.CheckedChanged += new System.EventHandler(this.autoupdate_CheckedChanged);
            // 
            // autoupdateopt
            // 
            this.autoupdateopt.FormattingEnabled = true;
            this.autoupdateopt.Items.AddRange(new object[] {
            "Every Day",
            "Every Week",
            "Every Month"});
            this.autoupdateopt.Location = new System.Drawing.Point(31, 144);
            this.autoupdateopt.Name = "autoupdateopt";
            this.autoupdateopt.Size = new System.Drawing.Size(121, 21);
            this.autoupdateopt.TabIndex = 12;
            this.autoupdateopt.SelectedIndexChanged += new System.EventHandler(this.autoupdateopt_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(182, 177);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 211);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.autoupdateopt);
            this.Controls.Add(this.autoupdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mwttb);
            this.Controls.Add(this.label4);
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
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(298, 250);
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox mwttb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox autoupdate;
        private System.Windows.Forms.ComboBox autoupdateopt;
        private System.Windows.Forms.Button Save;

    }
}