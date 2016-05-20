namespace Wnmp.UI
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
            this.MinimizeToTrayInsteadOfClosing = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.StartNginxLaunchCB = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.StartMySQLLaunchCB = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.selecteditor = new System.Windows.Forms.Button();
            this.UpdateCheckInterval = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StartPHPLaunchCB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartWnmpWithWindows = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoUpdate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.editorTB = new System.Windows.Forms.TextBox();
            this.MinimizeWnmpToTray = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PHP = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.phpExtListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.phpBin = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PHP_PROCESSES = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.PHP_PORT = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.StartMinimizedToTray = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.General.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateCheckInterval)).BeginInit();
            this.PHP.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).BeginInit();
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
            this.groupBox1.Controls.Add(this.StartMinimizedToTray);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.MinimizeToTrayInsteadOfClosing);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.StartNginxLaunchCB);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.StartMySQLLaunchCB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.selecteditor);
            this.groupBox1.Controls.Add(this.UpdateCheckInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StartPHPLaunchCB);
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
            this.groupBox1.Size = new System.Drawing.Size(327, 240);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Settings";
            // 
            // MinimizeToTrayInsteadOfClosing
            // 
            this.MinimizeToTrayInsteadOfClosing.AutoSize = true;
            this.MinimizeToTrayInsteadOfClosing.Location = new System.Drawing.Point(226, 150);
            this.MinimizeToTrayInsteadOfClosing.Name = "MinimizeToTrayInsteadOfClosing";
            this.MinimizeToTrayInsteadOfClosing.Size = new System.Drawing.Size(15, 14);
            this.MinimizeToTrayInsteadOfClosing.TabIndex = 22;
            this.MinimizeToTrayInsteadOfClosing.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Minimize to tray instead of closing";
            // 
            // StartNginxLaunchCB
            // 
            this.StartNginxLaunchCB.AutoSize = true;
            this.StartNginxLaunchCB.Location = new System.Drawing.Point(226, 70);
            this.StartNginxLaunchCB.Name = "StartNginxLaunchCB";
            this.StartNginxLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartNginxLaunchCB.TabIndex = 18;
            this.StartNginxLaunchCB.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Start Nginx on launch";
            // 
            // StartMySQLLaunchCB
            // 
            this.StartMySQLLaunchCB.AutoSize = true;
            this.StartMySQLLaunchCB.Location = new System.Drawing.Point(226, 90);
            this.StartMySQLLaunchCB.Name = "StartMySQLLaunchCB";
            this.StartMySQLLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartMySQLLaunchCB.TabIndex = 16;
            this.StartMySQLLaunchCB.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Start MySQL on launch";
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
            this.UpdateCheckInterval.Location = new System.Drawing.Point(226, 210);
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
            this.label6.Location = new System.Drawing.Point(25, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Update check interval (in days)";
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
            // StartPHPLaunchCB
            // 
            this.StartPHPLaunchCB.AutoSize = true;
            this.StartPHPLaunchCB.Location = new System.Drawing.Point(226, 110);
            this.StartPHPLaunchCB.Name = "StartPHPLaunchCB";
            this.StartPHPLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartPHPLaunchCB.TabIndex = 7;
            this.StartPHPLaunchCB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start PHP on launch";
            // 
            // StartWnmpWithWindows
            // 
            this.StartWnmpWithWindows.AutoSize = true;
            this.StartWnmpWithWindows.Location = new System.Drawing.Point(226, 50);
            this.StartWnmpWithWindows.Name = "StartWnmpWithWindows";
            this.StartWnmpWithWindows.Size = new System.Drawing.Size(15, 14);
            this.StartWnmpWithWindows.TabIndex = 4;
            this.StartWnmpWithWindows.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Wnmp with Windows";
            // 
            // AutoUpdate
            // 
            this.AutoUpdate.AutoSize = true;
            this.AutoUpdate.Location = new System.Drawing.Point(226, 190);
            this.AutoUpdate.Name = "AutoUpdate";
            this.AutoUpdate.Size = new System.Drawing.Size(15, 14);
            this.AutoUpdate.TabIndex = 11;
            this.AutoUpdate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Automatically check for updates";
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
            this.MinimizeWnmpToTray.Location = new System.Drawing.Point(226, 130);
            this.MinimizeWnmpToTray.Name = "MinimizeWnmpToTray";
            this.MinimizeWnmpToTray.Size = new System.Drawing.Size(15, 14);
            this.MinimizeWnmpToTray.TabIndex = 9;
            this.MinimizeWnmpToTray.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Minimize to tray instead of minimizing";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Start Wnmp minimized";
            // 
            // StartMinimizedToTray
            // 
            this.StartMinimizedToTray.AutoSize = true;
            this.StartMinimizedToTray.Location = new System.Drawing.Point(226, 170);
            this.StartMinimizedToTray.Name = "StartMinimizedToTray";
            this.StartMinimizedToTray.Size = new System.Drawing.Size(15, 14);
            this.StartMinimizedToTray.TabIndex = 24;
            this.StartMinimizedToTray.UseVisualStyleBackColor = true;
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).EndInit();
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
        private System.Windows.Forms.CheckBox StartPHPLaunchCB;
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
        private System.Windows.Forms.CheckBox StartNginxLaunchCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox StartMySQLLaunchCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox MinimizeToTrayInsteadOfClosing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox StartMinimizedToTray;
        private System.Windows.Forms.Label label13;
    }
}
