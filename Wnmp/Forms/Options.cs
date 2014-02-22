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
        private void UpdateOptions()
        {
            switch (Settings.Default.startaprgssu)
            {
                case false:
                    suap.Checked = false;
                    break;
                case true:
                    suap.Checked = true;
                    break;
            }
            switch (Settings.Default.startwnmpsu)
            {
                case false:
                    suwnmpcb.Checked = false;
                    break;
                case true:
                    suwnmpcb.Checked = true;
                    break;
            }
            switch (Settings.Default.editor)
            {
                case "":
                    editorTB.Text = "notepad.exe";
                    break;
                default:
                    editorTB.Text = Settings.Default.editor;
                    break;
            }
            switch (Settings.Default.autocheckforupdates)
            {
                case true:
                    autoupdate.Checked = true;
                    break;
                case false:
                    autoupdate.Checked = false;
                    break;
            }
            switch (Settings.Default.cfuevery)
            {
                case "day":
                    autoupdateopt.SelectedIndex = 0;
                    break;
                case "week":
                    autoupdateopt.SelectedIndex = 1;
                    break;
                case "month":
                    autoupdateopt.SelectedIndex = 2;
                    break;
                default:
                    autoupdateopt.SelectedIndex = 1; /* Default: To check for updates every week. */
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

        private void suwnmpcb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (suwnmpcb.Checked == true)
                {
                    RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Wnmp", "\"" + Application.ExecutablePath.ToString() + "\"");
                    Settings.Default.startwnmpsu = true;
                }
                else
                {
                    RegistryKey remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Wnmp");
                    Settings.Default.startwnmpsu = false;
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

        private void suap_CheckedChanged(object sender, EventArgs e)
        {
            if (suap.Checked == true)
            {
                Settings.Default.startaprgssu = true;
            }
            else
            {
                Settings.Default.startaprgssu = false;
            }
        }

        private void mwttb_CheckedChanged(object sender, EventArgs e)
        {
            if (mwttb.Checked == true)
            {
                Settings.Default.mwttbs = true;
            }
            else
            {
                Settings.Default.mwttbs = false;
            }
        }

        private void autoupdateopt_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (autoupdateopt.SelectedIndex)
            {
                case 0:
                    Settings.Default.cfuevery = "day";
                    break;
                case 1:
                    Settings.Default.cfuevery = "week";
                    break;
                case 2:
                    Settings.Default.cfuevery = "month";
                    break;
                default:
                    Settings.Default.cfuevery = "day";
                    break;
            }
        }

        private void autoupdate_CheckedChanged(object sender, EventArgs e)
        {
            switch (autoupdate.Checked)
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
