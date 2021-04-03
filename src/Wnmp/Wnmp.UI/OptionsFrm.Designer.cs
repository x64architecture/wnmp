namespace Wnmp.UI
{
    partial class OptionsFrm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsFrm));
            this.Cancel = new System.Windows.Forms.Button();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.applicationSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.StartMinimizedToTray = new System.Windows.Forms.CheckBox();
            this.startWnmpMinimizedLabel = new System.Windows.Forms.Label();
            this.MinimizeToTrayInsteadOfClosing = new System.Windows.Forms.CheckBox();
            this.minimizeToTrayICLabel = new System.Windows.Forms.Label();
            this.StartNginxLaunchCB = new System.Windows.Forms.CheckBox();
            this.startNginxOnLaunchLabel = new System.Windows.Forms.Label();
            this.StartMySQLLaunchCB = new System.Windows.Forms.CheckBox();
            this.startMariaDBOnLaunchLabel = new System.Windows.Forms.Label();
            this.selecteditor = new System.Windows.Forms.Button();
            this.updateCheckIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.updateCheckIntervalLabel = new System.Windows.Forms.Label();
            this.editorLabel = new System.Windows.Forms.Label();
            this.StartPHPLaunchCB = new System.Windows.Forms.CheckBox();
            this.startPHPOnLaunchLabel = new System.Windows.Forms.Label();
            this.StartWnmpWithWindows = new System.Windows.Forms.CheckBox();
            this.startWnmpWithWindowsLabel = new System.Windows.Forms.Label();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.automaticallyCheckForUpdatesLabel = new System.Windows.Forms.Label();
            this.editorTB = new System.Windows.Forms.TextBox();
            this.MinimizeWnmpToTray = new System.Windows.Forms.CheckBox();
            this.minimizeToTrayLabel = new System.Windows.Forms.Label();
            this.Nginx = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nginxBin = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.MariaDB = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mariadbBin = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
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
            this.Save = new System.Windows.Forms.Button();
            this.optionsTabControl.SuspendLayout();
            this.General.SuspendLayout();
            this.applicationSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateCheckIntervalNumericUpDown)).BeginInit();
            this.Nginx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MariaDB.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.PHP.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(321, 399);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 27);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.General);
            this.optionsTabControl.Controls.Add(this.Nginx);
            this.optionsTabControl.Controls.Add(this.MariaDB);
            this.optionsTabControl.Controls.Add(this.PHP);
            this.optionsTabControl.Location = new System.Drawing.Point(8, 14);
            this.optionsTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(405, 378);
            this.optionsTabControl.TabIndex = 19;
            // 
            // General
            // 
            this.General.Controls.Add(this.applicationSettingsGroupBox);
            this.General.Location = new System.Drawing.Point(4, 24);
            this.General.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.General.Size = new System.Drawing.Size(397, 350);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // applicationSettingsGroupBox
            // 
            this.applicationSettingsGroupBox.Controls.Add(this.StartMinimizedToTray);
            this.applicationSettingsGroupBox.Controls.Add(this.startWnmpMinimizedLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.MinimizeToTrayInsteadOfClosing);
            this.applicationSettingsGroupBox.Controls.Add(this.minimizeToTrayICLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.StartNginxLaunchCB);
            this.applicationSettingsGroupBox.Controls.Add(this.startNginxOnLaunchLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.StartMySQLLaunchCB);
            this.applicationSettingsGroupBox.Controls.Add(this.startMariaDBOnLaunchLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.selecteditor);
            this.applicationSettingsGroupBox.Controls.Add(this.updateCheckIntervalNumericUpDown);
            this.applicationSettingsGroupBox.Controls.Add(this.updateCheckIntervalLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.editorLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.StartPHPLaunchCB);
            this.applicationSettingsGroupBox.Controls.Add(this.startPHPOnLaunchLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.StartWnmpWithWindows);
            this.applicationSettingsGroupBox.Controls.Add(this.startWnmpWithWindowsLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.autoUpdateCheckBox);
            this.applicationSettingsGroupBox.Controls.Add(this.automaticallyCheckForUpdatesLabel);
            this.applicationSettingsGroupBox.Controls.Add(this.editorTB);
            this.applicationSettingsGroupBox.Controls.Add(this.MinimizeWnmpToTray);
            this.applicationSettingsGroupBox.Controls.Add(this.minimizeToTrayLabel);
            this.applicationSettingsGroupBox.Location = new System.Drawing.Point(7, 7);
            this.applicationSettingsGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.applicationSettingsGroupBox.Name = "applicationSettingsGroupBox";
            this.applicationSettingsGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.applicationSettingsGroupBox.Size = new System.Drawing.Size(382, 277);
            this.applicationSettingsGroupBox.TabIndex = 16;
            this.applicationSettingsGroupBox.TabStop = false;
            this.applicationSettingsGroupBox.Text = "Application Settings";
            // 
            // StartMinimizedToTray
            // 
            this.StartMinimizedToTray.AutoSize = true;
            this.StartMinimizedToTray.Location = new System.Drawing.Point(18, 195);
            this.StartMinimizedToTray.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartMinimizedToTray.Name = "StartMinimizedToTray";
            this.StartMinimizedToTray.Size = new System.Drawing.Size(15, 14);
            this.StartMinimizedToTray.TabIndex = 24;
            this.StartMinimizedToTray.UseVisualStyleBackColor = true;
            // 
            // startWnmpMinimizedLabel
            // 
            this.startWnmpMinimizedLabel.AutoSize = true;
            this.startWnmpMinimizedLabel.Location = new System.Drawing.Point(37, 196);
            this.startWnmpMinimizedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startWnmpMinimizedLabel.Name = "startWnmpMinimizedLabel";
            this.startWnmpMinimizedLabel.Size = new System.Drawing.Size(129, 15);
            this.startWnmpMinimizedLabel.TabIndex = 23;
            this.startWnmpMinimizedLabel.Text = "Start Wnmp minimized";
            // 
            // MinimizeToTrayInsteadOfClosing
            // 
            this.MinimizeToTrayInsteadOfClosing.AutoSize = true;
            this.MinimizeToTrayInsteadOfClosing.Location = new System.Drawing.Point(18, 172);
            this.MinimizeToTrayInsteadOfClosing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeToTrayInsteadOfClosing.Name = "MinimizeToTrayInsteadOfClosing";
            this.MinimizeToTrayInsteadOfClosing.Size = new System.Drawing.Size(15, 14);
            this.MinimizeToTrayInsteadOfClosing.TabIndex = 22;
            this.MinimizeToTrayInsteadOfClosing.UseVisualStyleBackColor = true;
            // 
            // minimizeToTrayICLabel
            // 
            this.minimizeToTrayICLabel.AutoSize = true;
            this.minimizeToTrayICLabel.Location = new System.Drawing.Point(37, 173);
            this.minimizeToTrayICLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minimizeToTrayICLabel.Name = "minimizeToTrayICLabel";
            this.minimizeToTrayICLabel.Size = new System.Drawing.Size(189, 15);
            this.minimizeToTrayICLabel.TabIndex = 21;
            this.minimizeToTrayICLabel.Text = "Minimize to tray instead of closing";
            // 
            // StartNginxLaunchCB
            // 
            this.StartNginxLaunchCB.AutoSize = true;
            this.StartNginxLaunchCB.Location = new System.Drawing.Point(18, 80);
            this.StartNginxLaunchCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartNginxLaunchCB.Name = "StartNginxLaunchCB";
            this.StartNginxLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartNginxLaunchCB.TabIndex = 18;
            this.StartNginxLaunchCB.UseVisualStyleBackColor = true;
            // 
            // startNginxOnLaunchLabel
            // 
            this.startNginxOnLaunchLabel.AutoSize = true;
            this.startNginxOnLaunchLabel.Location = new System.Drawing.Point(37, 81);
            this.startNginxOnLaunchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startNginxOnLaunchLabel.Name = "startNginxOnLaunchLabel";
            this.startNginxOnLaunchLabel.Size = new System.Drawing.Size(122, 15);
            this.startNginxOnLaunchLabel.TabIndex = 17;
            this.startNginxOnLaunchLabel.Text = "Start Nginx on launch";
            // 
            // StartMySQLLaunchCB
            // 
            this.StartMySQLLaunchCB.AutoSize = true;
            this.StartMySQLLaunchCB.Location = new System.Drawing.Point(18, 103);
            this.StartMySQLLaunchCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartMySQLLaunchCB.Name = "StartMySQLLaunchCB";
            this.StartMySQLLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartMySQLLaunchCB.TabIndex = 16;
            this.StartMySQLLaunchCB.UseVisualStyleBackColor = true;
            // 
            // startMariaDBOnLaunchLabel
            // 
            this.startMariaDBOnLaunchLabel.AutoSize = true;
            this.startMariaDBOnLaunchLabel.Location = new System.Drawing.Point(37, 104);
            this.startMariaDBOnLaunchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startMariaDBOnLaunchLabel.Name = "startMariaDBOnLaunchLabel";
            this.startMariaDBOnLaunchLabel.Size = new System.Drawing.Size(135, 15);
            this.startMariaDBOnLaunchLabel.TabIndex = 15;
            this.startMariaDBOnLaunchLabel.Text = "Start MariaDB on launch";
            // 
            // selecteditor
            // 
            this.selecteditor.Location = new System.Drawing.Point(239, 25);
            this.selecteditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selecteditor.Name = "selecteditor";
            this.selecteditor.Size = new System.Drawing.Size(30, 23);
            this.selecteditor.TabIndex = 14;
            this.selecteditor.Text = "...";
            this.selecteditor.UseVisualStyleBackColor = true;
            this.selecteditor.Click += new System.EventHandler(this.Selecteditor_Click);
            // 
            // updateCheckIntervalNumericUpDown
            // 
            this.updateCheckIntervalNumericUpDown.Location = new System.Drawing.Point(223, 240);
            this.updateCheckIntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updateCheckIntervalNumericUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.updateCheckIntervalNumericUpDown.Name = "updateCheckIntervalNumericUpDown";
            this.updateCheckIntervalNumericUpDown.Size = new System.Drawing.Size(77, 23);
            this.updateCheckIntervalNumericUpDown.TabIndex = 13;
            this.updateCheckIntervalNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // updateCheckIntervalLabel
            // 
            this.updateCheckIntervalLabel.AutoSize = true;
            this.updateCheckIntervalLabel.Location = new System.Drawing.Point(37, 242);
            this.updateCheckIntervalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateCheckIntervalLabel.Name = "updateCheckIntervalLabel";
            this.updateCheckIntervalLabel.Size = new System.Drawing.Size(169, 15);
            this.updateCheckIntervalLabel.TabIndex = 12;
            this.updateCheckIntervalLabel.Text = "Update check interval (in days)";
            // 
            // editorLabel
            // 
            this.editorLabel.AutoSize = true;
            this.editorLabel.Location = new System.Drawing.Point(13, 29);
            this.editorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editorLabel.Name = "editorLabel";
            this.editorLabel.Size = new System.Drawing.Size(41, 15);
            this.editorLabel.TabIndex = 0;
            this.editorLabel.Text = "Editor:";
            // 
            // StartPHPLaunchCB
            // 
            this.StartPHPLaunchCB.AutoSize = true;
            this.StartPHPLaunchCB.Location = new System.Drawing.Point(18, 126);
            this.StartPHPLaunchCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartPHPLaunchCB.Name = "StartPHPLaunchCB";
            this.StartPHPLaunchCB.Size = new System.Drawing.Size(15, 14);
            this.StartPHPLaunchCB.TabIndex = 7;
            this.StartPHPLaunchCB.UseVisualStyleBackColor = true;
            // 
            // startPHPOnLaunchLabel
            // 
            this.startPHPOnLaunchLabel.AutoSize = true;
            this.startPHPOnLaunchLabel.Location = new System.Drawing.Point(37, 127);
            this.startPHPOnLaunchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startPHPOnLaunchLabel.Name = "startPHPOnLaunchLabel";
            this.startPHPOnLaunchLabel.Size = new System.Drawing.Size(113, 15);
            this.startPHPOnLaunchLabel.TabIndex = 6;
            this.startPHPOnLaunchLabel.Text = "Start PHP on launch";
            // 
            // StartWnmpWithWindows
            // 
            this.StartWnmpWithWindows.AutoSize = true;
            this.StartWnmpWithWindows.Location = new System.Drawing.Point(18, 57);
            this.StartWnmpWithWindows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartWnmpWithWindows.Name = "StartWnmpWithWindows";
            this.StartWnmpWithWindows.Size = new System.Drawing.Size(15, 14);
            this.StartWnmpWithWindows.TabIndex = 4;
            this.StartWnmpWithWindows.UseVisualStyleBackColor = true;
            // 
            // startWnmpWithWindowsLabel
            // 
            this.startWnmpWithWindowsLabel.AutoSize = true;
            this.startWnmpWithWindowsLabel.Location = new System.Drawing.Point(37, 58);
            this.startWnmpWithWindowsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startWnmpWithWindowsLabel.Name = "startWnmpWithWindowsLabel";
            this.startWnmpWithWindowsLabel.Size = new System.Drawing.Size(148, 15);
            this.startWnmpWithWindowsLabel.TabIndex = 3;
            this.startWnmpWithWindowsLabel.Text = "Start Wnmp with Windows";
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(18, 218);
            this.autoUpdateCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.autoUpdateCheckBox.TabIndex = 11;
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // automaticallyCheckForUpdatesLabel
            // 
            this.automaticallyCheckForUpdatesLabel.AutoSize = true;
            this.automaticallyCheckForUpdatesLabel.Location = new System.Drawing.Point(37, 219);
            this.automaticallyCheckForUpdatesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.automaticallyCheckForUpdatesLabel.Name = "automaticallyCheckForUpdatesLabel";
            this.automaticallyCheckForUpdatesLabel.Size = new System.Drawing.Size(178, 15);
            this.automaticallyCheckForUpdatesLabel.TabIndex = 10;
            this.automaticallyCheckForUpdatesLabel.Text = "Automatically check for updates";
            // 
            // editorTB
            // 
            this.editorTB.Location = new System.Drawing.Point(63, 25);
            this.editorTB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editorTB.Name = "editorTB";
            this.editorTB.ReadOnly = true;
            this.editorTB.Size = new System.Drawing.Size(167, 23);
            this.editorTB.TabIndex = 1;
            // 
            // MinimizeWnmpToTray
            // 
            this.MinimizeWnmpToTray.AutoSize = true;
            this.MinimizeWnmpToTray.Location = new System.Drawing.Point(18, 149);
            this.MinimizeWnmpToTray.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeWnmpToTray.Name = "MinimizeWnmpToTray";
            this.MinimizeWnmpToTray.Size = new System.Drawing.Size(15, 14);
            this.MinimizeWnmpToTray.TabIndex = 9;
            this.MinimizeWnmpToTray.UseVisualStyleBackColor = true;
            // 
            // minimizeToTrayLabel
            // 
            this.minimizeToTrayLabel.AutoSize = true;
            this.minimizeToTrayLabel.Location = new System.Drawing.Point(37, 150);
            this.minimizeToTrayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minimizeToTrayLabel.Name = "minimizeToTrayLabel";
            this.minimizeToTrayLabel.Size = new System.Drawing.Size(93, 15);
            this.minimizeToTrayLabel.TabIndex = 8;
            this.minimizeToTrayLabel.Text = "Minimize to tray";
            // 
            // Nginx
            // 
            this.Nginx.Controls.Add(this.groupBox1);
            this.Nginx.Location = new System.Drawing.Point(4, 24);
            this.Nginx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Nginx.Name = "Nginx";
            this.Nginx.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Nginx.Size = new System.Drawing.Size(397, 350);
            this.Nginx.TabIndex = 2;
            this.Nginx.Text = "Nginx";
            this.Nginx.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nginxBin);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(382, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nginx Settings";
            // 
            // nginxBin
            // 
            this.nginxBin.FormattingEnabled = true;
            this.nginxBin.Location = new System.Drawing.Point(108, 28);
            this.nginxBin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nginxBin.Name = "nginxBin";
            this.nginxBin.Size = new System.Drawing.Size(80, 23);
            this.nginxBin.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 31);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Nginx Version:";
            // 
            // MariaDB
            // 
            this.MariaDB.Controls.Add(this.groupBox4);
            this.MariaDB.Location = new System.Drawing.Point(4, 24);
            this.MariaDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MariaDB.Name = "MariaDB";
            this.MariaDB.Size = new System.Drawing.Size(397, 350);
            this.MariaDB.TabIndex = 3;
            this.MariaDB.Text = "MariaDB";
            this.MariaDB.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mariadbBin);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(382, 69);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MariaDB Settings";
            // 
            // mariadbBin
            // 
            this.mariadbBin.FormattingEnabled = true;
            this.mariadbBin.Location = new System.Drawing.Point(125, 28);
            this.mariadbBin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mariadbBin.Name = "mariadbBin";
            this.mariadbBin.Size = new System.Drawing.Size(80, 23);
            this.mariadbBin.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 31);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "MariaDB Version:";
            // 
            // PHP
            // 
            this.PHP.Controls.Add(this.groupBox3);
            this.PHP.Controls.Add(this.groupBox2);
            this.PHP.Location = new System.Drawing.Point(4, 24);
            this.PHP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PHP.Name = "PHP";
            this.PHP.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PHP.Size = new System.Drawing.Size(397, 350);
            this.PHP.TabIndex = 1;
            this.PHP.Text = "PHP";
            this.PHP.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.phpExtListBox);
            this.groupBox3.Location = new System.Drawing.Point(7, 141);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(380, 201);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PHP Extensions";
            // 
            // phpExtListBox
            // 
            this.phpExtListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phpExtListBox.FormattingEnabled = true;
            this.phpExtListBox.Location = new System.Drawing.Point(4, 19);
            this.phpExtListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.phpExtListBox.Name = "phpExtListBox";
            this.phpExtListBox.Size = new System.Drawing.Size(372, 179);
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
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(382, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PHP Settings";
            // 
            // phpBin
            // 
            this.phpBin.FormattingEnabled = true;
            this.phpBin.Location = new System.Drawing.Point(126, 90);
            this.phpBin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.phpBin.Name = "phpBin";
            this.phpBin.Size = new System.Drawing.Size(80, 23);
            this.phpBin.TabIndex = 5;
            this.phpBin.SelectedIndexChanged += new System.EventHandler(this.PhpBin_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "PHP Version:";
            // 
            // PHP_PROCESSES
            // 
            this.PHP_PROCESSES.Location = new System.Drawing.Point(126, 29);
            this.PHP_PROCESSES.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.PHP_PROCESSES.Size = new System.Drawing.Size(80, 23);
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
            this.label8.Location = new System.Drawing.Point(21, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "PHP Processes:";
            // 
            // PHP_PORT
            // 
            this.PHP_PORT.Location = new System.Drawing.Point(126, 58);
            this.PHP_PORT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PHP_PORT.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PHP_PORT.Name = "PHP_PORT";
            this.PHP_PORT.Size = new System.Drawing.Size(80, 23);
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
            this.label7.Location = new System.Drawing.Point(21, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "PHP Port:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(214, 399);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(88, 27);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // OptionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 440);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.optionsTabControl);
            this.Controls.Add(this.Save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsFrm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.optionsTabControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.applicationSettingsGroupBox.ResumeLayout(false);
            this.applicationSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateCheckIntervalNumericUpDown)).EndInit();
            this.Nginx.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MariaDB.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PHP.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PROCESSES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHP_PORT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.GroupBox applicationSettingsGroupBox;
        private System.Windows.Forms.CheckBox StartMinimizedToTray;
        private System.Windows.Forms.Label startWnmpMinimizedLabel;
        private System.Windows.Forms.CheckBox MinimizeToTrayInsteadOfClosing;
        private System.Windows.Forms.Label minimizeToTrayICLabel;
        private System.Windows.Forms.CheckBox StartNginxLaunchCB;
        private System.Windows.Forms.Label startNginxOnLaunchLabel;
        private System.Windows.Forms.CheckBox StartMySQLLaunchCB;
        private System.Windows.Forms.Label startMariaDBOnLaunchLabel;
        private System.Windows.Forms.Button selecteditor;
        private System.Windows.Forms.NumericUpDown updateCheckIntervalNumericUpDown;
        private System.Windows.Forms.Label updateCheckIntervalLabel;
        private System.Windows.Forms.CheckBox StartPHPLaunchCB;
        private System.Windows.Forms.Label startPHPOnLaunchLabel;
        private System.Windows.Forms.CheckBox StartWnmpWithWindows;
        private System.Windows.Forms.Label startWnmpWithWindowsLabel;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.Label automaticallyCheckForUpdatesLabel;
        private System.Windows.Forms.TextBox editorTB;
        private System.Windows.Forms.CheckBox MinimizeWnmpToTray;
        private System.Windows.Forms.Label minimizeToTrayLabel;
        private System.Windows.Forms.TabPage PHP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox phpExtListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox phpBin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown PHP_PROCESSES;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown PHP_PORT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TabPage Nginx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox nginxBin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage MariaDB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox mariadbBin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label editorLabel;
    }
}