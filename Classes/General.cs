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
        internal static void start_Click()
        {
            string[] prgs = new string[3];
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/php/php-cgi.exe";
            prgs[2] = @Application.StartupPath + @"/mariadb/bin/mysqld.exe";
            try
            {
                //Create process
                System.Diagnostics.Process nginxs = new System.Diagnostics.Process();
                //arr4[0] is path and file name of command to run
                nginxs.StartInfo.FileName = prgs[0].ToString();
                nginxs.StartInfo.UseShellExecute = false;
                //Set output of program to be written to process output stream
                nginxs.StartInfo.RedirectStandardOutput = true;
                nginxs.StartInfo.WorkingDirectory = Application.StartupPath;
                nginxs.StartInfo.CreateNoWindow = true; //Excute with no window
                nginxs.Start(); //Start the process
                //PHP
                System.Threading.Thread.Sleep(100); //Wait
                System.Diagnostics.Process phps = new System.Diagnostics.Process(); //Create process
                phps.StartInfo.FileName = prgs[1].ToString(); //arr4[1] is path and file name of command to run
                phps.StartInfo.Arguments = "-b localhost:9000"; //Parameters to pass to program
                phps.StartInfo.UseShellExecute = false;
                phps.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                phps.StartInfo.WorkingDirectory = Application.StartupPath;
                phps.StartInfo.CreateNoWindow = true; //Excute with no window
                phps.Start(); //Start the process
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = prgs[2].ToString();
                mariadb.StartInfo.UseShellExecute = false;
                mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.StartInfo.CreateNoWindow = true; //Excute with no window
                mariadb.Start(); //Start the process
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Starting all applications");
                Program.formInstance.nginxrunning.Text = "\u221A";
                Program.formInstance.nginxrunning.ForeColor = Color.Green;
                Program.formInstance.mariadbrunning.Text = "\u221A";
                Program.formInstance.mariadbrunning.ForeColor = Color.Green;
                Program.formInstance.phprunning.Text = "\u221A";
                Program.formInstance.phprunning.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void stop_Click()
        {
            string[] prgs = new string[3];
            prgs[0] = @Application.StartupPath + @"/nginx.exe";
            prgs[1] = @Application.StartupPath + @"/php/php-cgi.exe";
            prgs[2] = @Application.StartupPath + @"/mariadb/bin/mysqladmin.exe";
            try
            {
                //Create process
                System.Diagnostics.Process nginxs = new System.Diagnostics.Process();
                //arr4[0] is path and file name of command to run
                nginxs.StartInfo.FileName = prgs[0].ToString();
                nginxs.StartInfo.Arguments = "-s stop";
                nginxs.StartInfo.UseShellExecute = false;
                //Set output of program to be written to process output stream
                nginxs.StartInfo.RedirectStandardOutput = true;
                nginxs.StartInfo.WorkingDirectory = Application.StartupPath;
                nginxs.StartInfo.CreateNoWindow = true; //Execute with no window
                nginxs.Start(); //Start the process
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
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqladmin.exe";
                mariadb.StartInfo.Arguments = "-u root -p shutdown";
                mariadb.StartInfo.UseShellExecute = true;
                mariadb.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.Start(); //Start the process
                Program.formInstance.nginxrunning.Text = "X";
                Program.formInstance.nginxrunning.ForeColor = Color.DarkRed;
                Program.formInstance.mariadbrunning.Text = "X";
                Program.formInstance.mariadbrunning.ForeColor = Color.DarkRed;
                Program.formInstance.phprunning.Text = "X";
                Program.formInstance.phprunning.ForeColor = Color.DarkRed;
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + "     Stopping all applications");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
