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
            this.StartWnmpWithWindows = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.StartAllProgramsOnLaunch = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MinimizeWnmpToTray = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AutoUpdate = new System.Windows.Forms.CheckBox();
            this.AutoUpdateFrequency = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.lastcheckforupdateTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            // StartWnmpWithWindows
            // 
            this.StartWnmpWithWindows.AutoSize = true;
            this.StartWnmpWithWindows.Location = new System.Drawing.Point(182, 54);
            this.StartWnmpWithWindows.Name = "StartWnmpWithWindows";
            this.StartWnmpWithWindows.Size = new System.Drawing.Size(15, 14);
            this.StartWnmpWithWindows.TabIndex = 4;
            this.StartWnmpWithWindows.UseVisualStyleBackColor = true;
            this.StartWnmpWithWindows.CheckedChanged += new System.EventHandler(this.StartWnmpWithWindows_CheckedChanged);
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
            // StartAllProgramsOnLaunch
            // 
            this.StartAllProgramsOnLaunch.AutoSize = true;
            this.StartAllProgramsOnLaunch.Location = new System.Drawing.Point(182, 78);
            this.StartAllProgramsOnLaunch.Name = "StartAllProgramsOnLaunch";
            this.StartAllProgramsOnLaunch.Size = new System.Drawing.Size(15, 14);
            this.StartAllProgramsOnLaunch.TabIndex = 7;
            this.StartAllProgramsOnLaunch.UseVisualStyleBackColor = true;
            this.StartAllProgramsOnLaunch.CheckedChanged += new System.EventHandler(this.StartAllProgramsOnLaunch_CheckedChanged);
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
            // MinimizeWnmpToTray
            // 
            this.MinimizeWnmpToTray.AutoSize = true;
            this.MinimizeWnmpToTray.Location = new System.Drawing.Point(182, 104);
            this.MinimizeWnmpToTray.Name = "MinimizeWnmpToTray";
            this.MinimizeWnmpToTray.Size = new System.Drawing.Size(15, 14);
            this.MinimizeWnmpToTray.TabIndex = 9;
            this.MinimizeWnmpToTray.UseVisualStyleBackColor = true;
            this.MinimizeWnmpToTray.CheckedChanged += new System.EventHandler(this.MinimizeWnmpToTray_CheckedChanged);
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
            // AutoUpdate
            // 
            this.AutoUpdate.AutoSize = true;
            this.AutoUpdate.Location = new System.Drawing.Point(182, 128);
            this.AutoUpdate.Name = "AutoUpdate";
            this.AutoUpdate.Size = new System.Drawing.Size(15, 14);
            this.AutoUpdate.TabIndex = 11;
            this.AutoUpdate.UseVisualStyleBackColor = true;
            this.AutoUpdate.CheckedChanged += new System.EventHandler(this.AutoUpdate_CheckedChanged);
            // 
            // AutoUpdateFrequency
            // 
            this.AutoUpdateFrequency.FormattingEnabled = true;
            this.AutoUpdateFrequency.Items.AddRange(new object[] {
            "Every Day",
            "Every Week",
            "Every Month"});
            this.AutoUpdateFrequency.Location = new System.Drawing.Point(31, 144);
            this.AutoUpdateFrequency.Name = "AutoUpdateFrequency";
            this.AutoUpdateFrequency.Size = new System.Drawing.Size(121, 21);
            this.AutoUpdateFrequency.TabIndex = 12;
            this.AutoUpdateFrequency.SelectedIndexChanged += new System.EventHandler(this.AutoUpdateFrequency_SelectedIndexChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(182, 205);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // lastcheckforupdateTB
            // 
            this.lastcheckforupdateTB.Location = new System.Drawing.Point(132, 175);
            this.lastcheckforupdateTB.MaxLength = 100;
            this.lastcheckforupdateTB.Name = "lastcheckforupdateTB";
            this.lastcheckforupdateTB.ReadOnly = true;
            this.lastcheckforupdateTB.Size = new System.Drawing.Size(121, 20);
            this.lastcheckforupdateTB.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Last check for update:";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 240);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lastcheckforupdateTB);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.AutoUpdateFrequency);
            this.Controls.Add(this.AutoUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MinimizeWnmpToTray);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StartAllProgramsOnLaunch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartWnmpWithWindows);
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
        private System.Windows.Forms.CheckBox StartWnmpWithWindows;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox StartAllProgramsOnLaunch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox MinimizeWnmpToTray;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox AutoUpdate;
        private System.Windows.Forms.ComboBox AutoUpdateFrequency;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox lastcheckforupdateTB;
        private System.Windows.Forms.Label label6;

    }
}