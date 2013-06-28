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
        internal static void mysqlstart_Click()
        {
            try
            {
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqld.exe";
                mariadb.StartInfo.UseShellExecute = false;
                mariadb.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.StartInfo.CreateNoWindow = true;
                mariadb.Start(); //Start the process
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "            Attempting to start MariaDB");
                Program.formInstance.mariadbrunning.Text = "\u221A";
                Program.formInstance.mariadbrunning.ForeColor = Color.Green;
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
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "            Attempting to stop MariaDB");
                System.Diagnostics.Process mariadb = new System.Diagnostics.Process(); //Create process
                mariadb.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqladmin.exe";
                mariadb.StartInfo.Arguments = "-u root -p shutdown";
                mariadb.StartInfo.UseShellExecute = true;
                mariadb.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadb.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadb.Start(); //Start the process
                Program.formInstance.mariadbrunning.Text = "X";
                Program.formInstance.mariadbrunning.ForeColor = Color.DarkRed;
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
                //MariaDB
                System.Diagnostics.Process mariadbs = new System.Diagnostics.Process(); //Create process
                mariadbs.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysqld.exe";
                mariadbs.StartInfo.UseShellExecute = false;
                mariadbs.StartInfo.RedirectStandardOutput = true; //Set output of program to be written to process output stream
                mariadbs.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadbs.StartInfo.CreateNoWindow = true;
                mariadbs.Start(); //Start the process
                System.Threading.Thread.Sleep(100); //Wait
                //MariaDB Shell
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [mariadb]" + "             Attempting to start MariaDB shell");
                System.Diagnostics.Process mariadbsh = new System.Diagnostics.Process(); //Create process
                mariadbsh.StartInfo.FileName = @Application.StartupPath + @"/mariadb\bin\mysql.exe";
                mariadbsh.StartInfo.Arguments = "-u root -p";
                mariadbsh.StartInfo.UseShellExecute = true;
                mariadbsh.StartInfo.RedirectStandardOutput = false; //Set output of program to be written to process output stream
                mariadbsh.StartInfo.WorkingDirectory = Application.StartupPath;
                mariadbsh.Start(); //Start the process
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
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
