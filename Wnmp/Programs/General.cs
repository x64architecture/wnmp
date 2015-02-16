/*
Copyright (c) Kurt Cancemi 2012-2015

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
using System.Windows.Forms;

using Wnmp.Helpers;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to the general applications (ex. start all apps)
    /// </summary>
    public static class General
    {
        private static readonly ToolTip toolTip = new ToolTip();

        public static void start_MouseHover()
        {
            toolTip.Show("Starts Nginx, PHP-CGI & MariaDB", Program.formInstance.start);
        }

        public static void stop_MouseHover()
        {
            toolTip.Show("Stops Nginx, PHP-CGI & MariaDB", Program.formInstance.stop);
        }

        public static void start_Click(object sender, EventArgs e)
        {
            Log.wnmp_log_notice("Attempting to start all the applications", Log.LogSection.WNMP_MAIN);
            // Nginx
            Nginx.ngx_start_Click(sender, e);
            // PHP
            PHP.php_start_Click(sender, e);
            // MariaDB
            MariaDB.mdb_start_Click(sender, e);
        }

        public static void stop_Click(object sender, EventArgs e)
        {
            Log.wnmp_log_notice("Attempting to stop all the applications", Log.LogSection.WNMP_MAIN);
            // Nginx
            Nginx.ngx_stop_Click(sender, e);
            // PHP
            PHP.php_stop_Click(sender, e);
            // MariaDB
            MariaDB.mdb_stop_Click(sender, e);
        }
    }
}
