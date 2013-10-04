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
using System.Net;
using System.Collections.Specialized;

namespace Wnmp
{
    public partial class Main : Form
    {
        public static string getappsupath = Application.StartupPath;
        public Main(string[] args)
        {
            InitializeComponent();
        }
        internal string CPVER = "2.0.7";
        #region Wnmp Stuff
        private void wnmpdir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @Application.StartupPath);
        }

        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options form = new Options();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://groups.google.com/group/windows-nginx-mysql-php-discuss");
        }
        private void Report_BugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string desktoppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                foreach (string file in Directory.GetFiles(Application.StartupPath + @"\logs", "*error*"))
                {
                    if (!Directory.Exists(desktoppath + @"\Wnmpissuefiles"))
                        Directory.CreateDirectory(desktoppath + @"\Wnmpissuefiles");
                    if (File.Exists(file))
                        File.Copy(file, desktoppath + @"\Wnmpissuefiles\" + Path.GetFileName(file), true);
                }
                if (!Directory.Exists(desktoppath + @"\Wnmpissuefiles"))
                    Directory.CreateDirectory(desktoppath + @"\Wnmpissuefiles");
                File.Copy(Application.StartupPath + "/php/logs/sys.log", desktoppath + @"\Wnmpissuefiles\sys.log", true);
                MessageBox.Show(String.Format("Attach the error log inside the {0} folder to the issue report that is associated with the problem you are facing.", desktoppath + @"\Wnmpissuefiles"));
                Process.Start("https://bitbucket.org/x64architecture/windows-nginx-mysql-php/issues/new");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (Wnmp.Properties.Settings.Default.mwttbs == true)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                    icon.BalloonTipTitle = "Wnmp";
                    icon.BalloonTipText = "Wnmp has been minimized to the taskbar.";
                    icon.ShowBalloonTip(3000);
                }
            }
            else { }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            icp();
            timer1.Enabled = true;
            WnmpFunctions.ContextMenus();
            WnmpFunctions.startup();
        }
        private void icp()
        {
            Process[] process = Process.GetProcessesByName("Wnmp");
            Process current = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != current.Id)
                {
                    MessageBox.Show("Wnmp is already running");
                    Application.Exit();
                }
            else { }
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wnmp.Forms.About aboutfrm = new Wnmp.Forms.About();
            aboutfrm.StartPosition = FormStartPosition.CenterParent;
            aboutfrm.ShowDialog(this);
            aboutfrm.Focus();
        }
        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://wnmp.x64Architecture.com");
        }
        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
        }

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost");
        }
        #endregion Wnmp Stuff
        #region output
        public void tc(string text, string oColor)
        {
            System.Drawing.ColorConverter colConvert = new ColorConverter();
            string searchText = text;
            int pos = 0;
            pos = output.Find(searchText, pos, RichTextBoxFinds.MatchCase);
            while (pos != -1)
            {
                if (output.SelectedText == searchText && output.SelectedText != "")
                {
                    output.SelectionLength = searchText.Length;
                    output.SelectionFont = new Font("arial", 10);
                    output.SelectionColor = (System.Drawing.Color)colConvert.ConvertFromString(oColor);
                }
                pos = output.Find(searchText, pos + 1, RichTextBoxFinds.MatchCase);
            }
        }
        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
            tc("Wnmp Main", "DarkBlue");
            tc("Wnmp Nginx", "DarkBlue");
            tc("Wnmp PHP", "DarkBlue");
            tc("Wnmp MariaDB", "DarkBlue");
        }
        #endregion output
        #region events
        // TODO: figure out a better way to do this(though there may not be)
        private void start_Click(object sender, EventArgs e) { General.start_Click(); } // start_Click
        private void stop_Click(object sender, EventArgs e) { General.stop_Click(); } // stop_Click
        private void opnMariaDBshell_Click(object sender, EventArgs e) { MariaDB.opnMariaDBshell_Click(); } // opnMariaDBshell_Click
        private void nginxstart_Click(object sender, EventArgs e) { Nginx.nginxstart_Click(); } // nginxstart_Click
        private void MariaDBstart_Click(object sender, EventArgs e) { MariaDB.MariaDBstart_Click(); } // MariaDBstart_Click
        private void phpstart_Click(object sender, EventArgs e) { PHP.phpstart_Click(); } // phpstart_Click
        private void nginxstop_Click(object sender, EventArgs e) { Nginx.nginxstop_Click(); } // nginxstop_Click
        private void MariaDBstop_Click(object sender, EventArgs e) { MariaDB.MariaDBstop_Click(); } // MariaDBstop_Click
        private void phpstop_Click(object sender, EventArgs e) { PHP.phpstop_Click(); } // phpstop_Click
        private void nginxreload_Click(object sender, EventArgs e) { Nginx.nginxreload_Click(); } // nginxreload_Click
        private void MariaDBhelp_Click(object sender, EventArgs e) { MariaDB.MariaDBhelp_Click(); } // MariaDBhelp_Click
        private void ngxconfig_Click(object sender, EventArgs e) { WnmpFunctions.ngxconfig_Click(sender,  e); } // ngxconfig_Click
        private void MariaDBCFG_Click(object sender, EventArgs e) { WnmpFunctions.MariaDBCFG_Click(sender, e); } // MariaDBCFG_Click
        private void PHPCFG_Click(object sender, EventArgs e) { WnmpFunctions.PHPCFG_Click(sender, e); } // PHPCFG_Click
        private void nginxlogs_Click(object sender, EventArgs e) { WnmpFunctions.nginxlogs_Click(sender, e); } // nginxlogs_Click
        private void mariadblogs_Click(object sender, EventArgs e) { WnmpFunctions.mariadblogs_Click(sender, e); } // mariadblogs_Click
        private void phplogs_Click(object sender, EventArgs e){ WnmpFunctions.phplogs_Click(sender, e); } // phplogs_Click
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) { WnmpFunctions.checkForUpdatesToolStripMenuItem_Click(); } // checkForUpdatesToolStripMenuItem_Click
        private void nginxstart_MouseHover(object sender, EventArgs e) { Nginx.nginxstart_MouseHover(); } // nginxstart_MouseHover
        private void MariaDBstart_MouseHover(object sender, EventArgs e) { MariaDB.MariaDBstart_MouseHover(); } // MariaDBstart_MouseHover
        private void phpstart_MouseHover(object sender, EventArgs e) { PHP.phpstart_MouseHover(); } // phpstart_MouseHover
        private void nginxstop_MouseHover(object sender, EventArgs e) { Nginx.nginxstop_MouseHover(); } // nginxstop_MouseHover
        private void MariaDBstop_MouseHover(object sender, EventArgs e) { MariaDB.MariaDBstop_MouseHover(); } // MariaDBstop_MouseHover
        private void phpstop_MouseHover(object sender, EventArgs e) { PHP.phpstop_MouseHover(); } // phpstop_MouseHover
        private void nginxreload_MouseHover(object sender, EventArgs e) { Nginx.nginxreload_MouseHover(); } // nginxreload_MouseHover
        private void start_MouseHover(object sender, EventArgs e) { General.start_MouseHover(); } // start_MouseHover
        private void stop_MouseHover(object sender, EventArgs e) { General.stop_MouseHover(); } // stop_MouseHover
        private void opnMariaDBshell_MouseHover(object sender, EventArgs e) { MariaDB.opnMariaDBshell_MouseHover(); } // opnMariaDBshell_MouseHover
        private void timer1_Tick(object sender, EventArgs e) { WnmpFunctions.timer1_Tick(); }
        #endregion
    }
}