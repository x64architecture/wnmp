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
        public Main(string[] args)
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
            Process[] process = Process.GetProcessesByName("Wnmp");
            Process current = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != current.Id)
                MessageBox.Show("Wnmp is already running");
                Application.Exit();
            }
            WnmpFunctions.ContextMenus();
            WnmpFunctions.startup();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string license = "This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.";
            MessageBox.Show("Wnmp makes an easy Nginx, MySQL and PHP environment for Windows." + "\n" + "Copyright (C) 2012-" + DateTime.Now.Year + " Kurt Cancemi" + "\n" + "\n" + license);
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
            string searchText5 = "Wnmp Nginx";
            int pos5 = 0;
            pos5 = output.Find(searchText5, pos5, RichTextBoxFinds.MatchCase);
            while (pos5 != -1)
            {
                if (output.SelectedText == searchText5 && output.SelectedText != "")
                {
                    output.SelectionLength = 10;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos5 = output.Find(searchText5, pos5 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText6 = "Wnmp PHP";
            int pos6 = 0;
            pos6 = output.Find(searchText6, pos6, RichTextBoxFinds.MatchCase);
            while (pos6 != -1)
            {
                if (output.SelectedText == searchText6 && output.SelectedText != "")
                {
                    output.SelectionLength = 8;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos6 = output.Find(searchText6, pos6 + 1, RichTextBoxFinds.MatchCase);
            }
            string searchText7 = "Wnmp MariaDB";
            int pos7 = 0;
            pos7 = output.Find(searchText7, pos7, RichTextBoxFinds.MatchCase);
            while (pos7 != -1)
            {
                if (output.SelectedText == searchText7 && output.SelectedText != "")
                {
                    output.SelectionLength = 12;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = Color.DarkBlue;
                }
                pos7 = output.Find(searchText7, pos7 + 1, RichTextBoxFinds.MatchCase);
            }
        }
        #endregion output
        #region events
        // Do this until I figure out a better way to do this(if there is).
        private void start_Click(object sender, EventArgs e)
        {
            General.start_Click();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            General.stop_Click();
        }

        private void opnmysqlshell_Click(object sender, EventArgs e)
        {
            MariaDB.opnmysqlshell_Click();
        }

        private void nginxstart_Click(object sender, EventArgs e)
        {
            Nginx.nginxstart_Click();
        }

        private void mysqlstart_Click(object sender, EventArgs e)
        {
            MariaDB.mysqlstart_Click();
        }

        private void phpstart_Click(object sender, EventArgs e)
        {
            PHP.phpstart_Click();
        }

        private void nginxstop_Click(object sender, EventArgs e)
        {
            Nginx.nginxstop_Click();
        }

        private void mysqlstop_Click(object sender, EventArgs e)
        {
            MariaDB.mysqlstop_Click();
        }

        private void phpstop_Click(object sender, EventArgs e)
        {
            PHP.phpstop_Click();
        }

        private void nginxreload_Click(object sender, EventArgs e)
        {
            Nginx.nginxreload_Click();
        }

        private void mysqlhelp_Click(object sender, EventArgs e)
        {
            MariaDB.mysqlhelp_Click();
        }

        private void ngxconfig_Click(object sender, EventArgs e)
        {
            WnmpFunctions.nginxlogs_Click(sender,  e);
        }

        private void MariaDBCFG_Click(object sender, EventArgs e)
        {
            WnmpFunctions.MariaDBCFG_Click(sender, e);
        }

        private void PHPCFG_Click(object sender, EventArgs e)
        {
            WnmpFunctions.PHPCFG_Click(sender, e);
        }

        private void nginxlogs_Click(object sender, EventArgs e)
        {
            WnmpFunctions.nginxlogs_Click(sender, e);
        }

        private void mariadblogs_Click(object sender, EventArgs e)
        {
            WnmpFunctions.mariadblogs_Click(sender, e);
        }

        private void phplogs_Click(object sender, EventArgs e)
        {
            WnmpFunctions.phplogs_Click(sender, e);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WnmpFunctions.checkForUpdatesToolStripMenuItem_Click();
        }

        private void nginxstart_MouseHover(object sender, EventArgs e)
        {
            Nginx.nginxstart_MouseHover();
        }

        private void mysqlstart_MouseHover(object sender, EventArgs e)
        {
            MariaDB.mysqlstart_MouseHover();
        }

        private void phpstart_MouseHover(object sender, EventArgs e)
        {
            PHP.phpstart_MouseHover();
        }

        private void nginxstop_MouseHover(object sender, EventArgs e)
        {
            Nginx.nginxstop_MouseHover();
        }

        private void mysqlstop_MouseHover(object sender, EventArgs e)
        {
            MariaDB.mysqlstop_MouseHover();
        }

        private void phpstop_MouseHover(object sender, EventArgs e)
        {
            PHP.phpstop_MouseHover();
        }

        private void nginxreload_MouseHover(object sender, EventArgs e)
        {
            Nginx.nginxreload_MouseHover();
        }

        private void start_MouseHover(object sender, EventArgs e)
        {
            General.start_MouseHover();
        }

        private void stop_MouseHover(object sender, EventArgs e)
        {
            General.stop_MouseHover();
        }

        private void opnmysqlshell_MouseHover(object sender, EventArgs e)
        {
            MariaDB.opnmysqlshell_MouseHover();
        }
        #endregion
    }
}