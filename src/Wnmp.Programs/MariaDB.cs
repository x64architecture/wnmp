/*
 * Copyright (c) 2012 - 2016, Kurt Cancemi (kurt@x64architecture.com)
 *
 * This file is part of Wnmp.
 *
 *  Wnmp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Wnmp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.ServiceProcess;

namespace Wnmp.Programs
{
    class MariaDBProgram : WnmpProgram
    {
        private readonly ServiceController mysqlController = new ServiceController();

        public MariaDBProgram()
        {
            /* Set MariaDB service details */
            mysqlController.MachineName = Environment.MachineName;
            mysqlController.ServiceName = "Wnmp-MySQL";
        }

        private void RemoveService()
        {
            StartProcess("cmd.exe", stopArgs, true); // Remove Service
        }

        private void InstallService()
        {
            StartProcess(exeName, startArgs, true);
        }

        public override void Start()
        {
            try {
                RemoveService();
                InstallService();
                mysqlController.Start();
                Log.wnmp_log_notice("Started " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error("Start(): " + ex.Message, progLogSection);
            }
        }

        public override void Stop()
        {
            try {
                mysqlController.Stop(); // Stop MySQL service
                StartProcess("cmd.exe", stopArgs, true); // Remove MySQL service
                Log.wnmp_log_notice("Stopped " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_notice("Stop(): " + ex.Message, progLogSection);
            }
        }

    }
}
