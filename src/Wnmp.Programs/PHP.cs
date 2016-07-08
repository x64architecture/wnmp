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

using Wnmp.UI;

namespace Wnmp.Programs
{
    class PHPProgram : WnmpProgram
    {
        public PHPProgram()
        {
            ps.StartInfo.EnvironmentVariables.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
        }

        private string GetPHPIniPath()
        {
            if (Settings.phpBin.Value == "Default")
                return Main.StartupPath + "/php/php.ini";
            else
                return Main.StartupPath + "/php/phpbins/" + Settings.phpBin.Value + "/php.ini";
        }

        public override void Start()
        {
            uint ProcessCount = Settings.PHP_Processes.Value;
            short port = Settings.PHP_Port.Value;
            string phpini = GetPHPIniPath();

            try {
                for (var i = 1; i <= ProcessCount; i++) {
                    StartProcess(exeName, $"-b localhost:{port} -c {phpini}");
                    Log.wnmp_log_notice("Starting PHP " + i + "/" + ProcessCount + " on port: " + port, progLogSection);
                    port++;
                }
                Log.wnmp_log_notice("PHP started", progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error("StartPHP(): " + ex.Message, progLogSection);
            }
        }

    }
}
