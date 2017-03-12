/*
 * Copyright (c) 2012 - 2017, Kurt Cancemi (kurt@x64architecture.com)
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
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace Wnmp.Programs
{
    class MariaDBProgram : WnmpProgram
    {
        private readonly ServiceController MariaDBController = new ServiceController();

        public MariaDBProgram(string exeFile) : base(exeFile)
        {
            /* Set MariaDB service details */
            MariaDBController.MachineName = Environment.MachineName;
            MariaDBController.ServiceName = "Wnmp-MariaDB";
        }

        public void RemoveService()
        {
            new Thread(() => {
                StartProcess("cmd.exe", StopArgs);
            }).Start();
        }

        public void InstallService()
        {
            if (!File.Exists(ExeFileName)) {
                Log.Error("File " + ExeFileName + " not found.", ProgLogSection);
                return;
            }
            new Thread(() => {
                if (ServiceExists())
                    RemoveService();
                StartProcess(ExeFileName, StartArgs);
            }).Start();
        }

        public bool ServiceExists()
        {
            ServiceController[] services = ServiceController.GetServices();
            for (var i = 0; i < services.Length; i++) {
                if (services[i].ServiceName == "Wnmp-MariaDB")
                    return true;
            }
            return false;
        }

        public void OpenShell()
        {
            if (IsRunning() == false)
                Start();

            Process.Start(Program.StartupPath + "/mariadb/bin/mysql.exe", "-u root -p");
            Log.Notice("Started MariaDB shell", ProgLogSection);
        }

        public override void Start()
        {
            MariaDBController.Start();
            Log.Notice("Started ", ProgLogSection);
        }

        public override void Stop()
        {
            try {
                MariaDBController.Stop();
                Log.Notice("Stopped ", ProgLogSection);
            } catch (Exception ex) {
                Log.Error("Stop(): " + ex.Message, ProgLogSection);
            }
        }

    }
}
