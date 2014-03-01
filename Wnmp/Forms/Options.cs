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
        public static Configuration.Ini settings = new Configuration.Ini();
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
            settings.ReadSettings();
            UpdateOptions();
        }

        #region UpdateOptions
        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            switch (settings.editor)
            {
                case "":
                    editorTB.Text = "notepad.exe";
                    break;
                default:
                    editorTB.Text = settings.editor;
                    break;
            }
            switch (settings.startupwithwindows)
            {
                case false:
                    StartWnmpWithWindows.Checked = false;
                    break;
                case true:
                    StartWnmpWithWindows.Checked = true;
                    break;
            }
            switch (settings.startallapplicationsatlaunch)
            {
                case false:
                    StartAllProgramsOnLaunch.Checked = false;
                    break;
                case true:
                    StartAllProgramsOnLaunch.Checked = true;
                    break;
            }
            switch (settings.minimizewnmptotray)
            {
                case true:
                    MinimizeWnmpToTray.Checked = true;
                    break;
                case false:
                    MinimizeWnmpToTray.Checked = false;
                    break;
            }
            switch (settings.autocheckforupdates)
            {
                case true:
                    AutoUpdate.Checked = true;
                    break;
                case false:
                    AutoUpdate.Checked = false;
                    break;
            }
            switch (settings.checkforupdatefrequency)
            {
                case 1:
                    AutoUpdateFrequency.SelectedIndex = 0;
                    break;
                case 7:
                    AutoUpdateFrequency.SelectedIndex = 1;
                    break;
                case 30:
                    AutoUpdateFrequency.SelectedIndex = 2;
                    break;
                default:
                    AutoUpdateFrequency.SelectedIndex = 1; /* Default: To check for updates every week. */
                    break;
            }
            if (settings.lastcheckforupdate == DateTime.MinValue)
                lastcheckforupdateTB.Text = "Never";
            else
                lastcheckforupdateTB.Text = settings.lastcheckforupdate.ToString();
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
            settings.editor = dialog.FileName;
            
            if (input == String.Empty)
            settings.editor = "notepad.exe";
            editorTB.Text = settings.editor;
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
                    settings.startupwithwindows = true;
                }
                else
                {
                    RegistryKey remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Wnmp");
                    settings.startupwithwindows = false;
                }
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option may require administator privileges. \n If it doesn't work or throws an error right click Wnmp.exe and click run as administator.");
        }

        private void StartAllProgramsOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (StartAllProgramsOnLaunch.Checked == true)
            {
                settings.startallapplicationsatlaunch = true;
            }
            else
            {
                settings.startallapplicationsatlaunch = false;
            }
        }

        private void MinimizeWnmpToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (MinimizeWnmpToTray.Checked == true)
            {
                settings.minimizewnmptotray = true;
            }
            else
            {
                settings.minimizewnmptotray = false;
            }
        }

        private void AutoUpdateFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AutoUpdateFrequency.SelectedIndex)
            {
                case 0:
                    settings.checkforupdatefrequency = 1;
                    break;
                case 1:
                    settings.checkforupdatefrequency = 7;
                    break;
                case 2:
                    settings.checkforupdatefrequency = 30;
                    break;
                default:
                    settings.checkforupdatefrequency = 7;
                    break;
            }
        }

        private void AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            switch (AutoUpdate.Checked)
            {
                case true:
                    settings.autocheckforupdates = true;
                    break;
                case false:
                    settings.autocheckforupdates = false;
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            settings.UpdateSettings();
            this.Close();
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
