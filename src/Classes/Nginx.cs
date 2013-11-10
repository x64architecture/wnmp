/*
Copyright (C) Kurt Cancemi

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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Permissions;

namespace Wnmp
{
    class Nginx
    {
        public static Process ps; // Avoid GC
        public static int ngxstatus = (int)ProcessStatus.ps.STOPPED;
        public static int NgxStatus { get { return ngxstatus; } }
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public static void startprocess(string p, string args, bool wfe)
        {
            System.Threading.Thread.Sleep(100); //Wait
            ps = new Process(); //Create process
            ps.StartInfo.FileName = p; //p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; //Parameters to pass to program
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Application.StartupPath;
            ps.StartInfo.CreateNoWindow = true; //Excute with no window
            ps.Start(); //Start the process
            if (wfe)
            {
                ps.WaitForExit();
            }
        }

        internal static void ngx_start_Click(object sender, EventArgs e)
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "", false);
                Log.wnmp_log_notice("Attempting to start Nginx", Log.LogSection.WNMP_NGINX);
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
                ngxstatus = (int)ProcessStatus.ps.STARTED;
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        internal static void ngx_stop_Click(object sender, EventArgs e)
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "-s stop", true);
                /* Ensure Nginx gets killed (No leftover useless proccess) */
                Process[] ngx = System.Diagnostics.Process.GetProcessesByName("nginx");
                foreach (Process currentProc in ngx)
                {
                    currentProc.Kill();
                }
                Log.wnmp_log_notice("Attempting to stop Nginx", Log.LogSection.WNMP_NGINX);
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
                ngxstatus = (int)ProcessStatus.ps.STOPPED;
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        internal static void ngx_reload_Click(object sender, EventArgs e)
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "-s reload", false);
                Log.wnmp_log_notice("Attempting to reload Nginx", Log.LogSection.WNMP_NGINX);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_NGINX);
            }
        }

        internal static void ngx_stop_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_stop_Tip = new ToolTip();
            nginx_stop_Tip.Show("Stop Nginx", Program.formInstance.ngx_stop);
        }

        internal static void ngx_start_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_start_Tip = new ToolTip();
            nginx_start_Tip.Show("Start Nginx", Program.formInstance.ngx_start);
        }
        internal static void ngx_reload_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_reload_Tip = new ToolTip();
            nginx_reload_Tip.Show("Reloads Nginx configuration without restart", Program.formInstance.ngx_reload);
        }
    }
}
