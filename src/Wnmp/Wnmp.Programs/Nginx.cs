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

namespace Wnmp.Programs
{
    public class NginxProgram : WnmpProgram
    {
        public NginxProgram(string exeFile) : base(exeFile)
        {
        }

        public override void Restart()
        {
            try
            {
                StartProcess(ExeFileName, "-s reload", WorkingDir);
                Log.Notice(Language.Resource.RESTARTED, ProgLogSection);
            }
            catch (Exception ex)
            {
                Log.Error($"Restart(): {ex.Message}", ProgLogSection);
            }
        }
    }
}
