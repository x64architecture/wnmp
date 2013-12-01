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
        public Main()
        {
            InitializeComponent();
            setevents();
        }
        internal Version CPVER = new Version("2.0.9");
        #region Wnmp Stuff
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string xmlUrl = "https://wnmp.x64architecture.com/update.xml";
            Updater _Updater = new Updater(xmlUrl, CPVER);
        }
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
                Process.Start("https://github.com/wnmp/wnmp/issues/new");
            }
            catch (Exception ex) { Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN); }
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
            if (File.Exists(@Application.StartupPath + "/updater.exe"))
            {
                try
                {
                    File.Delete(@Application.StartupPath + "/updater.exe");
                }
                catch (Exception ex) { Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN); }
            }
            timer1.Enabled = true;
            WnmpFunctions.startup();
            DoAutoCheckForUpdate();
        }

        private void DoAutoCheckForUpdate()
        {
            if (Wnmp.Properties.Settings.Default.autocheckforupdates == true)
            {
                switch (Wnmp.Properties.Settings.Default.cfuevery)
                {
                    case "day":
                        DoDateEclasped(1);
                        break;
                    case "week":
                        DoDateEclasped(7);
                        break;
                    case "month":
                        DoDateEclasped(30);
                        break;
                    default:
                        DoDateEclasped(7); /* Default: To check for updates every week. */
                        break;
                }
            }
        }
        public bool IsSet(string s)
        {
            if (s != "")
                return true;
            else
                return false;
        }
        private void DoDateEclasped(double days)
        {
            if (IsSet(Wnmp.Properties.Settings.Default.lastcheckforupdate))
            {
                DateTime LastCheckForUpdate = DateTime.Parse(Wnmp.Properties.Settings.Default.lastcheckforupdate);
                DateTime expiryDate = LastCheckForUpdate.AddDays(days);
                if (DateTime.Now > expiryDate)
                {
                    const string xmlUrl = "https://wnmp.x64architecture.com/update.xml";
                    Updater _Updater = new Updater(xmlUrl, CPVER);
                }
            }
            else
            {
                Wnmp.Properties.Settings.Default.lastcheckforupdate = DateTime.Now.ToString();
                Wnmp.Properties.Settings.Default.Save();
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
        #region events
        private void setevents()
        {
            Log.setLogComponent(log_rtb);
            // General Events Start
            start.Click += General.start_Click;
            stop.Click += General.stop_Click;
            // End
            // Nginx Events Start
            ngx_start.Click += Nginx.ngx_start_Click;
            ngx_stop.Click += Nginx.ngx_stop_Click;
            ngx_reload.Click += Nginx.ngx_reload_Click;
            ngx_config.Click += Nginx.ngx_cfg_Click;
            ngx_log.Click += Nginx.ngx_log_Click;
            ngx_start.MouseHover += Nginx.ngx_start_MouseHover;
            ngx_stop.MouseHover += Nginx.ngx_stop_MouseHover;
            ngx_reload.MouseHover += Nginx.ngx_reload_MouseHover;
            // End
            // MariaDB Events Start
            mdb_start.Click += MariaDB.mdb_start_Click;
            mdb_stop.Click += MariaDB.mdb_stop_Click;
            mdb_help.Click += MariaDB.mdb_help_Click;
            mdb_shell.Click += MariaDB.mdb_shell_Click;
            mdb_cfg.Click += MariaDB.mdb_cfg_Click;
            //mdb_log.Click += WnmpFunctions.mdb_log_Click;
            mdb_start.MouseHover += MariaDB.mdb_start_MouseHover;
            mdb_stop.MouseHover += MariaDB.mdb_stop_MouseHover;
            mdb_shell.MouseHover += MariaDB.mdb_shell_MouseHover;
            // End
            // PHP Events Start
            php_start.Click += PHP.php_start_Click;
            php_stop.Click += PHP.php_stop_Click;
            php_cfg.Click += PHP.php_cfg_Click;
            php_log.Click += PHP.php_log_Click;
            php_start.MouseHover += PHP.php_start_MouseHover;
            php_stop.MouseHover += PHP.php_stop_MouseHover;
            // End
        }
        #endregion
    }
}