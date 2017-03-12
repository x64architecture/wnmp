/*
 * Copyright (c) 2012 - 2017, Kurt Cancemi (kurt@x64architecture.com)
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
        private PHPConfigurationManager PHPConfigurationMgr = new PHPConfigurationManager();

        public OptionsFrm(MainFrm form)
        {
            mainForm = form;
            InitializeComponent();
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
            phpBin.Items.Add("Default");
            foreach (var str in PhpVersions()) {
                phpBin.Items.Add(str);
            }
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
            StartWithWindows();
            UpdateNgxPHPConfig();
            Properties.Settings.Default.PHPVersion = phpBin.Text;
            Save_PHPExtOptions();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            Properties.Settings.Default.Save();
            /* Setup custom PHP without restart */
            if (Properties.Settings.Default.PHPVersion == "Default") {
                mainForm.SetupPHP();
            } else {
                mainForm.SetupCustomPHP();
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* Editor releated functions */

        private void SetEditor()
        {
            var input = "";
            var dialog = new OpenFileDialog {
                Filter = "executable files (*.exe)|*.exe|All files (*.*)|*.*",
                Title = "Select a text editor"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;

            editorTB.Text = dialog.FileName;
            Editor = dialog.FileName;

            if (input == "")
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

        private string[] PhpVersions()
        {
            if (Directory.Exists(Program.StartupPath + "/php/phpbins") == false)
                return new string[0];
            return Directory.GetDirectories(Program.StartupPath + "/php/phpbins").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private void UpdateNgxPHPConfig()
        {
            short port = (short)PHP_PORT.Value;
            uint PHPProcesses = (uint)PHP_PROCESSES.Value;

            using (var sw = new StreamWriter(Program.StartupPath + "/conf/php_processes.conf")) {
                sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNMP CONTROL PANEL.\r\n");
                sw.WriteLine("upstream php_processes {");
                for (var i = 1; i <= PHPProcesses; i++) {
                    sw.WriteLine("    server 127.0.0.1:" + port + " weight=1;");
                    port++;
                }
                sw.WriteLine("}");
            }
        }


        private void StartWithWindows()
        {
            var root = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (root == null)
                return;
            if (StartWnmpWithWindows.Checked) {
                if (root.GetValue("Wnmp") == null)
                    root.SetValue("Wnmp", "\"" + Application.ExecutablePath + "\"");
            } else {
                if (root.GetValue("Wnmp") != null)
                    root.DeleteValue("Wnmp");
            }
        }

        /* PHP Extensions Manager */

        private void Save_PHPExtOptions()
        {
            for (var i = 0; i < phpExtListBox.Items.Count; i++) {
                PHPConfigurationMgr.UserPHPExtentionValues[i] = phpExtListBox.GetItemChecked(i);
            }
            PHPConfigurationMgr.SavePHPIniOptions();
        }

        private void PhpBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            phpExtListBox.Items.Clear();
            PHPConfigurationMgr.LoadPHPExtensions(phpBin.Text);

            for (var i = 0; i < PHPConfigurationMgr.phpExtName.Length; i++) {
                phpExtListBox.Items.Add(PHPConfigurationMgr.phpExtName[i],
                    PHPConfigurationMgr.PHPExtensions[i].HasFlag(PHPConfigurationManager.PHPExtension.Enabled));
            }
        }
    }
}