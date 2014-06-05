/*
Copyright (c) Kurt Cancemi 2012-2014

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
using System.IO;
using System.Text;
using System.Windows.Forms;
using Wnmp.Forms;
using Wnmp.Programs;
namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        // Variables that contain the default values
        private readonly string iniPath = Main.StartupPath + "/Wnmp.ini"; // ini path
        public string Editor = "notepad.exe"; // editor for viewing config and log files
        public bool Startupwithwindows = false; // Start Wnmp with Windows
        public bool Startallapplicationsatlaunch = false; // Start all applications at launch
        public bool Minimizewnmptotray = false; // Minimize Wnmp to tray when minimized
        public bool Autocheckforupdates = true; // Auto check for updates
        public int Checkforupdatefrequency = 7; // Check for update frequency
        public int PHPPort = 9000; // PHP Port
        public DateTime Lastcheckforupdate = DateTime.MinValue;
        public bool Firstrun = true; // First run

        /// <summary>
        /// Reads an ini value and returns it
        /// </summary>
        /// <param name="Option"></param>
        /// <returns></returns>
        private string ReadIniValue(string Option)
        {
            if (File.Exists(iniPath))
            {
                string str = Option + "=";
                using (var sr = new StreamReader(iniPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) // Read every line while not null
                    {
                        if (line.StartsWith(str))
                            return line.Remove(0, str.Length);
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Reads the settings from the ini
        /// </summary>
        public void ReadSettings()
        {
            if (!File.Exists(iniPath))
            {
                UpdateSettings(); // Update options with default values
            }

            Editor = ReadIniValue("editorpath");
            Boolean.TryParse(ReadIniValue("startupwithwindows"), out Startupwithwindows);
            Boolean.TryParse(ReadIniValue("startallapplicationsatlaunch"), out Startallapplicationsatlaunch);
            Boolean.TryParse(ReadIniValue("minimizewnmptotray"), out Minimizewnmptotray);
            Boolean.TryParse(ReadIniValue("autocheckforupdates"), out Autocheckforupdates);
            int.TryParse(ReadIniValue("checkforupdatefrequency"), out Checkforupdatefrequency);
            DateTime.TryParse(ReadIniValue("lastcheckforupdate"), out Lastcheckforupdate);
            int.TryParse(ReadIniValue("phpport"), out PHPPort);
            Boolean.TryParse(ReadIniValue("firstrun"), out Firstrun);

        }
        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            using (var sw = new StreamWriter(iniPath))
            {
                sw.WriteLine("; Wnmp Configuration File\r\n;");
                sw.WriteLine("; Editor path\r\neditorpath=" + Editor);
                sw.WriteLine("; Start Wnmp with Windows\r\nstartupwithwindows=" + Startupwithwindows);
                sw.WriteLine("; Start all applications when Wnmp starts\r\nstartallapplicationsatlaunch=" + Startallapplicationsatlaunch);
                sw.WriteLine("; Minimize Wnmp to tray when minimized\r\nminimizewnmptotray=" + Minimizewnmptotray);
                sw.WriteLine("; Automatically check for updates\r\nautocheckforupdates=" + Autocheckforupdates);
                sw.WriteLine("; Update frequency(In days)\r\ncheckforupdatefrequency=" + Checkforupdatefrequency);
                sw.WriteLine("; Last check for update\r\nlastcheckforupdate=" + Lastcheckforupdate);
                sw.WriteLine("; PHP Port\r\nphpport=" + PHPPort);
                sw.WriteLine("; First run\r\nfirstrun=" + Firstrun);
            }
        }
    }
}
