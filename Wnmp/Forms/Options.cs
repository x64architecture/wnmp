/*
Copyright (C) Kurt Cancemi

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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Wnmp.Properties;

using Wnmp.Helpers;
using Wnmp.Internals;

namespace Wnmp
{
    /// <summary>
    /// Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Declarations.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        #region UpdateOptions
        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            switch (Settings.Default.editor)
            {
                case "":
                    editorTB.Text = "notepad.exe";
                    break;
                default:
                    editorTB.Text = Settings.Default.editor;
                    break;
            }
            switch (Settings.Default.startupwithwindows)
            {
                case false:
                    StartWnmpWithWindows.Checked = false;
                    break;
                case true:
                    StartWnmpWithWindows.Checked = true;
                    break;
            }
            switch (Settings.Default.startallappsatlaunch)
            {
                case false:
                    StartAllProgramsOnLaunch.Checked = false;
                    break;
                case true:
                    StartAllProgramsOnLaunch.Checked = true;
                    break;
            }
            switch (Settings.Default.minimizewnmptotray)
            {
                case true:
                    MinimizeWnmpToTray.Checked = true;
                    break;
                case false:
                    MinimizeWnmpToTray.Checked = false;
                    break;
            }
            switch (Settings.Default.autocheckforupdates)
            {
                case true:
                    AutoUpdate.Checked = true;
                    break;
                case false:
                    AutoUpdate.Checked = false;
                    break;
            }
            switch (Settings.Default.checkforupdatefrequency)
            {
                case "day":
                    AutoUpdateFrequency.SelectedIndex = 0;
                    break;
                case "week":
                    AutoUpdateFrequency.SelectedIndex = 1;
                    break;
                case "month":
                    AutoUpdateFrequency.SelectedIndex = 2;
                    break;
                default:
                    AutoUpdateFrequency.SelectedIndex = 1; /* Default: To check for updates every week. */
                    break;
            }
        }
        #endregion
        private void selecteditor_Click(object sender, EventArgs e)
        {
             String input = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "excutable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title = "Select an editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;
            editorTB.Text = dialog.FileName;
            Settings.Default.editor = dialog.FileName;
            
            if (input == String.Empty)
            Settings.Default.editor = "notepad.exe";
            editorTB.Text = Settings.Default.editor;
                return;
        }

        private void StartWnmpWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (StartWnmpWithWindows.Checked == true)
                {
                    RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Wnmp", "\"" + Application.ExecutablePath.ToString() + "\"");
                    Settings.Default.startupwithwindows = true;
                }
                else
                {
                    RegistryKey remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Wnmp");
                    Settings.Default.startupwithwindows = false;
                }
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option may require administator privileges. \n If it dosent work or throws an error right click Wnmp.exe and click run as administator.");
        }

        private void StartAllProgramsOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (StartAllProgramsOnLaunch.Checked == true)
            {
                Settings.Default.startallappsatlaunch = true;
            }
            else
            {
                Settings.Default.startallappsatlaunch = false;
            }
        }

        private void MinimizeWnmpToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (MinimizeWnmpToTray.Checked == true)
            {
                Settings.Default.minimizewnmptotray = true;
            }
            else
            {
                Settings.Default.minimizewnmptotray = false;
            }
        }

        private void AutoUpdateFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (AutoUpdateFrequency.SelectedIndex)
            {
                case 0:
                    Settings.Default.checkforupdatefrequency = "day";
                    break;
                case 1:
                    Settings.Default.checkforupdatefrequency = "week";
                    break;
                case 2:
                    Settings.Default.checkforupdatefrequency = "month";
                    break;
                default:
                    Settings.Default.checkforupdatefrequency = "day";
                    break;
            }
        }

        private void AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            switch (AutoUpdate.Checked)
            {
                case true:
                    Settings.Default.autocheckforupdates = true;
                    break;
                case false:
                    Settings.Default.autocheckforupdates = false;
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            this.Close();
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Reload();
        }
    }
}
