/*
 * Copyright (c) 2012 - 2021, Kurt Cancemi (kurt@x64architecture.com)
 *
 * This file is part of Wnmp.
 *
 *  Wnmp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Wnmp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;
using Wnmp.Configuration;

namespace Wnmp.UI
{
    /// <summary>
    /// Form that allows configuring Wnmp options.
    /// </summary>
    public partial class OptionsFrm : Form
    {
        public MainFrm mainForm;
        private string Editor;
        private readonly PHPConfigurationManager PHPConfigurationMgr = new();

        private void SetLanguage()
        {
            Text = Language.Resource.OPTIONS;
            optionsTabControl.TabPages[0].Text = Language.Resource.GENERAL;
            applicationSettingsGroupBox.Text = Language.Resource.APPLICATION_SETTINGS;
            editorLabel.Text = Language.Resource.EDITOR;
            startWnmpWithWindowsLabel.Text = Language.Resource.START_WNMP_WITH_WINDOWS;
            startNginxOnLaunchLabel.Text = Language.Resource.START_NGINX_ON_LAUNCH;
            startMariaDBOnLaunchLabel.Text = Language.Resource.START_MARIADB_ON_LAUNCH;
            startPHPOnLaunchLabel.Text = Language.Resource.START_PHP_ON_LAUNCH;
            minimizeToTrayLabel.Text = Language.Resource.MINIMIZE_TO_TRAY;
            minimizeToTrayICLabel.Text = Language.Resource.MINIMIZE_TO_TRAY_INSTEAD_OF_CLOSING;
            startWnmpMinimizedLabel.Text = Language.Resource.START_WNMP_MINIMIZED;
            automaticallyCheckForUpdatesLabel.Text = Language.Resource.AUTOMATICALLY_CHECK_FOR_UPDATES;
            updateCheckIntervalLabel.Text = Language.Resource.UPDATE_CHECK_INTERVAL_IN_DAYS;
        }

        public OptionsFrm(MainFrm form)
        {
            mainForm = form;
            InitializeComponent();
            SetLanguage();
        }

        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00040000; // Remove WS_THICKFRAME (Disables resizing)
                return cp;
            }
        }

        /* Options releated functions */

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            editorTB.Text = Properties.Settings.Default.TextEditor;
            StartWnmpWithWindows.Checked = Properties.Settings.Default.StartWithWindows;
            StartNginxLaunchCB.Checked = Properties.Settings.Default.StartNginxOnLaunch;
            StartMySQLLaunchCB.Checked = Properties.Settings.Default.StartMariaDBOnLaunch;
            StartPHPLaunchCB.Checked = Properties.Settings.Default.StartPHPOnLaunch;
            StartMinimizedToTray.Checked = Properties.Settings.Default.StartMinimizedToTray;
            MinimizeWnmpToTray.Checked = Properties.Settings.Default.MinimizeToTray;
            autoUpdateCheckBox.Checked = Properties.Settings.Default.AutoCheckForUpdates;
            updateCheckIntervalNumericUpDown.Value = Properties.Settings.Default.UpdateFrequency;
            PHP_PROCESSES.Value = Properties.Settings.Default.PHPProcessCount;
            PHP_PORT.Value = Properties.Settings.Default.PHPPort;
            MinimizeToTrayInsteadOfClosing.Checked = Properties.Settings.Default.MinimizeInsteadOfClosing;
            foreach (var str in GetNginxVersions())
            {
                nginxBin.Items.Add(str);
            }
            foreach (var str in GetMariaDBVersions())
            {
                mariadbBin.Items.Add(str);
            }
            foreach (var str in GetPHPVersions()) {
                phpBin.Items.Add(str);
            }
            nginxBin.SelectedIndex = nginxBin.Items.IndexOf(Properties.Settings.Default.NginxVersion);
            mariadbBin.SelectedIndex = mariadbBin.Items.IndexOf(Properties.Settings.Default.MariaDBVersion);
            phpBin.SelectedIndex = phpBin.Items.IndexOf(Properties.Settings.Default.PHPVersion);
        }

        private void Options_Load(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        private void SetSettings()
        {
            Properties.Settings.Default.TextEditor = editorTB.Text;
            Properties.Settings.Default.StartWithWindows = StartWnmpWithWindows.Checked;
            Properties.Settings.Default.StartNginxOnLaunch = StartNginxLaunchCB.Checked;
            Properties.Settings.Default.StartMariaDBOnLaunch = StartMySQLLaunchCB.Checked;
            Properties.Settings.Default.StartPHPOnLaunch = StartPHPLaunchCB.Checked;
            Properties.Settings.Default.StartMinimizedToTray = StartMinimizedToTray.Checked;
            Properties.Settings.Default.MinimizeToTray = MinimizeWnmpToTray.Checked;
            Properties.Settings.Default.MinimizeInsteadOfClosing = MinimizeToTrayInsteadOfClosing.Checked;
            Properties.Settings.Default.AutoCheckForUpdates = autoUpdateCheckBox.Checked;
            Properties.Settings.Default.PHPProcessCount = (uint)PHP_PROCESSES.Value;
            Properties.Settings.Default.PHPPort = (ushort)PHP_PORT.Value;
            Properties.Settings.Default.UpdateFrequency = (uint)updateCheckIntervalNumericUpDown.Value;
            try
            {
                StartWithWindows();
                UpdateNgxPHPConfig();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            if (Properties.Settings.Default.NginxVersion != nginxBin.Text)
            {
                Properties.Settings.Default.NginxVersion = nginxBin.Text;
                mainForm.SetupNginx(true);
            }
            if (Properties.Settings.Default.MariaDBVersion != mariadbBin.Text)
            {
                Properties.Settings.Default.MariaDBVersion = mariadbBin.Text;
                mainForm.SetupMariaDB(true);
            }
            if (Properties.Settings.Default.PHPVersion != phpBin.Text)
            {
                Properties.Settings.Default.PHPVersion = phpBin.Text;
                mainForm.SetupPHP(true);
            }
            Save_PHPExtOptions();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            Properties.Settings.Default.Save();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* Editor releated functions */

        private void SetEditor()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",
                Title = Language.Resource.SELECT_A_TEXT_EDITOR,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Editor = dialog.FileName;
            }

            if (string.IsNullOrEmpty(Editor))
                Editor = "notepad.exe";
            editorTB.Text = Editor;
        }

        private void Selecteditor_Click(object sender, EventArgs e)
        {
            SetEditor();
        }

        private void EditorTB_DoubleClick(object sender, EventArgs e)
        {
            SetEditor();
        }

        private static string[] GetNginxVersions()
        {
            if (Directory.Exists($"{Program.StartupPath}\\nginx-bins") == false)
                return Array.Empty<string>();
            return Directory.GetDirectories(Program.StartupPath + "\\nginx-bins").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private static string[] GetMariaDBVersions()
        {
            if (Directory.Exists($"{Program.StartupPath}\\mariadb-bins") == false)
                return Array.Empty<string>();
            return Directory.GetDirectories(Program.StartupPath + "\\mariadb-bins").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private static string[] GetPHPVersions()
        {
            if (Directory.Exists($"{Program.StartupPath}\\php-bins") == false)
                return Array.Empty<string>();
            return Directory.GetDirectories(Program.StartupPath + "\\php-bins").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private void UpdateNgxPHPConfig()
        {
            ushort port = (ushort)PHP_PORT.Value;

            using var sw = new StreamWriter($"{mainForm.Nginx.WorkingDir}\\conf\\php_processes.conf");
            sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNMP CONTROL PANEL.\r\n");
            sw.WriteLine("upstream php_processes {");
            sw.WriteLine($"    server 127.0.0.1:{port} weight=1;");
            sw.WriteLine("}");
        }


        private void StartWithWindows()
        {
            var root = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (root == null)
                return;
            if (StartWnmpWithWindows.Checked) {
                if (root.GetValue("Wnmp") == null)
                    root.SetValue("Wnmp", $"\"{Application.ExecutablePath}\"");
            } else {
                if (root.GetValue("Wnmp") != null)
                    root.DeleteValue("Wnmp");
            }
        }

        /* PHP Extensions Manager */

        private void Save_PHPExtOptions()
        {
            for (var i = 0; i < phpExtListBox.Items.Count; i++) {
                PHPConfigurationMgr.PHPExtensions[i].Enabled = phpExtListBox.GetItemChecked(i);
            }
            PHPConfigurationMgr.SavePHPIniOptions();
        }

        private void PhpBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            phpExtListBox.Items.Clear();
            PHPConfigurationMgr.LoadPHPExtensions(phpBin.Text);

            foreach (var ext in PHPConfigurationMgr.PHPExtensions)
                phpExtListBox.Items.Add(ext.Name, ext.Enabled);
        }
    }
}