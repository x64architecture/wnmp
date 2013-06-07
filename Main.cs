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
using System.Diagnostics;
using System.IO;

namespace Wnmp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        internal string CPVER = "2.0.1";
        #region Wnmp Stuff
        private void wnmpdir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Application.StartupPath);
        }

        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options form = new Options();
            form.ShowDialog();
            form.Focus();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                icon.BalloonTipTitle = "Wnmp";
                icon.BalloonTipText = "Wnmp has been minimized to the taskbar.";
                icon.ShowBalloonTip(3000);
            }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            WnmpFunctions.ContextMenus(); 
            WnmpFunctions.startup();
            Process[] process = Process.GetProcessesByName("Wnmp");
            Process current = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != current.Id)
                    p.Kill();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string license = "This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.";
            MessageBox.Show("Wnmp makes an easy Nginx, MySQL and PHP environment for Windows." + "\n" + "Created by Kurt Cancemi" + "\n" + "\n" + license);
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wnmp.x64Architecture.com");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
        }
        #endregion Wnmp Stuff
        #region output
        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
            string searchText = "Wnmp Main";
            int pos = 0;
            pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (output.SelectedText == searchText && output.SelectedText != "")
                {
                    output.SelectionLength = searchText.Length;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText5 = "nginx";
            int pos5 = 0;
            pos5 = output.Find(searchText5, pos5, RichTextBoxFinds.MatchCase);
            while (pos5 != -1)
            {
                if (output.SelectedText == searchText5 && output.SelectedText != "")
                {
                    output.SelectionLength = 5;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos5 = output.Find(searchText5, pos5 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText6 = "php";
            int pos6 = 0;
            pos6 = output.Find(searchText6, pos6, RichTextBoxFinds.MatchCase);
            while (pos6 != -1)
            {
                if (output.SelectedText == searchText6 && output.SelectedText != "")
                {
                    output.SelectionLength = 3;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos6 = output.Find(searchText6, pos6 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText7 = "mariadb";
            int pos7 = 0;
            pos7 = output.Find(searchText7, pos7, RichTextBoxFinds.MatchCase);
            while (pos7 != -1)
            {
                if (output.SelectedText == searchText7 && output.SelectedText != "")
                {
                    output.SelectionLength = 7;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos7 = output.Find(searchText7, pos7 + 1, RichTextBoxFinds.MatchCase);
            }
        }
        #endregion output
    }
}