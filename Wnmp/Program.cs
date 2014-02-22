/*
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Wnmp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!IsVistaOrGreater())
            {
                MessageBox.Show("Wnmp is unsupported on your Operating System please upgrade to Vista/2008 or later.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            if (icp())
            {
                MessageBox.Show("Wnmp is already running.");
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(formInstance = new Main());
        }
        public static Main formInstance;
        static bool icp()
        {
            Process[] process = Process.GetProcessesByName("Wnmp");
            Process current = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != current.Id)
                    return true;
            }
            return false;
        }
        static bool IsVistaOrGreater()
        {
            OperatingSystem OS = Environment.OSVersion;
            return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
        }
    }
}
