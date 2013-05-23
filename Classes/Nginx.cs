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
        internal static void nginxreload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.Arguments = "-s reload";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to reload Nginx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void nginxstop_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.Arguments = "-s stop";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to stop Nginx");
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void nginxstart_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process nginx = new System.Diagnostics.Process(); //Create process
                nginx.StartInfo.FileName = @Application.StartupPath + "/nginx.exe";
                nginx.StartInfo.UseShellExecute = false;
                nginx.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                nginx.StartInfo.WorkingDirectory = Application.StartupPath;
                nginx.StartInfo.CreateNoWindow = true;
                nginx.Start(); //Start the process
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [nginx]" + "                  Attempting to start Nginx");
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void nginxreload_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_reload_Tip = new ToolTip();
            nginx_reload_Tip.Show("Reloads Nginx configuration without restart", Program.formInstance.nginxreload);
        }

        internal static void nginxstop_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_stop_Tip = new ToolTip();
            nginx_stop_Tip.Show("Stop Nginx", Program.formInstance.nginxstop);
        }

        internal static void nginxstart_MouseHover(object sender, EventArgs e)
        {
            ToolTip nginx_start_Tip = new ToolTip();
            nginx_start_Tip.Show("Start Nginx", Program.formInstance.nginxstart);
        }
    }
}
