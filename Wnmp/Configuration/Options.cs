/*
 * Copyright (c) 2012 - 2015, Kurt Cancemi (kurt@x64architecture.com)
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

namespace Wnmp.Forms
{
    /// <summary>
    ///     Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public static Ini settings = new Ini();
        private string Editor;

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

        private void SetEditor()
        {
            string input = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "executable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title  = "Select a text editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;

            editorTB.Text = dialog.FileName;
            Editor = dialog.FileName;

            if (input == "")
                Editor = "notepad.exe";
            editorTB.Text = Editor;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            settings.ReadSettings();
            UpdateOptions();
        }

        private void selecteditor_Click(object sender, EventArgs e)
        {
            SetEditor();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            settings.UpdateSettings();
            this.Close();
        }

        private void SetSettings()
        {
            settings.Editor = Editor;
            settings.StartWithWindows = StartWnmpWithWindows.Checked;
            settings.RunAppsAtLaunch = StartAllProgramsOnLaunch.Checked;
            settings.MinimizeWnmpToTray = MinimizeWnmpToTray.Checked;
            settings.AutoCheckForUpdates = AutoUpdate.Checked;
            settings.PHP_Processes = (int)PHP_PROCESSES.Value;
            settings.PHP_Port = (short)PHP_PORT.Value;
            settings.UpdateFrequency = (int)UpdateCheckInterval.Value;
            UpdatePHPngxCfg();
        }

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            editorTB.Text = settings.Editor;
            StartWnmpWithWindows.Checked = settings.StartWithWindows;
            StartAllProgramsOnLaunch.Checked = settings.RunAppsAtLaunch;
            MinimizeWnmpToTray.Checked = settings.MinimizeWnmpToTray;
            AutoUpdate.Checked = settings.AutoCheckForUpdates;
            UpdateCheckInterval.Value = settings.UpdateFrequency;
            PHP_PROCESSES.Value = settings.PHP_Processes;
            PHP_PORT.Value = settings.PHP_Port;
        }

        private void StartWithWindows()
        {
            RegistryKey root;
            const string key = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            if (StartWnmpWithWindows.Checked) {
                root = Registry.CurrentUser.OpenSubKey(key, true);
                if (root.GetValue("Wnmp") == null)
                    root.SetValue("Wnmp", "\"" + Application.ExecutablePath + "\"");
            } else {
                root = Registry.CurrentUser.OpenSubKey(key, true);
                if (root.GetValue("Wnmp") != null)
                    root.DeleteValue("Wnmp");
            }
        }

        private void UpdatePHPngxCfg()
        {
            int i;
            int port = (int)PHP_PORT.Value;
            int PHPProcesses = (int)PHP_PROCESSES.Value;

            using (var sw = new StreamWriter(Main.StartupPath + "/conf/php_processes.conf")) {
                sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNMP CONTROL PANEL.\r\n");
                sw.WriteLine("upstream php_processes {");
                for (i = 1; i <= PHPProcesses; i++) {
                    sw.WriteLine("    server 127.0.0.1:" + port + " weight=1;");
                    port++;
                }
                sw.WriteLine("}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorTB_DoubleClick(object sender, EventArgs e)
        {
            SetEditor();
        }
    }
}