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
using System.Net;
using System.Net.Sockets;

namespace Wnmp.Programs
{
    class PHPProgram : WnmpProgram
    {
        private Socket sock;
        public PHPProgram(string exeFile) : base(exeFile)
        {

        }

        private string GetPHPIniPath()
        {
            if (Properties.Settings.Default.PHPVersion == "Default")
                return Program.StartupPath + "/php/php.ini";
            else
                return Program.StartupPath + "/php/phpbins/" + Properties.Settings.Default.PHPVersion + "/php.ini";
        }

        public override void Start()
        {
            uint ProcessCount = Properties.Settings.Default.PHPProcessCount;
            ushort port = Properties.Settings.Default.PHPPort;
            string phpini = GetPHPIniPath();

            if (IsRunning()) {
                Log.Error("Already running.", ProgLogSection);
                return;
            }

            if (sock != null)
                sock.Close();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            sock.Bind(new IPEndPoint(IPAddress.Any, port));
            sock.Listen(16384);

            try {
                for (var i = 1; i <= ProcessCount; i++) {
                    StartProcess(ExeFileName, $"-b localhost:{port} -c {phpini}");
                    Log.Notice("Starting PHP " + i + "/" + ProcessCount, ProgLogSection);
                }
                Log.Notice("PHP started", ProgLogSection);
            } catch (Exception ex) {
                Log.Error("StartPHP(): " + ex.Message, ProgLogSection);
            }
        }
    }
}
