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
    class PHP
    {
        internal static void phpstart_Click()
        {
            try
            {
                System.Diagnostics.Process start = new System.Diagnostics.Process();
                start.StartInfo.FileName = @Application.StartupPath + @"/php/php-cgi.exe";
                start.StartInfo.Arguments = "-b localhost:9000";
                start.StartInfo.RedirectStandardError = true;
                start.StartInfo.RedirectStandardOutput = true;
                start.StartInfo.UseShellExecute = false;
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.StartInfo.CreateNoWindow = true;
                start.Start();
                start.CloseMainWindow();
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp PHP]" + " - Attempting to start PHP");
                Program.formInstance.phprunning.Text = "\u221A";
                Program.formInstance.phprunning.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void phpstop_Click()
        {
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
            Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp PHP]" + " - Attempting to stop PHP");
            Program.formInstance.phprunning.Text = "X";
            Program.formInstance.phprunning.ForeColor = Color.DarkRed;
        }
        internal static void phpstart_MouseHover()
        {
            ToolTip mysql_start_Tip = new ToolTip();
            mysql_start_Tip.Show("Start PHP-CGI", Program.formInstance.phpstart);
        }

        internal static void phpstop_MouseHover()
        {
            ToolTip mysql_stop_Tip = new ToolTip();
            mysql_stop_Tip.Show("Stop PHP-CGI", Program.formInstance.phpstop);
        }
    }
}
