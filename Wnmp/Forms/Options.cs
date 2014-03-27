/*
Copyright (c) Kurt Cancemi 2012-2014

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
using System.Windows.Forms;
using Microsoft.Win32;
using Wnmp.Configuration;
using Wnmp.Helpers;
using Wnmp.Internals;

namespace Wnmp.Forms
{
    /// <summary>
    ///     Form that allows configuring Wnmp options.
    /// </summary>
    public partial class Options : Form
    {
        public static Ini settings = new Ini();

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

        private void selecteditor_Click(object sender, EventArgs e)
        {
            String input = string.Empty;
            var dialog = new OpenFileDialog();
            dialog.Filter =
                "excutable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title = "Select an editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;
            editorTB.Text = dialog.FileName;
            settings.Editor = dialog.FileName;

            if (input == String.Empty)
                settings.Editor = "notepad.exe";
            editorTB.Text = settings.Editor;
        }

        private void StartWnmpWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (StartWnmpWithWindows.Checked)
                {
                    RegistryKey add =
                        Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Wnmp", "\"" + Application.ExecutablePath + "\"");
                    settings.Startupwithwindows = true;
                }
                else
                {
                    RegistryKey remove =
                        Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Wnmp");
                    settings.Startupwithwindows = false;
                }
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This option may require administator privileges. \n If it doesn't work or throws an error right click Wnmp.exe and click run as administator.");
        }

        private void StartAllProgramsOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            settings.Startallapplicationsatlaunch = StartAllProgramsOnLaunch.Checked;
        }

        private void MinimizeWnmpToTray_CheckedChanged(object sender, EventArgs e)
        {
            settings.Minimizewnmptotray = MinimizeWnmpToTray.Checked;
        }

        private void AutoUpdateFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AutoUpdateFrequency.SelectedIndex)
            {
                case 0:
                    settings.Checkforupdatefrequency = 1;
                    break;
                case 1:
                    settings.Checkforupdatefrequency = 7;
                    break;
                case 2:
                    settings.Checkforupdatefrequency = 30;
                    break;
                default:
                    settings.Checkforupdatefrequency = 7;
                    break;
            }
        }

        private void AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            switch (AutoUpdate.Checked)
            {
                case true:
                    settings.Autocheckforupdates = true;
                    break;
                case false:
                    settings.Autocheckforupdates = false;
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            settings.UpdateSettings();
            Close();
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        #region UpdateOptions

        /// <summary>
        ///     Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            switch (settings.Editor)
            {
                case "":
                    editorTB.Text = "notepad.exe";
                    break;
                default:
                    editorTB.Text = settings.Editor;
                    break;
            }
            switch (settings.Startupwithwindows)
            {
                case false:
                    StartWnmpWithWindows.Checked = false;
                    break;
                case true:
                    StartWnmpWithWindows.Checked = true;
                    break;
            }
            switch (settings.Startallapplicationsatlaunch)
            {
                case false:
                    StartAllProgramsOnLaunch.Checked = false;
                    break;
                case true:
                    StartAllProgramsOnLaunch.Checked = true;
                    break;
            }
            switch (settings.Minimizewnmptotray)
            {
                case true:
                    MinimizeWnmpToTray.Checked = true;
                    break;
                case false:
                    MinimizeWnmpToTray.Checked = false;
                    break;
            }
            switch (settings.Autocheckforupdates)
            {
                case true:
                    AutoUpdate.Checked = true;
                    break;
                case false:
                    AutoUpdate.Checked = false;
                    break;
            }
            switch (settings.Checkforupdatefrequency)
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
            if (settings.Lastcheckforupdate != DateTime.MinValue)
                lastcheckforupdateTB.Text = settings.Lastcheckforupdate.ToString();
            else
                lastcheckforupdateTB.Text = "Never";
        }

        #endregion
    }
}