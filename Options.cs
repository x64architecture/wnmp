/*
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
    }
}
