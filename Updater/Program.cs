/*
Copyright (C) Kurt Cancemi

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


namespace Updater
{
    class Program
    {
        
        public static bool FindAndKillProcess(string name)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains(name))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        File.WriteAllText("updaterlog.txt", ex.ToString());
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
        bool print_log = false;
        string curDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string _orig = Path.Combine(curDir, "Wnmp.exe");
        string _new = Path.Combine(curDir, "Wnmp_new.exe");
        string _old = Path.Combine(curDir, "Wnmp_old.exe");
            foreach (string s in args)
            {
                if (s == "-t")
                    print_log = true;
            }
            if (print_log)
            {
                Console.WriteLine(print_log);
            }
            if (!FindAndKillProcess("Wnmp"))
            {
                Console.WriteLine("Failed To Kill the process");
                return;
            }
            try
            {
                System.Threading.Thread.Sleep(500);
                if (File.Exists(_orig))
                {
                    File.Move(_orig, _old);
                    if (print_log)
                    {
                        Console.WriteLine("Moved {0} to {1}", _orig, _old);
                    }
                }
                if (File.Exists(_new))
                {
                    File.Move(_new, _orig);

                    if (print_log)
                    {
                        Console.WriteLine("Moved {0} to {1}", _new, _orig);
                    }
                    File.Delete(_old);
                    if (print_log)
                    {
                        Console.WriteLine("Deleted {0}", _old);
                    }
                    Process.Start(_orig);
                    if (print_log)
                    {
                        Console.WriteLine("Started Wnmp.exe and exited the updater.");
                    }
                    else
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("updaterlog.txt", ex.ToString());
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
         