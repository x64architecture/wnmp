/*
Copyright (c) Kurt Cancemi 2013-2014

This file is part of Updater.

    Updater is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Updater is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;


namespace Updater
{
    class Program
    {

        /// <summary>
        /// Trys to find the process in the name parameter
        /// and if it does it kills it
        /// </summary>
        /// <returns>True on sucess else false</returns>
        public static bool FindAndKillProcess(string name)
        {
            foreach (Process process in Process.GetProcesses()) {
                if (process.ProcessName.Contains(name)) {
					try {
						process.Kill();
					} catch (Exception ex) {
						File.WriteAllText("updaterlog.txt", ex.ToString());
						Console.WriteLine(ex.Message);
						return false;
					}
                    return true;
                }
            }
            return true;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            string curDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string _orig = Path.Combine(curDir, "Wnmp.exe");
            string _new = Path.Combine(curDir, "Wnmp_new.exe");

            if (!FindAndKillProcess("Wnmp")) {
                Console.WriteLine("Failed To Kill the process");
                return;
            }

            Thread.Sleep(250);

            if (!File.Exists(_orig))
                return;
            
            File.Delete(_orig);

            if (!File.Exists(_new))
                return;
            
            File.Move(_new, _orig);

            Process.Start(_orig);
            return;
        }
    }
}
         
