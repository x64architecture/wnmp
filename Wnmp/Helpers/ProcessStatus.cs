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
using System.Timers;
using System.Diagnostics;
using System.Security.Permissions;
using Wnmp.Programs;
using Wnmp.Helpers;

namespace Wnmp.Helpers
{
    public class ProcessStatus
    {
        internal enum ps
        {
            STOPPED,
            STARTED
        }

        public static void timer()
        {
            cfc = new Timer();
            cfc.Elapsed += new ElapsedEventHandler(OnTimer);
            cfc.Interval = 5000;
            cfc.Enabled = true;
        }

        private static Timer cfc;
        public delegate void Action();
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public static void OnTimer(Object source, ElapsedEventArgs e)
        {
            int ngxfails = 0;
            int mariadbfails = 0;
            int phpfails = 0;
            switch (Nginx.NgxStatus)
            {
                case (int)ProcessStatus.ps.STARTED:
                    {
                        if (ngxfails <= 10) // If Nginx fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("nginx") == false)
                            {
                                Nginx.startprocess(Main.StartupPath + "/nginx.exe", "", false);
                                Log.wnmp_log_error("Attempting to restart crashed Nginx", Log.LogSection.WNMP_NGINX);
                                ngxfails++;
                            }
                        }
                        break;
                    }
                case (int)ProcessStatus.ps.STOPPED: ngxfails = 0; break;
            }
            switch (MariaDB.MariaDBStatus)
            {
                case (int)ProcessStatus.ps.STARTED:
                    {
                        if (mariadbfails <= 10) // If MariaDB fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("mariadb") == false)
                            {
                                MariaDB.startprocess(Main.StartupPath + "/mariadb/bin/mysqld.exe", "", false, true, false);
                                Log.wnmp_log_error("Attempting to restart crashed MariaDB", Log.LogSection.WNMP_MARIADB);
                                mariadbfails++;
                            }
                        }
                        break;
                    }
                case (int)ProcessStatus.ps.STOPPED: mariadbfails = 0; break;
            }
            switch (PHP.PHPStatus)
            {
                case (int)ProcessStatus.ps.STARTED:
                    {
                        if (phpfails <= 10) // If PHP fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("php-cgi") == false)
                            {
                                PHP.startprocess(Main.StartupPath + "/php/php-cgi.exe", "-b localhost:9000");
                                Log.wnmp_log_error("Attempting to restart crashed PHP", Log.LogSection.WNMP_PHP);
                                phpfails++;
                            }
                        }
                        break;
                    }
                case (int)ProcessStatus.ps.STOPPED: phpfails = 0; break;
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private static bool ciair(string process)
        {
            Process[] ptcf = Process.GetProcessesByName(process);
            if (ptcf.Length == 0)
            {
                return false;
            }
            else { return true; }
        }
    }
}