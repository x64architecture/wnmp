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
    class NginxProgram : WnmpProgram
    {
        public NginxProgram(string exeFile) : base(exeFile)
        {
        }

        public override void Restart()
        {
            try
            {
                StartProcess(ExeFileName, "-s reload");
                Log.Notice("Started", ProgLogSection);
            }
            catch (Exception ex)
            {
                Log.Error("Start():" + ex.Message, ProgLogSection);
            }
        }

        public void GenerateSSLKeyPair()
        {
            try
            {
                StartProcess(ExeFileName, "-b");
                Log.Notice("Generated SSL Keypair", ProgLogSection);
            }
            catch (Exception ex)
            {
                Log.Error("Failed to generate SSL Keypair: " + ex.Message, ProgLogSection);
            }
        }
    }
}
