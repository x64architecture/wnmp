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
    public static class General
    {
        internal static void start_MouseHover()
        {
            ToolTip start_all_Tip = new ToolTip();
            start_all_Tip.Show("Starts Nginx, PHP-CGI & MySQL", Program.formInstance.start);
        }

        internal static void stop_MouseHover()
        {
            ToolTip stop_all_Tip = new ToolTip();
            stop_all_Tip.Show("Stops Nginx, PHP-CGI & MySQL", Program.formInstance.stop);
        }
        public static void startprocess(string p, string args, bool shellexc, bool redirectso)
        {
            System.Threading.Thread.Sleep(100); //Wait
            System.Diagnostics.Process ps = new System.Diagnostics.Process(); //Create process
            ps.StartInfo.FileName = p; //p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; //Parameters to pass to program
            ps.StartInfo.UseShellExecute = shellexc;
            ps.StartInfo.RedirectStandardOutput = redirectso; //Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Application.StartupPath;
            ps.StartInfo.CreateNoWindow = true; //Excute with no window
            ps.Start(); //Start the process
        }
        internal static void start_Click()
        {
            string[] prgs = new string[3];
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/php/php-cgi.exe";
            prgs[2] = @Application.StartupPath + @"/mariadb/bin/mysqld.exe";
            try
            {
                //Nginx
                startprocess(prgs[0], "", false, true);
                //PHP
                startprocess(prgs[1], "-b localhost:9000", false, true);
                //MariaDB
                startprocess(prgs[2], "", false, true);
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + " - Starting all applications");
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
                Program.formInstance.mariadbrunning.Text = "\u221A";
                Program.formInstance.mariadbrunning.ForeColor = Color.Green;
                Program.formInstance.phprunning.Text = "\u221A";
                Program.formInstance.phprunning.ForeColor = Color.Green;
                Nginx.ngxstatus = (int)ProcessStatus.ps.STARTED;
                MariaDB.mariadbstatus = (int)ProcessStatus.ps.STARTED;
                PHP.phpstatus = (int)ProcessStatus.ps.STARTED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void stop_Click()
        {
            string[] prgs = new string[2];
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/mariadb/bin/mysqladmin.exe";
            try
            {
                //Nginx
                startprocess(prgs[0], "-s stop", false, true);
                //PHP
                try
                {
                    Process[] phps = System.Diagnostics.Process.GetProcessesByName("php-cgi");
                    foreach (Process currentProc in phps)
                    {
                        currentProc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                //MariaDB
                startprocess(prgs[1], "-u root -p shutdown", true, false);
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
                Program.formInstance.mariadbrunning.Text = "X";
                Program.formInstance.mariadbrunning.ForeColor = Color.DarkRed;
                Program.formInstance.phprunning.Text = "X";
                Program.formInstance.phprunning.ForeColor = Color.DarkRed;
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + " - Stopping all applications");
                Nginx.ngxstatus = (int)ProcessStatus.ps.STOPPED;
                MariaDB.mariadbstatus = (int)ProcessStatus.ps.STOPPED;
                PHP.phpstatus = (int)ProcessStatus.ps.STOPPED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
