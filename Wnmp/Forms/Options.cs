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
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Common.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void SetEditor()
        {
            var input = String.Empty;
            var dialog = new OpenFileDialog();
            dialog.Filter =
                "executable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialog.Title = "Select a text editor";
            if (dialog.ShowDialog() == DialogResult.OK)
                input = dialog.FileName;

            editorTB.Text = dialog.FileName;
            settings.Editor = dialog.FileName;

            if (input == String.Empty)
                settings.Editor = "notepad.exe";
            editorTB.Text = settings.Editor;
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

        private void StartWnmpWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Should we use the registry or use the users Startup Folder?
            if (StartWnmpWithWindows.Checked) {
                var addReg =
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                addReg.SetValue("Wnmp", "\"" + Application.ExecutablePath + "\"");
                settings.Startupwithwindows = true;
            } else {
                var remove =
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                remove.DeleteValue("Wnmp");
                settings.Startupwithwindows = false;
            }
        }

        private void StartAllProgramsOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            settings.Startallapplicationsatlaunch = StartAllProgramsOnLaunch.Checked;
        }

        private void MinimizeWnmpToTray_CheckedChanged(object sender, EventArgs e)
        {
            settings.Minimizewnmptotray = MinimizeWnmpToTray.Checked;
        }

        private void AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoUpdate.Checked)
                settings.Autocheckforupdates = true;
            else
                settings.Autocheckforupdates = false;
        }

        private void PHP_PORT_ValueChanged(object sender, EventArgs e)
        {
            settings.PHPPort = (int)PHP_PORT.Value;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            settings.UpdateSettings();
            Close();
        }

        #region UpdateOptions

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void UpdateOptions()
        {
            editorTB.Text = settings.Editor;

            StartWnmpWithWindows.Checked = settings.Startupwithwindows;

            StartAllProgramsOnLaunch.Checked = settings.Startallapplicationsatlaunch;

            MinimizeWnmpToTray.Checked = settings.Minimizewnmptotray;

            AutoUpdate.Checked = settings.Autocheckforupdates;

            UpdateCheckInterval.Value = settings.Checkforupdatefrequency;

            PHP_PORT.Value = settings.PHPPort;
        }

        #endregion

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorTB_DoubleClick(object sender, EventArgs e)
        {
            SetEditor();
        }

        private void UpdateCheckInterval_ValueChanged(object sender, EventArgs e)
        {
            settings.Checkforupdatefrequency = (int)UpdateCheckInterval.Value;
        }
    }
}