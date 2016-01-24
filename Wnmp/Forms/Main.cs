/*
 * Copyright (c) 2012 - 2015, Kurt Cancemi (kurt@x64architecture.com)
 *
 * This file is part of Wnmp.
 *
 *  Wnmp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Wnmp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Wnmp.Forms
{

    /// <summary>
    /// Main form of Wnmp
    /// </summary>
    public partial class Main : Form
    {
        private WnmpProgram Nginx   = new WnmpProgram();
        private WnmpProgram MariaDB = new WnmpProgram();
        private WnmpProgram PHP     = new WnmpProgram();
        private WnmpUpdater Updater = new WnmpUpdater();
        public static string StartupPath { get { return Application.StartupPath; } }

        public static readonly Version CPVER = new Version("3.0.3");

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon();

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Constants.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        public void SetupNginx()
        {
            Nginx.exeName = StartupPath.Replace(@"\", "/") + "/nginx.exe";
            Nginx.procName = "nginx";
            Nginx.progName = "Nginx";
            Nginx.progLogSection = Log.LogSection.WNMP_NGINX;
            Nginx.startArgs = "";
            Nginx.stopArgs = "-s stop";
            Nginx.killStop = false;
            Nginx.statusLabel = nginxrunning;
            Nginx.confDir = "/conf/";
            Nginx.logDir = "/logs/";
        }

        public void SetupMariaDB()
        {
            MariaDB.exeName = StartupPath + "/mariadb/bin/mysqld.exe";
            MariaDB.procName = "mysqld";
            MariaDB.progName = "MariaDB";
            MariaDB.progLogSection = Log.LogSection.WNMP_MARIADB;
            MariaDB.startArgs = "";
            MariaDB.stopArgs = "";
            MariaDB.killStop = true;
            MariaDB.statusLabel = mariadbrunning;
            MariaDB.confDir = "/mariadb/";
            MariaDB.logDir = "/mariadb/data/";
        }

        public void SetupPHP()
        {
            if (Options.settings.phpBin != "Default") {
                SetupCustomPHP();
                return;
            }
            PHP.exeName = StartupPath + "/php/php-cgi.exe";
            PHP.procName = "php-cgi";
            PHP.progName = "PHP";
            PHP.progLogSection = Log.LogSection.WNMP_PHP;
            PHP.startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            PHP.stopArgs = "";
            PHP.killStop = true;
            PHP.statusLabel = phprunning;
            PHP.confDir = "/php/";
            PHP.logDir = "/php/logs/";
        }

        public void SetupCustomPHP()
        {
            PHP.exeName = StartupPath + "/php/phpbins/" + Options.settings.phpBin + "/php-cgi.exe";
            PHP.procName = "php-cgi";
            PHP.progName = "PHP";
            PHP.progLogSection = Log.LogSection.WNMP_PHP;
            PHP.startArgs = ""; // Special handling see StartPHP() in the WnmpProgram class
            PHP.stopArgs = "";
            PHP.killStop = true;
            PHP.statusLabel = phprunning;
            PHP.confDir = "/php/phpbins/" + Options.settings.phpBin + "/";
            PHP.logDir = "/php/phpbins/" + Options.settings.phpBin + "/logs/";
        }

        public Main()
        {
            InitializeComponent();
            Options.settings.ReadSettings();
            Options.settings.UpdateSettings();
            Updater.mainForm = this;
            Options.mainForm = this;

            SetupNginx();
            SetupMariaDB();
            SetupPHP();
        }

        private void DoCheckIfAppsAreRunningTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 5000; // TODO: 5 seconds sounds reasonable?
            timer.Tick += (s, e) => {
                Nginx.SetStatusLabel();
                MariaDB.SetStatusLabel();
                PHP.SetStatusLabel();
            };
            timer.Start();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Log.setLogComponent(log_rtb);
            WnmpTrayIcon.Click += WnmpTrayIcon_Click;
            WnmpTrayIcon.Icon = Properties.Resources.logo;
            WnmpTrayIcon.Visible = true;

            CheckForApps();
            DoCheckIfAppsAreRunningTimer();

            PopulateMenus();
            FirstRun();

            if (Options.settings.RunAppsAtLaunch)
                start_all_Click(null, null);

            if (Options.settings.AutoCheckForUpdates)
                Updater.DoDateEclasped();

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);
        }

        private bool NotifyMinimizeWnmp = true;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (Options.settings.MinimizeWnmpToTray == false)
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
            /* Cleanup */
            WnmpTrayIcon.Dispose();
            if (File.Exists(Application.StartupPath + "/Wnmp-Upgrade-Installer.exe")) {
                try {
                    File.Delete(Application.StartupPath + "/Wnmp-Upgrade-Installer.exe");
                } catch (Exception ex) {
                    Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
                }
            }
        }

        private void WnmpTrayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FirstRun()
        {
            if (Options.settings.FirstRun == false)
                return;

            if (!File.Exists(Main.StartupPath + "/bin/CertGen.exe"))
                return;
           if (!Directory.Exists(Main.StartupPath + "/conf"))
               Directory.CreateDirectory(Main.StartupPath + "/conf");

            using (Process ps = new Process()) {
                ps.StartInfo.FileName = Main.StartupPath + "/bin/CertGen.exe";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
                Options.settings.FirstRun = false;
                Options.settings.UpdateSettings();
            }
        }

        /// <summary>
        /// Checks if Nginx, MariaDB, and PHP exist in the Wnmp directory
        /// </summary>
        private void CheckForApps()
        {
            Log.wnmp_log_notice("Checking for applications", Log.LogSection.WNMP_MAIN);
            if (!File.Exists(Application.StartupPath + "/nginx.exe"))
                Log.wnmp_log_error("Error: Nginx Not Found", Log.LogSection.WNMP_NGINX);

            if (!Directory.Exists(Application.StartupPath + "/mariadb"))
                Log.wnmp_log_error("Error: MariaDB Not Found", Log.LogSection.WNMP_MARIADB);

            if (!Directory.Exists(Application.StartupPath + "/php"))
                Log.wnmp_log_error("Error: PHP Not Found", Log.LogSection.WNMP_PHP);
        }


        /// <summary>
        /// Adds configuration files or log files to the context menu strip
        /// </summary>
        private void DirFiles(string path, string GetFiles, ContextMenuStrip cms)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Main.StartupPath + path);

            if (!dinfo.Exists)
                return;

            FileInfo[] Files = dinfo.GetFiles(GetFiles);
            foreach (FileInfo file in Files)
                cms.Items.Add(file.Name, null);
        }
        /// <summary>
        /// Populate configuration and log menus
        /// </summary>
        private void PopulateMenus()
        {
            DirFiles("/conf",         "*.conf",  Nginx.configContextMenu);
            DirFiles("/mariadb",      "my.ini",  MariaDB.configContextMenu);
            DirFiles("/php",          "php.ini", PHP.configContextMenu);
            DirFiles("/logs",         "*.log",   Nginx.logContextMenu);
            DirFiles("/mariadb/data", "*.err",   MariaDB.logContextMenu);
            DirFiles("/php/logs",     "*.log",   PHP.logContextMenu);
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
            Updater.CheckForUpdates();
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

        private void start_all_Click(object sender, EventArgs e)
        {
            Nginx.Start();
            MariaDB.Start();
            PHP.Start();
        }

        private void stop_all_Click(object sender, EventArgs e)
        {
            Nginx.Stop();
            MariaDB.Stop();
            PHP.Stop();
        }

        private void mdb_shell_Click(object sender, EventArgs e)
        {
            if (MariaDB.IsRunning() == false)
                MariaDB.Start();

            try {
                Process.Start(StartupPath + "/mariadb/bin/mysql.exe", "-u root -p");
                Log.wnmp_log_notice("Started MariaDB shell", Log.LogSection.WNMP_MARIADB);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        private void wnmpdir_Click(object sender, EventArgs e)
        {
            // If this fails.... we have a bigger problem.
            Process.Start("explorer.exe", Application.StartupPath);
        }

        /* Applications Section */

        private void ngx_start_Click(object sender, EventArgs e)
        {
            Nginx.Start();
        }

        private void ngx_stop_Click(object sender, EventArgs e)
        {
            Nginx.Stop();
        }

        private void ngx_reload_Click(object sender, EventArgs e)
        {
            Nginx.Restart();
        }

        private void ngx_config_Click(object sender, EventArgs e)
        {
            Nginx.ConfigButton(sender);
        }

        private void ngx_log_Click(object sender, EventArgs e)
        {
            Nginx.LogButton(sender);
        }

        private void mdb_start_Click(object sender, EventArgs e)
        {
            MariaDB.Start();
        }

        private void mdb_stop_Click(object sender, EventArgs e)
        {
            MariaDB.Stop();
        }

        private void mdb_restart_Click(object sender, EventArgs e)
        {
            MariaDB.Restart();
        }

        private void mdb_cfg_Click(object sender, EventArgs e)
        {
            MariaDB.ConfigButton(sender);
        }

        private void mdb_log_Click(object sender, EventArgs e)
        {
            MariaDB.LogButton(sender);
        }

        private void php_start_Click(object sender, EventArgs e)
        {
            PHP.Start();
        }

        private void php_stop_Click(object sender, EventArgs e)
        {
            PHP.Stop();
        }

        private void php_restart_Click(object sender, EventArgs e)
        {
            PHP.Restart();
        }

        private void php_cfg_Click(object sender, EventArgs e)
        {
            PHP.ConfigButton(sender);
        }

        private void php_log_Click(object sender, EventArgs e)
        {
            PHP.LogButton(sender);
        }
    }
}
