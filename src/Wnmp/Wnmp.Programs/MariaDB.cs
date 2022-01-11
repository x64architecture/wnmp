/*
 * Copyright (c) 2012 - 2021, Kurt Cancemi (kurt@x64architecture.com)
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

namespace Wnmp.Programs
{
    public class MariaDBProgram : WnmpProgram
    {
        public const string ServiceName = "Wnmp-MariaDB";
        private readonly ServiceController MariaDBController = new();

        public MariaDBProgram(string exeFile) : base(exeFile)
        {
            /* Set MariaDB service details */
            MariaDBController.MachineName = Environment.MachineName;
            MariaDBController.ServiceName = ServiceName;
        }

        public void RemoveService()
        {
            try {
                MariaDBController.Close();
                StartProcess("cmd.exe", StopArgs, WorkingDir, true);
            } catch (Exception) { }
        }

        public void InstallService()
        {
            try
            {
                if (ServiceExists())
                    RemoveService();
                StartProcess(ExeFileName, StartArgs, WorkingDir, true);
            }
            catch (Exception ex)
            {
                Log.Error($"InstallService(): {ex.Message}", ProgLogSection);
            }
        }

        public static bool ServiceExists()
        {
            ServiceController[] services = ServiceController.GetServices();
            for (var i = 0; i < services.Length; i++) {
                if (services[i].ServiceName == ServiceName)
                    return true;
            }
            return false;
        }

        public void OpenShell()
        {
            if (IsRunning() == false)
                Start();

            try
            {
                Process.Start(Program.StartupPath + "\\mariadb\\bin\\mysql.exe", "-u root -p");
                Log.Notice(Language.Resource.STARTED_MARIADB_SHELL, ProgLogSection);
            }
            catch (Exception ex)
            {
                Log.Error($"OpenShell(): {ex.Message}", ProgLogSection);
            }
        }

        public override void Start()
        {
            try {
                InstallService();
                MariaDBController.Start();
                Log.Notice(Language.Resource.STARTED, ProgLogSection);
            } catch (Exception ex) {
                Log.Error($"Start(): {ex.Message}", ProgLogSection);
            }
        }

        public override void Stop()
        {
            try {
                MariaDBController.Stop();
                RemoveService();
                Log.Notice(Language.Resource.STOPPED, ProgLogSection);
            } catch (Exception ex) {
                Log.Error($"Stop(): {ex.Message}", ProgLogSection);
            }
        }

        public override bool IsRunning()
        {
            try {
                if (ServiceExists())
                {
                    MariaDBController.Refresh();
                    return MariaDBController.Status == ServiceControllerStatus.Running;
                }
            } catch (Exception) { }
            return false;
        }
    }
}
