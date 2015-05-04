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
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Forms;
using Wnmp.Helpers;
using Wnmp.Internals;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to MariaDB
    /// </summary>
    class MariaDB
    {
        public Main form;
        public Process ps; // Avoid GC
        public ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        public readonly ToolTip toolTip = new ToolTip(); // ToolTip
        private string mysqlExe = Main.StartupPath + "/mariadb/bin/mysql.exe";
        private string mysqldExe = Main.StartupPath + "/mariadb/bin/mysqld.exe";
        private string mysqladminExe = Main.StartupPath + "/mariadb/bin/mysqladmin.exe";
        private string mdb_pidfile = Main.StartupPath + "/mariadb/data/" + Environment.MachineName + ".pid";

        public MariaDB()
        {
            cms.ItemClicked += cms_ItemClicked;
            lms.ItemClicked += lms_ItemClicked;
        }

        /// <summary>
        /// Starts an executable file
        /// </summary>
        public void startprocess(string p, string args)
        {
            ps = new Process(); // Create process
            ps.StartInfo.FileName = p; // p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; // Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true; // Execute with no window
            ps.Start(); // Start the process
        }

        private void KillMariaDB()
        {
            try
            {
                Process[] mdbs = Process.GetProcessesByName("mysqld");
                foreach (Process currentProc in mdbs)
                    currentProc.Kill();
                /* Clean up PID file */
                if (File.Exists(mdb_pidfile))
                    File.Delete(mdb_pidfile);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        private bool MariaDBIsRunning()
        {
            Process[] ptcf = Process.GetProcessesByName("mysqld");

            return (ptcf.Length == 0);
        }

        public void StartMariaDB()
        {
            try {
                startprocess(mysqldExe, "");
                Log.wnmp_log_notice("Attempting to start MariaDB", Log.LogSection.WNMP_MARIADB);
                Common.ToStartedLabel(form.mariadbrunning);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        public void StopMariaDB()
        {
            try {
                KillMariaDB();
                Log.wnmp_log_notice("Attempting to stop MariaDB", Log.LogSection.WNMP_MARIADB);
                Common.ToStoppedLabel(form.mariadbrunning);
            } catch(Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        public void RestartMariaDB()
        {
            try {
                if (MariaDBIsRunning() == true)
                    KillMariaDB();
                startprocess(mysqldExe, "");
                Log.wnmp_log_notice("Restarted MariaDB", Log.LogSection.WNMP_MARIADB);
                Common.ToStartedLabel(form.mariadbrunning);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }
        public void StartMDBShell()
        {
            // MariaDB
            if (MariaDBIsRunning() == false)
                StartMariaDB();
            try {
                // MariaDB Shell
                Process.Start(mysqlExe, "-u root -p");
                Log.wnmp_log_notice("Started MariaDB shell", Log.LogSection.WNMP_MARIADB);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        public void MariaDBConfig(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cms.Show(ptLowerLeft);
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, Main.StartupPath + "/mariadb/" + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }

        public void MariaDBLog(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
        }

        public void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, Main.StartupPath + "/mariadb/data/" + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MARIADB);
            }
        }
    }
}
