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
using System.Linq;

namespace Wnmp.Forms
{
    /// <summary>
    /// Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public static Ini settings = new Ini();
        public static Main mainForm;
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

        /* Options releated functions */

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
            phpBin.Items.Add("Default");
            foreach (string str in phpVersions()) {
                phpBin.Items.Add(str);
            }
            phpBin.SelectedIndex = phpBin.Items.IndexOf(settings.phpBin);
        }

        private void Options_Load(object sender, EventArgs e)
        {
            settings.ReadSettings();
            UpdateOptions();
        }

        private void SetSettings()
        {
            settings.Editor = EditorTB.Text;
            settings.StartWithWindows = StartWnmpWithWindows.Checked;
            settings.RunAppsAtLaunch = StartAllProgramsOnLaunch.Checked;
            settings.MinimizeWnmpToTray = MinimizeWnmpToTray.Checked;
            settings.AutoCheckForUpdates = AutoUpdate.Checked;
            settings.PHP_Processes = (int)PHP_PROCESSES.Value;
            settings.PHP_Port = (short)PHP_PORT.Value;
            settings.UpdateFrequency = (int)UpdateCheckInterval.Value;
            StartWithWindows();
            UpdateNgxPHPConfig();
            settings.phpBin = phpBin.Text;
            save_phpextensionopts();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SetSettings();
            settings.UpdateSettings();
            /* Setup custom PHP without restart */
            if (settings.phpBin == "Default") {
                mainForm.SetupPHP();
            }
            else {
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

        /* PHP Extensions Manager */

        private string[] phpExtName;
        private bool[] phpExtEnabled;
        private int opcacheIndex;
        private string extPath, iniFile;

        private void parse_phpini(int i)
        {
            string str;
            StreamReader sr = new StreamReader(iniFile);
            while ((str = sr.ReadLine()) != null) {
                if (str.StartsWith(";extension=" + phpExtName[i])) {
                    phpExtEnabled[i] = false;
                    continue;
                }
                if (str.StartsWith("extension=" + phpExtName[i])) {
                    phpExtEnabled[i] = true;
                    continue;
                }
                if (str.StartsWith(";zend_extension=" + phpExtName[i])) {
                    phpExtEnabled[i] = false;
                    opcacheIndex = i;
                    continue;
                }
                if (str.StartsWith("zend_extension=" + phpExtName[i])) {
                    phpExtEnabled[i] = true;
                    opcacheIndex = i;
                    continue;
                }
            }
            sr.Close();
        }
        private void set_phpiniopt(int i, bool enable)
        {
            string text = File.ReadAllText(iniFile);
            if (i != opcacheIndex) {
                if (enable)
                    text = text.Replace(";extension=" + phpExtName[i], "extension=" + phpExtName[i]);
                else {
                    if (phpExtEnabled[i] == true)
                        text = text.Replace("extension=" + phpExtName[i], ";extension=" + phpExtName[i]);
                }
            } else { // Special case zend_extension
                if (enable)
                    text = text.Replace(";zend_extension=" + phpExtName[i], "zend_extension=" + phpExtName[i]);
                else {
                    if (phpExtEnabled[i] == true)
                        text = text.Replace("zend_extension=" + phpExtName[i], ";zend_extension=" + phpExtName[i]);
                }
            }
            File.WriteAllText(iniFile, text);
        }

        private void load_phpextensions(string phpBin)
        {
            if (phpBin == "Default") {
                extPath = Main.StartupPath + "/php/ext/";
                iniFile = Main.StartupPath + "/php/php.ini";
            }
            else {
                extPath = Main.StartupPath + "/php/phpbins/" + phpBin + "/ext/";
                iniFile = Main.StartupPath + "/php/phpbins/" + phpBin + "/php.ini";
            }

            if (!Directory.Exists(extPath))
                return;
            phpExtName = Directory.GetFiles(extPath, "*.dll");
            phpExtEnabled = new bool[phpExtName.Length];

            for (int i = 0; i < phpExtName.Length; i++) {
                phpExtName[i] = phpExtName[i].Remove(0, extPath.Length);
                parse_phpini(i);
                phpExtListBox.Items.Add(phpExtName[i], phpExtEnabled[i]);
            }
        }

        private void save_phpextensionopts()
        {
            for (int i = 0; i < phpExtListBox.Items.Count; i++) {
                if (phpExtListBox.GetItemChecked(i))
                    set_phpiniopt(i, true);
                else
                    set_phpiniopt(i, false);
            }
        }

        private void phpBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            phpExtListBox.Items.Clear();
            load_phpextensions(phpBin.Text);
        }
    }
}