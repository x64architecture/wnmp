/*
Copyright (c) Kurt Cancemi 2012-2015

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
        private General GeneralIns   = new General();
        private Nginx NginxIns       = new Nginx();
        private MariaDB MariaDBIns   = new MariaDB();
        private PHP PHPIns           = new PHP();
        private Updater UpdaterIns   = new Updater();
        private MainHelper HelperIns = new MainHelper();
        public static string StartupPath { get { return Application.StartupPath; } }

        public static readonly Version CPVER = new Version("2.4.1");

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon();

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Common.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        public Main()
        {
            InitializeComponent();
            Options.settings.ReadSettings();
            GeneralIns.form = this;
            NginxIns.form   = this;
            MariaDBIns.form = this;
            PHPIns.form     = this;
            UpdaterIns.form = this;
            HelperIns.form  = this;
            GeneralIns.nginx   = NginxIns;
            GeneralIns.mariadb = MariaDBIns;
            GeneralIns.php     = PHPIns;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Log.setLogComponent(log_rtb);
            WnmpTrayIcon.Icon = Properties.Resources.logo;
            WnmpTrayIcon.Visible = true;

            HelperIns.checkforapps();
            HelperIns.DoTimer();

            PopulateMenus();
            HelperIns.FirstRun();

            if (Options.settings.Startallappsatlaunch)
                GeneralIns.StartAllProgs();

            if (Options.settings.Autocheckforupdates)
                UpdaterIns.DoDateEclasped();

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);
        }

        private bool NotifyMinimizeWnmp = true;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (Options.settings.Minimizewnmptotray == false)
                return;

            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                if (NotifyMinimizeWnmp == false)
                    return;

                NotifyMinimizeWnmp = false;
                WnmpTrayIcon.BalloonTipTitle = "Wnmp";
                WnmpTrayIcon.BalloonTipText = "Wnmp has been minimized to the tray.";
                WnmpTrayIcon.ShowBalloonTip(4000);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            WnmpTrayIcon.Dispose();
            Common.DeleteFile(Application.StartupPath + "/Wnmp-Upgrade-Installer.exe");
        }

        private void WnmpTrayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Populate configuration and log menus
        /// </summary>
        private void PopulateMenus()
        {
            HelperIns.DirFiles("/conf",         "*.conf",  NginxIns.cms);
            HelperIns.DirFiles("/mariadb",      "my.ini",  MariaDBIns.cms);
            HelperIns.DirFiles("/php",          "php.ini", PHPIns.cms);
            HelperIns.DirFiles("/logs",         "*.log",   NginxIns.lms);
            HelperIns.DirFiles("/mariadb/data", "*.err",   MariaDBIns.lms);
            HelperIns.DirFiles("/php/logs",     "*.log",   PHPIns.lms);
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

        /* File Menu */
        private void wnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options form = new Options();
            ShowForm(form);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdaterIns.CheckForUpdates(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Tools Menu */

        private void hostToIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostToIPForm form = new HostToIPForm();
            ShowForm(form);
        }

        private void getHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpHeaders form = new HttpHeaders();
            ShowForm(form);
        }

        /* Help Menu */

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Process.Start(Constants.MailingListUrl);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void Report_BugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
            Process.Start(Constants.ReportBugUrl);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Process.Start(Constants.WnmpWebUrl);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Process.Start(Constants.WnmpContribUrl);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutfrm = new About();
            ShowForm(aboutfrm);
        }

        /* Lone button */

        private void localhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost");
        }

        /*  Right Hand Side */

        private void start_Click(object sender, EventArgs e)
        {
            GeneralIns.StartAllProgs();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            GeneralIns.StopAllProgs();
        }

        private void mdb_shell_Click(object sender, EventArgs e)
        {
            MariaDBIns.StartMDBShell();
        }

        private void wnmpdir_Click(object sender, EventArgs e)
        {
            // If this fails.... we have a bigger problem.
            Process.Start("explorer.exe", Application.StartupPath);
        }

        /* Applications Section */

        private void ngx_start_Click(object sender, EventArgs e)
        {
            NginxIns.StartNginx();
        }

        private void ngx_stop_Click(object sender, EventArgs e)
        {
            NginxIns.StopNginx();
        }

        private void ngx_reload_Click(object sender, EventArgs e)
        {
            NginxIns.ReloadNginx();
        }

        private void ngx_config_Click(object sender, EventArgs e)
        {
            NginxIns.NginxConfig(sender);
        }

        private void ngx_log_Click(object sender, EventArgs e)
        {
            NginxIns.NginxLog(sender);
        }

        private void mdb_start_Click(object sender, EventArgs e)
        {
            MariaDBIns.StartMariaDB();
        }

        private void mdb_stop_Click(object sender, EventArgs e)
        {
            MariaDBIns.StopMariaDB();
        }

        private void mdb_restart_Click(object sender, EventArgs e)
        {
            MariaDBIns.RestartMariaDB();
        }

        private void mdb_cfg_Click(object sender, EventArgs e)
        {
            MariaDBIns.MariaDBConfig(sender);
        }

        private void mdb_log_Click(object sender, EventArgs e)
        {
            MariaDBIns.MariaDBLog(sender);
        }

        private void php_start_Click(object sender, EventArgs e)
        {
            PHPIns.StartPHP();
        }

        private void php_stop_Click(object sender, EventArgs e)
        {
            PHPIns.StopPHP();
        }

        private void php_restart_Click(object sender, EventArgs e)
        {
            PHPIns.RestartPHP();
        }

        private void php_cfg_Click(object sender, EventArgs e)
        {
            PHPIns.PHPConfig(sender);
        }

        private void php_log_Click(object sender, EventArgs e)
        {
            PHPIns.PHPLog(sender);
        }
    }
}
