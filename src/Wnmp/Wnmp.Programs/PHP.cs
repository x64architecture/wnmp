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
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Wnmp.Programs
{
    public class PHPProgram : WnmpProgram
    {
        private Socket sock;
        public PHPProgram(string exeFile) : base(exeFile)
        {

        }

        public override void Start()
        {
            uint ProcessCount = Properties.Settings.Default.PHPProcessCount;
            ushort port = Properties.Settings.Default.PHPPort;
            string phpini = Program.StartupPath + "\\php\\php.ini";

            if (IsRunning())
            {
                Log.Error(Language.Resource.ALREADY_RUNNING, ProgLogSection);
                return;
            }

            try
            {
                if (sock != null)
                    sock.Close();
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                sock.Bind(new IPEndPoint(IPAddress.Any, port));
                sock.Listen(16384);
                var env_vars = new Dictionary<string, string>
                {
                    { "PHP_FCGI_MAX_REQUESTS", "0" }
                };


                for (var i = 1; i <= ProcessCount; i++)
                {

                    StartProcess(ExeFileName, $"-b localhost:{port} -c {phpini}", WorkingDir, false, env_vars);
                    Log.Notice($"{Language.Resource.STARTED} PHP {i}/{ProcessCount}", ProgLogSection);
                }
                Log.Notice(Language.Resource.STARTED, ProgLogSection);
            }
            catch (Exception ex)
            {
                Log.Error($"StartPHP(): {ex.Message}", ProgLogSection);
            }
        }
    }
}
