/*
This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU Wnmp Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Wnmp Public License for more details.

    You should have received a copy of the GNU Wnmp Public License
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

namespace Wnmp
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (Wnmp.Properties.Settings.Default.startaprgssu == false)
            {
                suap.Checked = false;
            }
            else
            {
                suap.Checked = true;
            }
            if (Wnmp.Properties.Settings.Default.startwnmpsu == false)
            {
                suwnmpcb.Checked = false;
            }
            else
            {
                suwnmpcb.Checked = true;
            }
            if (Wnmp.Properties.Settings.Default.editor == "")
            {
                editorTB.Text = "notpad.exe";
            }
            else
            {
                editorTB.Text = Wnmp.Properties.Settings.Default.editor;
            }
        }

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
            Wnmp.Properties.Settings.Default.editor = dialog.FileName;
            Wnmp.Properties.Settings.Default.Save();
            if (input == String.Empty)
            Wnmp.Properties.Settings.Default.editor = "notepad.exe";
            Wnmp.Properties.Settings.Default.Save();
            editorTB.Text = Wnmp.Properties.Settings.Default.editor;
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
                    Wnmp.Properties.Settings.Default.startwnmpsu = true;
                    Wnmp.Properties.Settings.Default.Save();
                }
                else
                {
                    RegistryKey remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Wnmp");
                    Wnmp.Properties.Settings.Default.startwnmpsu = false;
                    Wnmp.Properties.Settings.Default.Save();
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
                Wnmp.Properties.Settings.Default.startaprgssu = true;
                Wnmp.Properties.Settings.Default.Save();
            }
            else
            {
                Wnmp.Properties.Settings.Default.startaprgssu = false;
                Wnmp.Properties.Settings.Default.Save();
            }
        }

        private void mwttb_CheckedChanged(object sender, EventArgs e)
        {
            if (mwttb.Checked == true)
            {
                Wnmp.Properties.Settings.Default.mwttbs = true;
                Wnmp.Properties.Settings.Default.Save();
            }
            else
            {
                Wnmp.Properties.Settings.Default.mwttbs = false;
                Wnmp.Properties.Settings.Default.Save();
            }
        }
    }
}
