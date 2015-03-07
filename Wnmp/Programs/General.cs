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
using Wnmp.Forms;
using Wnmp.Helpers;
namespace Wnmp.Programs
{
    /// <summary>
    /// Functions/Handlers releated to the general applications (ex. start all apps)
    /// </summary>
    class General
    {
        public Main form;
        public Nginx nginx;
        public MariaDB mariadb;
        public PHP php;

        public void StartAllProgs()
        {
            Log.wnmp_log_notice("Attempting to start all the applications", Log.LogSection.WNMP_MAIN);
            // Nginx
            nginx.StartNginx();
            // PHP
            php.StartPHP();
            // MariaDB
            mariadb.StartMariaDB();
        }

        public void StopAllProgs()
        {
            Log.wnmp_log_notice("Attempting to stop all the applications", Log.LogSection.WNMP_MAIN);
            // Nginx
            nginx.StopNginx();
            // PHP
            php.StopPHP();
            // MariaDB
            mariadb.StopMariaDB();
        }
    }
}
