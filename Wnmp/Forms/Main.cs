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
using System.Diagnostics;

using Wnmp.Programs;
using Wnmp.Helpers;
using Wnmp.Internals;
namespace Wnmp.Forms
{

    /// <summary>
    /// Main form of Wnmp
    /// </summary>
    public partial class Main : Form
    {
        public static string StartupPath { get { return Application.StartupPath; } }

        private static readonly Version CPVER = new Version("2.3.2");
        public static Version GetCPVER { get { return CPVER; } }

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon();

        protected override CreateParams CreateParams
        {
            get
            {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Common.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        public Main()
        {
            InitializeComponent();
            setevents();
            Options.settings.ReadSettings();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Log.setLogComponent(log_rtb);
            WnmpTrayIcon.Icon = Properties.Resources.logo;
            WnmpTrayIcon.Visible = true;

            MainHelper.checkforapps();
            MainHelper.DoTimer();

            PopulateMenus();
            CheckFirstRun();

            if (Options.settings.Startallapplicationsatlaunch)
                General.start_Click(null, null);

            if (Options.settings.Autocheckforupdates)
                Updater.DoDateEclasped();

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);
        }

        private void CheckFirstRun()
        {
            var worker = new System.Threading.Thread(MainHelper.FirstRun);
            worker.Start();
        }

        /// <summary>
        /// Populate configuration and log menus
        /// </summary>
        private void PopulateMenus()
        {
            MainHelper.DirFiles("/conf", "*.conf", Nginx.cms);
            MainHelper.DirFiles("/mariadb", "my.ini", MariaDB.cms);
            MainHelper.DirFiles("/php", "php.ini", PHP.cms);
            MainHelper.DirFiles("/logs", "*.log", Nginx.lms);
            MainHelper.DirFiles("/mariadb/data", "*.err", MariaDB.lms);
            MainHelper.DirFiles("/php/logs", "*.log", PHP.lms);
        }
        
        /// <summary>
        /// Takes a form and displays it
        /// </summary>
        private void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater.CheckForUpdates(false);
        }

        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Options();
            ShowForm(form);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://mailman.getwnmp.org/mailman/listinfo/wnmp-users");
        }

        private void Report_BugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/wnmp/wnmp/issues/new");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutfrm = new About();
            ShowForm(aboutfrm);
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.getwnmp.org");
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P7LAQRRNF6AVE");
        }

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost");
        }

        private void hostToIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HostToIPForm();
            ShowForm(form);
        }

        private void getHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HttpHeaders();
            ShowForm(form);
        }

        private int MinimizeWnmpToTrayCount = 0;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (!Options.settings.Minimizewnmptotray)
                return;
            
            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                if (MinimizeWnmpToTrayCount > 0)
                    return;

                MinimizeWnmpToTrayCount++;
                WnmpTrayIcon.BalloonTipTitle = "Wnmp";
                WnmpTrayIcon.BalloonTipText = "Wnmp has been minimized to the tray.";
                WnmpTrayIcon.ShowBalloonTip(4000);
           }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            WnmpTrayIcon.Dispose();
            Common.DeleteFile(Application.StartupPath + "/updater.exe");
            Common.DeleteFile(Application.StartupPath + "/Wnmp-Upgrade-Installer.exe");
        }

        private void WnmpTrayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void wnmpdir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void setevents()
        {
            WnmpTrayIcon.Click += WnmpTrayIcon_Click;
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
            mdb_restart.Click += MariaDB.mdb_restart_Click;
            mdb_shell.Click += MariaDB.mdb_shell_Click;
            mdb_cfg.Click += MariaDB.mdb_cfg_Click;
            mdb_log.Click += MariaDB.mdb_log_Click;
            mdb_start.MouseHover += MariaDB.mdb_start_MouseHover;
            mdb_stop.MouseHover += MariaDB.mdb_stop_MouseHover;
            mdb_shell.MouseHover += MariaDB.mdb_shell_MouseHover;
            mdb_restart.MouseHover += MariaDB.mdb_restart_MouseHover;
            // End
            // PHP Events Start
            php_start.Click += PHP.php_start_Click;
            php_stop.Click += PHP.php_stop_Click;
            php_restart.Click += PHP.php_restart_Click;
            php_cfg.Click += PHP.php_cfg_Click;
            php_log.Click += PHP.php_log_Click;
            php_start.MouseHover += PHP.php_start_MouseHover;
            php_stop.MouseHover += PHP.php_stop_MouseHover;
            php_restart.MouseHover += PHP.php_restart_MouseHover;
            // End
        }
    }
}
