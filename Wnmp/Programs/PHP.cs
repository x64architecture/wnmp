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
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Forms;
using Wnmp.Helpers;
using Wnmp.Internals;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to PHP
    /// </summary>
    class PHP
    {
        public static Process ps; // Avoid GC
        public static ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public static ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        private static readonly ToolTip toolTip = new ToolTip(); // ToolTip
        private static readonly string pini = String.Format("\"{0}/php/php.ini\"", Main.StartupPath); // Location of php.ini to pass on to php
        private static readonly string PHPExe = Main.StartupPath + "/php/php-cgi.exe";

        private enum Status
        {
            Stopped = 0,
            Started = 1
        }

        private static Status PHPStatus = Status.Stopped;

        /// <summary>
        /// Starts an executable file
        /// </summary>
        public static void startprocess(string p, string args)
        {
            ps = new Process(); // Create process
            ps.StartInfo.FileName = p; // p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; // Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true; // Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true; // Excute with no window
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "2000"); // After 2000 requests php-cgi.exe will kill its process
            if (PHPStatus != Status.Stopped) {
                ps.EnableRaisingEvents = true;
                ps.Exited += ps_Exited; // Were going to have to restart PHP after its process is killed.
            }
            ps.Start(); // Start the process
        }

        static void ps_Exited(object sender, EventArgs e)
        {
            /* The Win-PHP developers thought is was smart to kill php after a certain amount of requests (Probably 500). 
               so we have to restart it once it exits or set 'PHP_FCGI_MAX_REQUESTS' variable to 0. I've looked and people are recommending just to restart it. */
            if (PHPStatus != Status.Stopped)
                startprocess(PHPExe, String.Format("-b localhost:{0} -c {1}", Options.settings.PHPPort, pini));
        }

        public static void php_start_Click(object sender, EventArgs e)
        {
            int i;
            int pp = Options.settings.PHPProcesses;
            int port = Options.settings.PHPPort;

            for (i = 1; i <= pp; i++) {
                startprocess(PHPExe, String.Format("-b localhost:{0} -c {1}", port, pini));
                Log.wnmp_log_notice("Starting PHP " + i + "/" + pp + " On port: " + port, Log.LogSection.WNMP_PHP);
                port++;
            }
            Log.wnmp_log_notice("PHP started", Log.LogSection.WNMP_PHP);

            PHPStatus = Status.Started;
            Common.ToStartedLabel(Program.formInstance.phprunning);
        }

        public static void php_stop_Click(object sender, EventArgs e)
        {
            Log.wnmp_log_notice("Stopping PHP", Log.LogSection.WNMP_PHP);
            PHPStatus = Status.Stopped;
            var phps = Process.GetProcessesByName("php-cgi");
            foreach (var currentProc in phps)
                currentProc.Kill();

            Common.ToStoppedLabel(Program.formInstance.phprunning);
        }

        public static void php_restart_Click(object sender, EventArgs e)
        {
            Log.wnmp_log_notice("Attempting to restart PHP", Log.LogSection.WNMP_PHP);
            // Kill PHP
            PHPStatus = Status.Stopped;
            var phps = Process.GetProcessesByName("php-cgi");
            foreach (var currentProc in phps)
                currentProc.Kill();

            // Start PHP
            php_start_Click(null, null);
        }

        public static void php_start_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Start PHP-CGI", Program.formInstance.php_start);
        }

        public static void php_stop_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Stop PHP-CGI", Program.formInstance.php_stop);
        }

        public static void php_restart_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Restart PHP-CGI", Program.formInstance.php_restart);
        }

        public static void php_cfg_Click(object sender, EventArgs e)
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
            Process.Start(Options.settings.Editor, Main.StartupPath + "/php/" + e.ClickedItem.Text);
        }

        public static void php_log_Click(object sender, EventArgs e)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
            lms.ItemClicked -= lms_ItemClicked;
            lms.ItemClicked += lms_ItemClicked;
        }

        static void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/php/logs/" + e.ClickedItem.Text);
        }
    }
}
