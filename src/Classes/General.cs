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

        internal static void start_Click(object sender, EventArgs e)
        {
            try
            {
                Log.wnmp_log_notice("Attempting to start all the applications", Log.LogSection.WNMP_MAIN);
                // Nginx
                Nginx.ngx_start_Click(sender, e);
                // PHP
                PHP.php_start_Click(sender, e);
                // MariaDB
                MariaDB.mdb_start_Click(sender, e);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }

        internal static void stop_Click(object sender, EventArgs e)
        {
            try
            {
                // Nginx
                Nginx.ngx_stop_Click(sender, e);
                // PHP
                PHP.php_stop_Click(sender, e);
                // MariaDB
                MariaDB.mdb_stop_Click(sender, e);
                Log.wnmp_log_notice("Attempting to stop all the applications", Log.LogSection.WNMP_MAIN);
            }
            catch (Exception ex)
            {
                Log.wnmp_log_error(ex.Message, Log.LogSection.WNMP_MAIN);
            }
        }
    }
}
