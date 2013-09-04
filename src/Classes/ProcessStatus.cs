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

namespace Wnmp
{
    public class ProcessStatus
    {
        internal enum ps
        {
            STARTED,
            STOPPED
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
        public static void OnTimer(Object source, ElapsedEventArgs e)
        {
            int ngxfails = 0;
            int mariadbfails = 0;
            int phpfails = 0;
            switch (Nginx.NgxStatus)
            {
                case 0:
                    {
                        if (ngxfails <= 10) // If Nginx fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("nginx") == false)
                            {
                                Nginx.startprocess(Main.getappsupath + "/nginx.exe", "");
                                Program.formInstance.output.Invoke(new Action(() => Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp Nginx]" + " - Attempting to restart crashed Nginx")));
                                ngxfails++;
                            }
                        }
                        break;
                    }
                case 1: ngxfails = 0; break;
            }
            switch (MariaDB.MariaDBStatus)
            {
                case 0:
                    {
                        if (mariadbfails <= 10) // If MariaDB fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("mariadb") == false)
                            {
                                MariaDB.startprocess(Main.getappsupath + "/mariadb/bin/mysqld.exe", "", false, true);
                                Program.formInstance.output.Invoke(new Action(() => Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp MariaDB]" + " - Attempting to restart crashed MariaDB")));
                                mariadbfails++;
                            }
                        }
                        break;
                    }
                case 1: mariadbfails = 0; break;
            }
            switch (PHP.PHPStatus)
            {
                case 0:
                    {
                        if (phpfails <= 10) // If PHP fails to start over 10 times quit trying to restart it.
                        {
                            if (ciair("php-cgi") == false)
                            {
                                PHP.startprocess(Main.getappsupath + "/php/php-cgi.exe", "-b localhost:9000");
                                Program.formInstance.output.Invoke(new Action(() => Program.formInstance.output.AppendText("\n" + DateTime.Now.ToString() + " [Wnmp PHP]" + " - Attempting to restart crashed PHP")));
                                phpfails++;
                            }
                        }
                        break;
                    }
                case 1: phpfails = 0; break;
            }
        }
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