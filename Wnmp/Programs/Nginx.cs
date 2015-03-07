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
using System.Windows.Forms;
using System.Diagnostics;

using Wnmp.Forms;
using Wnmp.Helpers;
using Wnmp.Internals;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to Nginx
    /// </summary>
    class Nginx
    {
        public Main form;
        public Process ps; // Avoid GC
        public ContextMenuStrip cms = new ContextMenuStrip(); // Config button context menu
        public ContextMenuStrip lms = new ContextMenuStrip(); // Log button context menu
        private readonly ToolTip toolTip = new ToolTip(); // ToolTip
        private readonly string NginxExe = Main.StartupPath.Replace(@"\", "/") + "/nginx.exe";

        public Nginx()
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
            ps.StartInfo.CreateNoWindow = true; // Execute with no window
            ps.Start(); // Start the process
        }

        private bool NginxIsRunning()
        {
            Process[] ptcf = Process.GetProcessesByName("nginx");

            return (ptcf.Length == 0);
        }

        public void StartNginx()
        {
            try {
                StartProcess(NginxExe, "");
                Log.wnmp_log_notice("Attempting to start Nginx", Log.LogSection.WNMP_NGINX);
                Common.ToStartedLabel(form.nginxrunning);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        public void StopNginx()
        {
            try {
                StartProcess(NginxExe, "-s stop");
                Log.wnmp_log_notice("Attempting to stop Nginx", Log.LogSection.WNMP_NGINX);
                Common.ToStoppedLabel(form.nginxrunning);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        public void ReloadNginx()
        {
            try {
                if (NginxIsRunning() == true) {
                    StartProcess(NginxExe, "-s reload");
                    Log.wnmp_log_notice("Attempting to reload Nginx", Log.LogSection.WNMP_NGINX);
                } else
                    StartNginx();
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        public void NginxConfig(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cms.Show(ptLowerLeft);
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, Main.StartupPath + "/conf/" + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        public void NginxLog(object sender)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            lms.Show(ptLowerLeft);
        }

        private void lms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Options.settings.Editor, Main.StartupPath + "/logs/" + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }
    }
}
