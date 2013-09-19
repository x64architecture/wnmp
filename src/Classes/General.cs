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
            start_all_Tip.Show("Starts Nginx, PHP-CGI & MariaDB", Program.formInstance.start);
        }

        internal static void stop_MouseHover()
        {
            ToolTip stop_all_Tip = new ToolTip();
            stop_all_Tip.Show("Stops Nginx, PHP-CGI & MariaDB", Program.formInstance.stop);
        }

        internal static void start_Click()
        {
            try
            {
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + " - Starting all applications");
                //Nginx
                Nginx.nginxstart_Click();
                //PHP
                PHP.phpstart_Click();
                //MariaDB
                MariaDB.MariaDBstart_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal static void stop_Click()
        {
            try
            {
                //Nginx
                Nginx.nginxstop_Click();
                //PHP
                PHP.phpstop_Click();
                //MariaDB
                MariaDB.MariaDBstop_Click();
                Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Main]" + " - Stopping all applications");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
