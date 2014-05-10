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
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Wnmp.Forms;
using Wnmp.Programs;
using Wnmp.Internals;

namespace Wnmp.Helpers
{
    /// <summary>
    /// Additional functions for the Main form
    /// </summary>
    class MainHelper
    {
        #region checkforapps
        /// <summary>
        /// Checks if Nginx, MariaDB, and PHP exist in the Wnmp directory
        /// </summary>
        private static void checkforapps()
        {
            Log.wnmp_log_notice("Checking for applications", Log.LogSection.WNMP_MAIN);
            if (!File.Exists(Application.StartupPath + "/nginx.exe"))
                Log.wnmp_log_error("Error: Nginx Not Found", Log.LogSection.WNMP_NGINX);

            if (!Directory.Exists(Application.StartupPath + "/mariadb"))
                Log.wnmp_log_error("Error: MariaDB Not Found", Log.LogSection.WNMP_MARIADB);

            if (!Directory.Exists(Application.StartupPath + "/php"))
                Log.wnmp_log_error("Error: PHP Not Found", Log.LogSection.WNMP_PHP);
        }
        #endregion checkforapps

        internal static void DoStartup()
        {
            Log.wnmp_log_notice("Control Panel Version: " + Main.GetCPVER, Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice("Wnmp Version: " + Application.ProductVersion, Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice(OSVersionInfo.WindowsVersionString(), Log.LogSection.WNMP_MAIN);
            Log.wnmp_log_notice("Wnmp Directory: " + Application.StartupPath, Log.LogSection.WNMP_MAIN);
            checkforapps();
            Log.wnmp_log_notice("Wnmp ready to go!", Log.LogSection.WNMP_MAIN);

            if (Options.settings.Startallapplicationsatlaunch)
                General.start_Click(null, null);

            DirFiles("/conf", "*.conf", Nginx.cms);
            DirFiles("/mariadb", "my.ini", MariaDB.cms);
            DirFiles("/php", "php.ini", PHP.cms);
            DirFiles("/logs", "*.log", Nginx.lms);
            DirFiles("/mariadb/data", "*.log", MariaDB.lms);
            DirFiles("/php/logs", "*.log", PHP.lms);

            if (Options.settings.Autocheckforupdates)
                Updater.DoDateEclasped();
        }

        /// <summary>
        /// Adds configuration files to the Config buttons context menu strip
        /// </summary>
        private static void DirFiles(string path, string GetFiles, ContextMenuStrip cms)
        {
            var dinfo = new DirectoryInfo(Main.StartupPath + path);
            if (!dinfo.Exists)
                return;
            var Files = dinfo.GetFiles(GetFiles);
            foreach (var file in Files)
            {
                cms.Items.Add(file.Name, null);
            }
        }

        /// <summary>
        /// Sets up the timer to check if the applications are running
        /// </summary>
        private static void DoTimer()
        {
            CheckIfAppsAreRunning(); // First we check at startup
            Timer timer = new Timer();
            timer.Interval = 30000; // 30 seconds
            timer.Tick += CheckIfAppsAreRunningTimer_Tick;
            timer.Start();
        }

        private static void CheckIfAppsAreRunningTimer_Tick(object sender, System.EventArgs e)
        {
            CheckIfAppsAreRunning();
        }

        #region CheckIfRunning
        /// <summary>
        /// Checks if Nginx, MariaDB or PHP is running
        /// </summary>
        internal static void CheckIfAppsAreRunning()
        {
            if (check_if_running("nginx"))
            {
                Common.ToStartedLabel(Program.formInstance.nginxrunning);
            }
            else
            {
                Common.ToStoppedLabel(Program.formInstance.nginxrunning);
            }
            if (check_if_running("mysqld"))
            {
                Common.ToStartedLabel(Program.formInstance.mariadbrunning);
            }
            else
            {
                Common.ToStoppedLabel(Program.formInstance.mariadbrunning);
            }
            if (check_if_running("php-cgi"))
            {
                Common.ToStartedLabel(Program.formInstance.phprunning);
            }
            else
            {
                Common.ToStoppedLabel(Program.formInstance.phprunning);
            }
        }

        private static bool check_if_running(string application)
        {
            var _Process = Process.GetProcessesByName(application);
            return _Process.Length != 0;
        }
        #endregion

        private static bool IsFirstRun()
        {
            return (Options.settings.Firstrun);
        }

        /// <summary>
        /// Generates a public and private keypair the first time Wnmp is launched
        /// </summary>
        internal static void FirstRun()
        {
            if (IsFirstRun())
            {
                if (!Directory.Exists(Main.StartupPath + "/conf"))
                {
                    Directory.CreateDirectory(Main.StartupPath + "/conf");
                }
                File.WriteAllBytes(Main.StartupPath + "/CertGen.exe", Properties.Resources.CertGen);
                using (var ps = new Process())
                {
                    ps.StartInfo.FileName = Main.StartupPath + "/CertGen.exe";
                    ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Start();
                    ps.WaitForExit();
                    Common.DeleteFile(Main.StartupPath + "/CertGen.exe");
                    Options.settings.Firstrun = false;
                    Options.settings.UpdateSettings();
                }
            }
        }

    }
}