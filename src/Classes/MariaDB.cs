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
using System.Xml;

namespace Wnmp
{
    class MariaDB
    {
        public static Process ps; // Avoid GC
        public static int mariadbstatus = (int)ProcessStatus.ps.STOPPED;
        public static void startprocess(string p, string args, bool shellexc, bool redirectso, bool wfe)
        {
            System.Threading.Thread.Sleep(100); //Wait
            ps = new Process(); //Create process
            ps.StartInfo.FileName = p; //p is the path and file name of the file to run
            ps.StartInfo.Arguments = args; //Parameters to pass to program
            ps.StartInfo.UseShellExecute = shellexc;
            ps.StartInfo.RedirectStandardOutput = redirectso; //Set output of program to be written to process output stream
            ps.StartInfo.WorkingDirectory = Application.StartupPath;
            ps.StartInfo.CreateNoWindow = true; //Excute with no window
            ps.Start(); //Start the process
            if (wfe)
            {
                ps.WaitForExit();
            }
        }
        internal static void mysqlstart_Click()
        {
            try
            {
                startprocess(@Application.StartupPath + @"\mariadb\bin\mysqld.exe", "", false, true, false);
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp MariaDB]" + " - Attempting to start MariaDB");
                Program.formInstance.mariadbrunning.Text = "\u221A";
                Program.formInstance.mariadbrunning.ForeColor = Color.Green;
                mariadbstatus = (int)ProcessStatus.ps.STARTED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        internal static void mysqlstop_Click()
        {
            try
            {
                //MariaDB
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp MariaDB]" + " - Attempting to stop MariaDB");
                startprocess(@Application.StartupPath + @"\mariadb\bin\mysqladmin.exe", "-u root -p shutdown", true, false, true);

                /* Ensure MariaDB gets killed (No leftover useless proccess) */
                Process[] ngx = System.Diagnostics.Process.GetProcessesByName("mysqld");
                foreach (Process currentProc in ngx)
                {
                    currentProc.Kill();
                }
                Program.formInstance.mariadbrunning.Text = "X";
                Program.formInstance.mariadbrunning.ForeColor = Color.DarkRed;
                mariadbstatus = (int)ProcessStatus.ps.STOPPED;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        internal static void opnmysqlshell_Click()
        {
            try
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp MariaDB]" + " - Attempting to start MariaDB shell");
                //MariaDB
                if (MariaDBStatus != 0)
                {
                    startprocess(@Application.StartupPath + @"\mariadb\bin\mysqld.exe", "", false, true, false);
                }
                //MariaDB Shell
                startprocess(@Application.StartupPath + @"\mariadb\bin\mysql.exe", "-u root -p", true, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public static int MariaDBStatus { get { return mariadbstatus; } }
        internal static void mysqlstart_MouseHover()
        {
            ToolTip mysql_start_Tip = new ToolTip();
            mysql_start_Tip.Show("Start MySQL", Program.formInstance.mysqlstart);
        }
        internal static void mysqlstop_MouseHover()
        {
            ToolTip mysql_stop_Tip = new ToolTip();
            mysql_stop_Tip.Show("Stop MySQL", Program.formInstance.mysqlstop);
        }
        internal static void opnmysqlshell_MouseHover()
        {
            ToolTip mysql_opnshell_Tip = new ToolTip();
            mysql_opnshell_Tip.Show("Open MySQL Shell", Program.formInstance.opnmysqlshell);
        }
        internal static void mysqlhelp_Click()
        {

            MessageBox.Show("The default login for MySQL/phpMyAdmin is:" + "\n" + "Username: root" + "\n" + "Password: password");
        }
    }
}
