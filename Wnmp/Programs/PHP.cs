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
        public Main form;
        public Process ps; // Avoid GC
        public ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        private readonly ToolTip toolTip = new ToolTip(); // ToolTip
        private readonly string pini = String.Format("\"{0}/php/php.ini\"", Main.StartupPath); // Location of php.ini to pass on to php
        private readonly string PHPExe = Main.StartupPath + "/php/php-cgi.exe";

        public PHP()
        {
            cms.ItemClicked += cms_ItemClicked;
            lms.ItemClicked += lms_ItemClicked;
        }

        /// <summary>
        /// Starts an executable file
        /// </summary>
        private void StartProcess(string p, string args)
        {
            ps = new Process(); // Create process
            ps.StartInfo.FileName = p; // p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; // Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true; // Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true; // Excute with no window
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
            ps.Start();
        }

        private void KillPHP()
        {
            try {
                Process[] phps = Process.GetProcessesByName("php-cgi");
                foreach (Process currentProc in phps)
                    currentProc.Kill();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_PHP);
            }
        }
        public void StartPHP()
        {
            int i;
            int ProcessCount = Options.settings.PHPProcesses;
            int port = Options.settings.PHPPort;

            try
            {
                for (i = 1; i <= ProcessCount; i++)
                {
                    StartProcess(PHPExe, String.Format("-b localhost:{0} -c {1}", port, pini));
                    Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " On port: " + port, Log.LogSection.WNMP_PHP);
                    port++;
                }
                Log.wnmp_log_notice("PHP started", Log.LogSection.WNMP_PHP);

                Common.ToStartedLabel(form.phprunning);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_PHP);
            }
        }

        public void StopPHP()
        {
            KillPHP();
            Log.wnmp_log_notice("Stopped PHP", Log.LogSection.WNMP_PHP);
            Common.ToStoppedLabel(form.phprunning);
        }

        public void RestartPHP()
        {
            StopPHP();
            StartPHP();
            Log.wnmp_log_notice("Restarted PHP", Log.LogSection.WNMP_PHP);
        }

        public void PHPConfig(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cms.Show(ptLowerLeft);
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/php/" + e.ClickedItem.Text);
        }

        public void PHPLog(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
        }

        private void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(Options.settings.Editor, Main.StartupPath + "/php/logs/" + e.ClickedItem.Text);
        }
    }
}
