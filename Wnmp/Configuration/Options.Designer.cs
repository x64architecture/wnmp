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
namespace Wnmp.Forms
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
            this.Save = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selecteditor = new System.Windows.Forms.Button();
            this.UpdateCheckInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StartAllProgramsOnLaunch = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartWnmpWithWindows = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoUpdate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.editorTB = new System.Windows.Forms.TextBox();
            this.MinimizeWnmpToTray = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PHP = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.phpBin = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PHP_PROCESSES = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.PHP_PORT = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.phpExtListBox = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.General.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateCheckInterval)).BeginInit();
            this.PHP.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(188, 346);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.PHP);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 328);
            this.tabControl1.TabIndex = 16;
            // 
            // General
            // 
            this.General.Controls.Add(this.groupBox1);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(339, 302);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selecteditor);
            this.groupBox1.Controls.Add(this.UpdateCheckInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StartAllProgramsOnLaunch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.StartWnmpWithWindows);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AutoUpdate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.editorTB);
            this.groupBox1.Controls.Add(this.MinimizeWnmpToTray);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 190);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Settings";
            // 
            // selecteditor
            // 
            this.selecteditor.Location = new System.Drawing.Point(235, 20);
            this.selecteditor.Name = "selecteditor";
            this.selecteditor.Size = new System.Drawing.Size(26, 23);
            this.selecteditor.TabIndex = 14;
            this.selecteditor.Text = "...";
            this.selecteditor.UseVisualStyleBackColor = true;
            this.selecteditor.Click += new System.EventHandler(this.selecteditor_Click);
            // 
            // UpdateCheckInterval
            // 
            this.UpdateCheckInterval.Location = new System.Drawing.Point(195, 154);
            this.UpdateCheckInterval.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.UpdateCheckInterval.Name = "UpdateCheckInterval";
            this.UpdateCheckInterval.Size = new System.Drawing.Size(66, 20);
            this.UpdateCheckInterval.TabIndex = 13;
            this.UpdateCheckInterval.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Update check interval (in days):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editor:";
            // 
            // StartAllProgramsOnLaunch
            // 
            this.StartAllProgramsOnLaunch.AutoSize = true;
            this.StartAllProgramsOnLaunch.Location = new System.Drawing.Point(195, 79);
            this.StartAllProgramsOnLaunch.Name = "StartAllProgramsOnLaunch";
            this.StartAllProgramsOnLaunch.Size = new System.Drawing.Size(15, 14);
            this.StartAllProgramsOnLaunch.TabIndex = 7;
            this.StartAllProgramsOnLaunch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start all programs on launch?:";
            // 
            // StartWnmpWithWindows
            // 
            this.StartWnmpWithWindows.AutoSize = true;
            this.StartWnmpWithWindows.Location = new System.Drawing.Point(195, 57);
            this.StartWnmpWithWindows.Name = "StartWnmpWithWindows";
            this.StartWnmpWithWindows.Size = new System.Drawing.Size(15, 14);
            this.StartWnmpWithWindows.TabIndex = 4;
            this.StartWnmpWithWindows.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Wnmp on start up?:";
            // 
            // AutoUpdate
            // 
            this.AutoUpdate.AutoSize = true;
            this.AutoUpdate.Location = new System.Drawing.Point(195, 130);
            this.AutoUpdate.Name = "AutoUpdate";
            this.AutoUpdate.Size = new System.Drawing.Size(15, 14);
            this.AutoUpdate.TabIndex = 11;
            this.AutoUpdate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Automatically check for updates?:";
            // 
            // editorTB
            // 
            this.editorTB.Location = new System.Drawing.Point(68, 22);
            this.editorTB.Name = "editorTB";
            this.editorTB.ReadOnly = true;
            this.editorTB.Size = new System.Drawing.Size(161, 20);
            this.editorTB.TabIndex = 1;
            this.editorTB.DoubleClick += new System.EventHandler(this.editorTB_DoubleClick);
            // 
            // MinimizeWnmpToTray
            // 
            this.MinimizeWnmpToTray.AutoSize = true;
            this.MinimizeWnmpToTray.Location = new System.Drawing.Point(195, 105);
            this.MinimizeWnmpToTray.Name = "MinimizeWnmpToTray";
            this.MinimizeWnmpToTray.Size = new System.Drawing.Size(15, 14);
            this.MinimizeWnmpToTray.TabIndex = 9;
            this.MinimizeWnmpToTray.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minimize Wnmp to the tray?:";
            // 
            // PHP
            // 
            this.PHP.Controls.Add(this.groupBox3);
            this.PHP.Controls.Add(this.groupBox2);
            this.PHP.Location = new System.Drawing.Point(4, 22);
            this.PHP.Name = "PHP";
            this.PHP.Padding = new System.Windows.Forms.Padding(3);
            this.PHP.Size = new System.Drawing.Size(339, 302);
            this.PHP.TabIndex = 1;
            this.PHP.Text = "PHP";
            this.PHP.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.phpBin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.PHP_PROCESSES);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.PHP_PORT);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PHP Settings";
            // 
            // phpBin
            // 
            this.phpBin.FormattingEnabled = true;
            this.phpBin.Location = new System.Drawing.Point(108, 78);
            this.phpBin.Name = "phpBin";
            this.phpBin.Size = new System.Drawing.Size(69, 21);
            this.phpBin.TabIndex = 5;
            this.phpBin.SelectedIndexChanged += new System.EventHandler(this.phpBin_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "PHP Version:";
            // 
            // PHP_PROCESSES
            // 
            this.PHP_PROCESSES.Location = new System.Drawing.Point(108, 25);
            this.PHP_PROCESSES.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PHP_PROCESSES.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PHP_PROCESSES.Name = "PHP_PROCESSES";
            this.PHP_PROCESSES.Size = new System.Drawing.Size(69, 20);
            this.PHP_PROCESSES.TabIndex = 3;
            this.PHP_PROCESSES.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "PHP Processes:";
            // 
            // PHP_PORT
            // 
            this.PHP_PORT.Location = new System.Drawing.Point(108, 50);
            this.PHP_PORT.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PHP_PORT.Name = "PHP_PORT";
            this.PHP_PORT.Size = new System.Drawing.Size(69, 20);
            this.PHP_PORT.TabIndex = 1;
            this.PHP_PORT.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "PHP Port:";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(280, 346);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 17;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.phpExtListBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 174);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PHP Extensions";
            // 
            // phpExtListBox
            // 
            this.phpExtListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phpExtListBox.FormattingEnabled = true;
            this.phpExtListBox.Location = new System.Drawing.Point(3, 16);
            this.phpExtListBox.Name = "phpExtListBox";
            this.phpExtListBox.Size = new System.Drawing.Size(320, 155);
            this.phpExtListBox.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 381);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(298, 250);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabControl1.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateCheckInterval)).EndInit();
            this.PHP.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage PHP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selecteditor;
        private System.Windows.Forms.NumericUpDown UpdateCheckInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox StartAllProgramsOnLaunch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox StartWnmpWithWindows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AutoUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox editorTB;
        private System.Windows.Forms.CheckBox MinimizeWnmpToTray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown PHP_PORT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.NumericUpDown PHP_PROCESSES;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox phpBin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox phpExtListBox;
    }
}
