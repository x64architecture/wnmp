/*
 * Copyright (c) 2012 - 2016, Kurt Cancemi (kurt@x64architecture.com)
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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.ComponentModel;

using Wnmp.Configuration;
using Wnmp.Programs;
using Wnmp.Updater;

namespace Wnmp.UI
{

    /// <summary>
    /// Main form of Wnmp
    /// </summary>
    public partial class Main : Form
    {
        private readonly MariaDBProgram MariaDB = new MariaDBProgram();
        private readonly WnmpProgram    Nginx   = new WnmpProgram();
        private readonly PHPProgram     PHP     = new PHPProgram();
        private readonly WnmpUpdater    Updater = new WnmpUpdater(); 
        public static string StartupPath { get { return Application.StartupPath; } }

        public Ini Settings = new Ini();

        private readonly NotifyIcon WnmpTrayIcon = new NotifyIcon {
            BalloonTipIcon = ToolTipIcon.Info, BalloonTipTitle = "Wnmp",
            BalloonTipText = "Wnmp has been minimized to the tray.",
            Icon = Properties.Resources.logo,
        };

        protected override CreateParams CreateParams
        {
            get {
                var myCp = base.CreateParams;
                myCp.Style = myCp.Style & ~Constants.WS_THICKFRAME; // Remove WS_THICKFRAME (Disables resizing)
                return myCp;
            }
        }

        private void SetupNginx()
        {
            Nginx.Settings = Settings;
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

        private void SetupMariaDB()
        {
            MariaDB.Settings = Settings;
            MariaDB.exeName = StartupPath + "/mariadb/bin/mysqld.exe";
            MariaDB.procName = "mysqld";
            MariaDB.progName = "MariaDB";
            MariaDB.progLogSection = Log.LogSection.WNMP_MARIADB;
            MariaDB.startArgs = "--install-manual Wnmp-MariaDB";
            MariaDB.stopArgs = "/c sc delete Wnmp-MariaDB";
            MariaDB.killStop = true;
            MariaDB.statusLabel = mariadbrunning;
            MariaDB.confDir = "/mariadb/";
            MariaDB.logDir = "/mariadb/data/";
            if (!MariaDB.ServiceExists())
                MariaDB.InstallService();
        }

        private void SetCurlCAPath()
        {
            var phpini = StartupPath + "/php/php.ini";

            string[] file = File.ReadAllLines(phpini);
            for (int i = 0; i < file.Length; i++) {
                if (file[i].Contains("curl.cainfo") == false)
                    continue;

                Regex reg = new Regex("\".*?\"");
                string replace = "\"" + StartupPath + @"\contrib\cacert.pem" + "\"";
                file[i] = file[i].Replace(reg.Match(file[i]).ToString(), replace);
            }
            using (var sw = new StreamWriter(phpini)) {
                foreach (var line in file)
                    sw.WriteLine(line);
            }
        }

        public void SetupPHP()
        {
            PHP.Settings = Settings;
            if (Settings.phpBin.Value != "Default") {
                SetupCustomPHP();
                return;
            }
            PHP.exeName = StartupPath + "/php/php-cgi.exe";
            PHP.procName = "php-cgi";
            PHP.progName = "PHP";
            PHP.progLogSection = Log.LogSection.WNMP_PHP;
            PHP.killStop = true;
            PHP.statusLabel = phprunning;
            PHP.confDir = "/php/";
            PHP.logDir = "/php/logs/";
            SetCurlCAPath();
        }

        public void SetupCustomPHP()
        {
            PHP.exeName = StartupPath + "/php/phpbins/" + Settings.phpBin.Value + "/php-cgi.exe";
            PHP.procName = "php-cgi";
            PHP.progName = "PHP";
            PHP.progLogSection = Log.LogSection.WNMP_PHP;
            PHP.killStop = true;
            PHP.statusLabel = phprunning;
            PHP.confDir = "/php/phpbins/" + Settings.phpBin.Value + "/";
            PHP.logDir = "/php/phpbins/" + Settings.phpBin.Value + "/logs/";
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);

        public Main()
        {
            var path = StartupPath + @"\bin\" +
                (Environment.Is64BitProcess ? "x64" : "x86");
            if (!SetDllDirectory(path))
                throw new Win32Exception();
            InitializeComponent();
            Settings.ReadSettings();
            Settings.UpdateSettings();
            Updater.mainForm = this;
            Updater.Settings = Settings;

            WnmpTrayIcon.Click += WnmpTrayIcon_Click;
            WnmpTrayIcon.Visible = true;

            if (Settings.StartMinimizedToTray.Value == true)
                visiblecore = false;

            SetupNginx();
            SetupMariaDB();
            SetupPHP();
        }

        private void DoCheckIfAppsAreRunningTimer()
        {
            var timer = new Timer { Interval = 1000 };
            timer.Tick += (s, e) => {
                Nginx.SetStatusLabel();
                MariaDB.SetStatusLabel();
                PHP.SetStatusLabel();
            };
            timer.Start();
        }

        private bool visiblecore = true;
        protected override void SetVisibleCore(bool value)
        {
            if (visiblecore == false) {
                value = false;
                if (!this.IsHandleCreated)
                    CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Log.setLogComponent(log_rtb);

            CheckForApps();
            DoCheckIfAppsAreRunningTimer();

            PopulateMenus();
            FirstRun();

            if (Settings.AutoCheckForUpdates.Value)
                Updater.DoDateEclasped();

            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);

            if (Settings.StartNginxOnLaunch.Value)
                Nginx.Start();
            if (Settings.StartMySQLOnLaunch.Value)
                MariaDB.Start();
            if (Settings.StartPHPOnLaunch.Value)
                PHP.Start();
        }

        private bool NotifyMinimizeWnmp = true;
        private void Main_Resize(object sender, EventArgs e)
        {
            if (Settings.MinimizeWnmpToTray.Value == false)
                return;

            if (WindowState == FormWindowState.Minimized) {
                this.Hide();
                if (NotifyMinimizeWnmp == false)
                    return;

                NotifyMinimizeWnmp = false;
                WnmpTrayIcon.ShowBalloonTip(4000);
            }
        }

        private bool NotifyMinimizeWnmp2 = true;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing ||
                Settings.MinimizeInsteadOfClosing.Value == false)
            {
                base.OnFormClosing(e);
                return;
            }

            this.Hide();
            e.Cancel = true;
            if (NotifyMinimizeWnmp2 == true) {
                WnmpTrayIcon.ShowBalloonTip(4000);
                NotifyMinimizeWnmp2 = false;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* Cleanup */
            WnmpTrayIcon.Visible = false;
            MariaDB.RemoveService();
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
            visiblecore = true;
            base.SetVisibleCore(true);
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FirstRun()
        {
            if (Settings.FirstRun.Value == false)
                return;

            if (!File.Exists(StartupPath + "/bin/CertGen.exe"))
                return;
           if (!Directory.Exists(StartupPath + "/conf"))
               Directory.CreateDirectory(StartupPath + "/conf");

            using (var ps = new Process()) {
                ps.StartInfo.FileName = StartupPath + "/bin/CertGen.exe";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
                Settings.FirstRun.Value = false;
                Settings.UpdateSettings();
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
            var dinfo = new DirectoryInfo(StartupPath + path);

            if (!dinfo.Exists)
                return;

            var files = dinfo.GetFiles(GetFiles);
            foreach (var file in files)
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
            var form = new Options {
                mainForm = this,
                Settings = Settings
            };
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
            var form = new HostToIP();
            ShowForm(form);
        }

        private void getHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new HttpHeaders();
            ShowForm(form);
        }

        /* Help Menu */

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Constants.MailingListUrl);
        }

        private void Report_BugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Constants.ReportBugUrl);
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Constants.WnmpWebUrl);
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Constants.WnmpContribUrl);
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

        public void StopAll()
        {
            Nginx.Stop();
            MariaDB.Stop();
            PHP.Stop();
        }

        private void stop_all_Click(object sender, EventArgs e)
        {
            StopAll();
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
