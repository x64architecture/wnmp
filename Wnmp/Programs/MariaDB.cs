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
        public static Process ps; // Avoid GC
        public static ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public static ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        public static readonly ToolTip toolTip = new ToolTip(); // ToolTip
        private static string mysqlExe = Main.StartupPath + "/mariadb/bin/mysql.exe";
        private static string mysqldExe = Main.StartupPath + "/mariadb/bin/mysqld.exe";
        private static string mysqladminExe = Main.StartupPath + "/mariadb/bin/mysqladmin.exe";

        /// <summary>
        /// Starts an executable file
        /// </summary>
        public static void startprocess(string p, string args, bool wfe)
        {
            ps = new Process(); // Create process
            ps.StartInfo.FileName = p; // p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; // Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true; // Excute with no window
            ps.Start(); // Start the process
            if (wfe)
                ps.WaitForExit();
        }

        public static void mdb_start_Click(object sender, EventArgs e)
        {
            startprocess(mysqldExe, "", false);
            Log.wnmp_log_notice("Attempting to start MariaDB", Log.LogSection.WNMP_MARIADB);
            Common.ToStartedLabel(Program.formInstance.mariadbrunning);
        }

        public static void mdb_stop_Click(object sender, EventArgs e)
        {
            // MariaDB
            Log.wnmp_log_notice("Attempting to stop MariaDB", Log.LogSection.WNMP_MARIADB);
            Process.Start(mysqladminExe, "-u root -p shutdown");
            Common.ToStoppedLabel(Program.formInstance.mariadbrunning);
        }

        public static void mdb_restart_Click(object sender, EventArgs e)
        {
            // MariaDB
            Log.wnmp_log_notice("Attempting to restart MariaDB", Log.LogSection.WNMP_MARIADB);
            var thread = new Thread(mdb_restart);
            thread.Start();
            Common.ToStartedLabel((Program.formInstance.mariadbrunning));
        }

        private static void mdb_restart()
        {
            startprocess(mysqladminExe, "-u root -p shutdown", true);
            startprocess(mysqldExe, "", false);
        }
        private static bool MariaDBIsRunning()
        {
            var ptcf = Process.GetProcessesByName("mysqld");

            return ptcf.Length == 0;
        }
        public static void mdb_shell_Click(object sender, EventArgs e)
        {
            Log.wnmp_log_notice("Attempting to start MariaDB shell", Log.LogSection.WNMP_MARIADB);
            // MariaDB
            if (!MariaDBIsRunning())
                startprocess(mysqldExe, "", false);
            // MariaDB Shell
            Process.Start(mysqlExe, "-u root -p");
        }

        public static void mdb_start_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Start MariaDB", Program.formInstance.mdb_start);
        }

        public static void mdb_stop_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Stop MariaDB", Program.formInstance.mdb_stop);
        }

        public static void mdb_shell_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Open MariaDB Shell", Program.formInstance.mdb_shell);
        }

        public static void mdb_restart_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Restart MariaDB", Program.formInstance.mdb_restart);
        }

        public static void mdb_cfg_Click(object sender, EventArgs e)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cms.Show(ptLowerLeft);
            cms.ItemClicked -= cms_ItemClicked;
            cms.ItemClicked += cms_ItemClicked;
        }

        static void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/mariadb/data/" + e.ClickedItem.Text);
        }

        public static void mdb_log_Click(object sender, EventArgs e)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
            lms.ItemClicked -= cms_ItemClicked;
            lms.ItemClicked += cms_ItemClicked;
        }

        static void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/mariadb/data/" + e.ClickedItem.Text);
        }
    }
}
