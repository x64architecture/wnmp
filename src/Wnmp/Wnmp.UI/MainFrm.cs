/*
 * Copyright (c) 2012 - 2017, Kurt Cancemi (kurt@x64architecture.com)
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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Wnmp.Programs;
using Wnmp.Updater;
using Wnmp.Wnmp.UI;

namespace Wnmp.UI
{
    public partial class MainFrm : Form
    {
        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00040000; // Remove WS_THICKFRAME (Disables resizing)
                return cp;
            }
        }

        WnmpProgram Nginx;
        MariaDBProgram MariaDB;
        PHPProgram PHP;

        ContextMenuStrip NginxConfigContextMenuStrip, NginxLogContextMenuStrip;
        ContextMenuStrip MariaDBConfigContextMenuStrip, MariaDBLogContextMenuStrip;
        ContextMenuStrip PHPConfigContextMenuStrip, PHPLogContextMenuStrip;
        private WnmpUpdater updater;
        private NotifyIcon ni = new NotifyIcon();
        private bool visiblecore = true;

        private void SetupNginx()
        {
            Nginx = new WnmpProgram(Program.StartupPath + "\\nginx.exe") {
                ProgLogSection = Log.LogSection.Nginx,
                StartArgs = "",
                StopArgs = "-s stop",
                ConfDir = Program.StartupPath + "\\conf\\",
                LogDir = Program.StartupPath + "\\logs\\"
            };
        }

        private void SetupMariaDB()
        {
            MariaDB = new MariaDBProgram(Program.StartupPath + "\\mariadb\\bin\\mysqld.exe") {
                ProgLogSection = Log.LogSection.MariaDB,
                StartArgs = "--install-manual Wnmp-MariaDB",
                StopArgs = "/c sc delete Wnmp-MariaDB",
                ConfDir = Program.StartupPath + "\\mariadb\\",
                LogDir = Program.StartupPath + "\\mariadb\\data\\"
            };
        }

        public void SetupPHP()
        {
            PHP = new PHPProgram(Program.StartupPath + "\\php\\php-cgi.exe") {
                ProgLogSection = Log.LogSection.PHP,
                ConfDir = Program.StartupPath + "\\php\\",
                LogDir = Program.StartupPath + "\\php\\logs\\"
            };
            SetCurlCAPath();
        }

        private void SetCurlCAPath()
        {
            string phpini = Program.StartupPath + "/php/php.ini";
            if (!File.Exists(phpini))
                return;

            string[] file = File.ReadAllLines(phpini);
            for (int i = 0; i < file.Length; i++) {
                if (file[i].Contains("curl.cainfo") == false)
                    continue;

                Regex reg = new Regex("\".*?\"");
                string orginal = reg.Match(file[i]).ToString();
                if (orginal == String.Empty)
                    continue;
                string replace = "\"" + Program.StartupPath + @"\contrib\cacert.pem" + "\"";
                file[i] = file[i].Replace(orginal, replace);
            }
            using (var sw = new StreamWriter(phpini)) {
                foreach (var line in file)
                    sw.WriteLine(line);
            }
        }

        /// <summary>
        /// Adds configuration files or log files to a context menu strip
        /// </summary>
        private void DirFiles(string path, string GetFiles, ContextMenuStrip cms)
        {
            var dInfo = new DirectoryInfo(path);

            if (!dInfo.Exists)
                return;

            var files = dInfo.GetFiles(GetFiles);
            foreach (var file in files) {
                cms.Items.Add(file.Name);
            }
        }

        private void SetupConfigAndLogMenuStrips()
        {
            NginxConfigContextMenuStrip = new ContextMenuStrip();
            NginxConfigContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(Nginx.ConfDir + e.ClickedItem.ToString());
            };
            NginxLogContextMenuStrip = new ContextMenuStrip();
            NginxLogContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(Nginx.LogDir + e.ClickedItem.ToString());
            };
            MariaDBConfigContextMenuStrip = new ContextMenuStrip();
            MariaDBConfigContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(MariaDB.ConfDir + e.ClickedItem.ToString());
            };
            MariaDBLogContextMenuStrip = new ContextMenuStrip();
            MariaDBLogContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(MariaDB.LogDir + e.ClickedItem.ToString());
            };
            PHPConfigContextMenuStrip = new ContextMenuStrip();
            PHPConfigContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(PHP.ConfDir + e.ClickedItem.ToString());
            };
            PHPLogContextMenuStrip = new ContextMenuStrip();
            PHPLogContextMenuStrip.ItemClicked += (s, e) => {
                Misc.OpenFileEditor(PHP.LogDir + e.ClickedItem.ToString());
            };
            DirFiles(Nginx.ConfDir, "*.conf", NginxConfigContextMenuStrip);
            DirFiles(MariaDB.ConfDir, "my.ini", MariaDBConfigContextMenuStrip);
            DirFiles(PHP.ConfDir, "php.ini", PHPConfigContextMenuStrip);
            DirFiles(Nginx.LogDir, "*.log", NginxLogContextMenuStrip);
            DirFiles(MariaDB.LogDir, "*.err", MariaDBLogContextMenuStrip);
            DirFiles(PHP.LogDir, "*.log", PHPLogContextMenuStrip);

        }

        public void SetupCustomPHP()
        {
            string phpVersion = Properties.Settings.Default.PHPVersion;
            PHP = new PHPProgram(Program.StartupPath + "\\php\\phpbins\\" + phpVersion + "\\php-cgi.exe") {
                ProgLogSection = Log.LogSection.PHP,
                ConfDir = Program.StartupPath + "\\php\\phpbins\\" + phpVersion + "\\",
                LogDir = Program.StartupPath + "\\php\\phpbins\\" + phpVersion + "\\logs\\",
            };
        }

        private void CreateWnmpCertificate()
        {
            string ConfDir = Program.StartupPath + "\\conf";

            if (!Directory.Exists(ConfDir))
                Directory.CreateDirectory(ConfDir);

            string keyFile = ConfDir + "\\key.pem";
            string certFile = ConfDir + "\\cert.pem";

            if (File.Exists(keyFile) && File.Exists(certFile))
                return;

            CertGen certgen = new CertGen();
            certgen.GenerateSelfSignedCertificate("Wnmp", 2048, keyFile, certFile);
        }

        private MenuItem CreateWnmpProgramMenuItem(WnmpProgram prog)
        {
            MenuItem item = new MenuItem();

            item.Text = Log.LogSectionToString(prog.ProgLogSection);
            MenuItem start = item.MenuItems.Add("Start");
            start.Click += (s, e) => { prog.Start(); };
            MenuItem stop = item.MenuItems.Add("Stop");
            stop.Click += (s, e) => { prog.Stop(); };
            MenuItem restart = item.MenuItems.Add("Restart");
            restart.Click += (s, e) => { prog.Restart(); };

            return item;
        }

        private void SetupTrayMenu()
        {
            MenuItem controlpanel = new MenuItem("Wnmp Control Panel");
            controlpanel.Click += (s, e) => {
                visiblecore = true;
                base.SetVisibleCore(true);
                WindowState = FormWindowState.Normal;
                Show();
            };
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(controlpanel);
            cm.MenuItems.Add("-");
            cm.MenuItems.Add(CreateWnmpProgramMenuItem(Nginx));
            cm.MenuItems.Add(CreateWnmpProgramMenuItem(MariaDB));
            cm.MenuItems.Add(CreateWnmpProgramMenuItem(PHP));
            cm.MenuItems.Add("-");
            MenuItem exit = new MenuItem("Exit");
            exit.Click += (s, e) => { Application.Exit(); };
            cm.MenuItems.Add(exit);
            cm.MenuItems.Add("-");
            ni.ContextMenu = cm;
            ni.Icon = Properties.Resources.logo;
            ni.Click += (s, e) => {
                visiblecore = true;
                base.SetVisibleCore(true);
                WindowState = FormWindowState.Normal;
                Show();
            };
            ni.Visible = true;
        }

        protected override void SetVisibleCore(bool value)
        {
            if (visiblecore == false) {
                value = false;
                if (!IsHandleCreated)
                    CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        public MainFrm()
        {
            if (Properties.Settings.Default.StartMinimizedToTray) {
                Visible = false;
                Hide();
            }
            InitializeComponent();
            Log.SetLogComponent(logRichTextBox);
            Log.Notice("Initializing Control Panel");
            Log.Notice("Wnmp Version: " + Application.ProductVersion);
            Log.Notice("Wnmp Directory: " + Program.StartupPath);
            SetupNginx();
            SetupMariaDB();
            /*Updated By Nash-x9:Fixd when startup,php will start with default version.*/
            if (Properties.Settings.Default.PHPVersion == "Default")
            {
                SetupPHP();
            }
            else
            {
                SetupCustomPHP();
            }
            /*Updated End*/
            SetupConfigAndLogMenuStrips();
            SetupTrayMenu();
            updater = new WnmpUpdater(this);
            CreateWnmpCertificate();

            if (Properties.Settings.Default.StartMinimizedToTray) {
                visiblecore = false;
                base.SetVisibleCore(false);
            }

            if (Properties.Settings.Default.StartNginxOnLaunch) {
                Nginx.Start();
            }

            if (Properties.Settings.Default.StartMariaDBOnLaunch) {
                MariaDB.Start();
            }

            if (Properties.Settings.Default.StartPHPOnLaunch) {
                PHP.Start();
            }
        }

        /* Menu */

        /* File */

        private void WnmpOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionsFrm(this);
            optionForm.ShowDialog(this);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /* Applications Group Box */

        private void CtxButton(object sender, ContextMenuStrip contextMenuStrip)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip.Show(ptLowerLeft);
        }

        private void NginxStartButton_Click(object sender, EventArgs e)
        {
            Nginx.Start();
        }

        private void MariadbStartButton_Click(object sender, EventArgs e)
        {
            MariaDB.Start();
        }

        private void PhpStartButton_Click(object sender, EventArgs e)
        {
            PHP.Start();
        }

        private void NginxStopButton_Click(object sender, EventArgs e)
        {
            Nginx.Stop();
        }

        private void MariadbStopButton_Click(object sender, EventArgs e)
        {
            MariaDB.Stop();
        }

        private void PhpStopButton_Click(object sender, EventArgs e)
        {
            PHP.Stop();
        }

        private void NginxRestartButton_Click(object sender, EventArgs e)
        {
            Nginx.Restart();
        }

        private void MariadbRestartButton_Click(object sender, EventArgs e)
        {
            MariaDB.Restart();
        }

        private void PhpRestartButton_Click(object sender, EventArgs e)
        {
            PHP.Restart();
        }

        private void NginxConfigButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, NginxConfigContextMenuStrip);
        }

        private void MariadbConfigButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, MariaDBConfigContextMenuStrip);
        }

        private void PhpConfigButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, PHPConfigContextMenuStrip);
        }

        private void NginxLogButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, NginxLogContextMenuStrip);
        }

        private void MariadbLogButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, MariaDBLogContextMenuStrip);
        }

        private void PhpLogButton_Click(object sender, EventArgs e)
        {
            CtxButton(sender, PHPLogContextMenuStrip);
        }

        /* */

        public void StopAll()
        {
            Nginx.Stop();
            MariaDB.Stop();
            PHP.Stop();
        }

        private void StartAllButton_Click(object sender, EventArgs e)
        {
            Nginx.Start();
            MariaDB.Start();
            PHP.Start();
        }

        private void StopAllButton_Click(object sender, EventArgs e)
        {
            StopAll();
        }

        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater.CheckForUpdates();
        }

        private void GetHTTPHeadersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HTTPHeadersFrm httpHeadersFrm = new HTTPHeadersFrm() {
                StartPosition = FormStartPosition.CenterParent
            };
            httpHeadersFrm.Show(this);
        }

        private void HostToIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostToIPFrm hostToIPFrm = new HostToIPFrm() {
                StartPosition = FormStartPosition.CenterParent
            };
            hostToIPFrm.Show(this);
        }

        private void SupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("https://groups.google.com/forum/#!forum/wnmp-users");
        }

        private void WebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("https://wnmp.x64architecture.com");
        }

        private void DonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("https://wnmp.x64architecture.com/contributing");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutFrm = new AboutFrm() {
                StartPosition = FormStartPosition.CenterParent
            };
            aboutFrm.ShowDialog(this);
        }

        private void ReportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("https://github.com/wnmp/wnmp/issues/new");
        }

        private void SetRunningStatusLabel(Label label, bool running)
        {
            if (running) {
                label.Text = "✓";
                label.ForeColor = Color.Green;
            } else {
                label.Text = "X";
                label.ForeColor = Color.DarkRed;
            }
        }

        private void AppsRunningTimer_Tick(object sender, EventArgs e)
        {
            SetRunningStatusLabel(nginxrunning, Nginx.IsRunning());
            SetRunningStatusLabel(phprunning, PHP.IsRunning());
            SetRunningStatusLabel(mariadbrunning, MariaDB.IsRunning());
        }

        private void LocalhostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("http://localhost");
        }

        private void OpenMariaDBShellButton_Click(object sender, EventArgs e)
        {
            MariaDB.OpenShell();
        }

        private void WnmpDirButton_Click(object sender, EventArgs e)
        {
            Misc.StartProcessAsync("explorer.exe", Program.StartupPath);
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Properties.Settings.Default.MinimizeInsteadOfClosing) {
                e.Cancel = true;
                Hide();
            } else {
                Properties.Settings.Default.Save();
            }
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MinimizeToTray == false)
                return;

            if (WindowState == FormWindowState.Minimized)
                Hide();
        }
    }
}
