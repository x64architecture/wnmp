/*
 * Copyright (c) 2012 - 2016, Kurt Cancemi (kurt@x64architecture.com)
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
using Microsoft.Win32;

using Wnmp.Configuration;
using System.Linq;

namespace Wnmp.UI
{
    /// <summary>
    /// Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public Main mainForm;
        public Ini Settings;
        private string Editor;
        private PHPConfigurationManager PHPConfigurationMgr = new PHPConfigurationManager();

        public Options()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Constants.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        /* Options releated functions */

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            editorTB.Text = Settings.Editor.Value;
            StartWnmpWithWindows.Checked = Settings.StartWithWindows.Value;
            StartNginxLaunchCB.Checked = Settings.StartNginxOnLaunch.Value;
            StartMySQLLaunchCB.Checked = Settings.StartMySQLOnLaunch.Value;
            StartPHPLaunchCB.Checked = Settings.StartPHPOnLaunch.Value;
            StartMinimizedToTray.Checked = Settings.StartMinimizedToTray.Value;
            MinimizeWnmpToTray.Checked = Settings.MinimizeWnmpToTray.Value;
            AutoUpdate.Checked = Settings.AutoCheckForUpdates.Value;
            UpdateCheckInterval.Value = Settings.UpdateFrequency.Value;
            PHP_PROCESSES.Value = Settings.PHP_Processes.Value;
            PHP_PORT.Value = Settings.PHP_Port.Value;
            MinimizeToTrayInsteadOfClosing.Checked = Settings.MinimizeInsteadOfClosing.Value;
            phpBin.Items.Add("Default");
            foreach (var str in phpVersions()) {
                phpBin.Items.Add(str);
            }
            phpBin.SelectedIndex = phpBin.Items.IndexOf(Settings.phpBin.Value);
        }

        private void Options_Load(object sender, EventArgs e)
        {
            Settings.ReadSettings();
            UpdateOptions();
        }

        private void SetSettings()
        {
            Settings.Editor.Value = editorTB.Text;
            Settings.StartWithWindows.Value = StartWnmpWithWindows.Checked;
            Settings.StartNginxOnLaunch.Value = StartNginxLaunchCB.Checked;
            Settings.StartMySQLOnLaunch.Value = StartMySQLLaunchCB.Checked;
            Settings.StartPHPOnLaunch.Value = StartPHPLaunchCB.Checked;
            Settings.StartMinimizedToTray.Value = StartMinimizedToTray.Checked;
            Settings.MinimizeWnmpToTray.Value = MinimizeWnmpToTray.Checked;
            Settings.MinimizeInsteadOfClosing.Value = MinimizeToTrayInsteadOfClosing.Checked;
            Settings.AutoCheckForUpdates.Value = AutoUpdate.Checked;
            Settings.PHP_Processes.Value = (uint)PHP_PROCESSES.Value;
            Settings.PHP_Port.Value = (short)PHP_PORT.Value;
            Settings.UpdateFrequency.Value = (uint)UpdateCheckInterval.Value;
            StartWithWindows();
            UpdateNgxPHPConfig();
            Settings.phpBin.Value = phpBin.Text;
            Save_PHPExtOptions();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            Settings.UpdateSettings();
            /* Setup custom PHP without restart */
            if (Settings.phpBin.Value == "Default") {
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

        private void selecteditor_Click(object sender, EventArgs e)
        {
            SetEditor();
        }

        private void editorTB_DoubleClick(object sender, EventArgs e)
        {
            SetEditor();
        }

        private string[] phpVersions()
        {
            if (Directory.Exists(Main.StartupPath + "/php/phpbins") == false)
                return new string[0];
            return Directory.GetDirectories(Main.StartupPath + "/php/phpbins").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private void UpdateNgxPHPConfig()
        {
            short port = (short)PHP_PORT.Value;
            uint PHPProcesses = (uint)PHP_PROCESSES.Value;

            using (var sw = new StreamWriter(Main.StartupPath + "/conf/php_processes.conf")) {
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

        private void phpBin_SelectedIndexChanged(object sender, EventArgs e)
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