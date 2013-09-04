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

namespace Wnmp
{
    class Nginx
    {
        public static Process ps; // Avoid GC
        public static int ngxstatus = (int)ProcessStatus.ps.STOPPED;
        public static void startprocess(string p, string args)
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
        }
        internal static void nginxreload_Click()
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "-s reload");
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Nginx]" + " - Attempting to reload Nginx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void nginxstop_Click()
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "-s stop");
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Nginx]" + " - Attempting to stop Nginx");
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
                ngxstatus = (int)ProcessStatus.ps.STOPPED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void nginxstart_Click()
        {
            try
            {
                startprocess(@Application.StartupPath + "/nginx.exe", "");
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Nginx]" + " - Attempting to start Nginx");
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
                ngxstatus = (int)ProcessStatus.ps.STARTED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public static int NgxStatus { get { return ngxstatus; } }
        internal static void nginxreload_MouseHover()
        {
            ToolTip nginx_reload_Tip = new ToolTip();
            nginx_reload_Tip.Show("Reloads Nginx configuration without restart", Program.formInstance.nginxreload);
        }

        internal static void nginxstop_MouseHover()
        {
            ToolTip nginx_stop_Tip = new ToolTip();
            nginx_stop_Tip.Show("Stop Nginx", Program.formInstance.nginxstop);
        }

        internal static void nginxstart_MouseHover()
        {
            ToolTip nginx_start_Tip = new ToolTip();
            nginx_start_Tip.Show("Start Nginx", Program.formInstance.nginxstart);
        }
    }
}
