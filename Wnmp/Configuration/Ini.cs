/*
Copyright (C) Kurt Cancemi 2014

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
using System.Text;
using System.IO;

namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        // Variables that contain the default values
        private string iniPath = Main.StartupPath + "/Wnmp.ini"; // ini path
        public string editor = "notepad.exe"; // editor for viewing config and log files
        public bool startupwithwindows = false; // Start Wnmp with Windows
        public bool startallapplicationsatlaunch = false; // Start all applications at launch
        public bool minimizewnmptotray = false; // Minimize Wnmp to tray when minimized
        public bool autocheckforupdates = true; // Auto check for updates
        public int checkforupdatefrequency = 7; // Check for update frequency
        public DateTime lastcheckforupdate = DateTime.MinValue;
        public bool firstrun = true; // First run

        /// <summary>
        /// Reads the settings from the ini
        /// </summary>
        public void ReadSettings()
        {
            if (!File.Exists(iniPath))
            {
                UpdateSettings(); // Update options with default values
            }

            if (File.Exists(iniPath))
            {
                string line;
                using (System.IO.StreamReader sr = new StreamReader(iniPath))
                {
                    while ((line = sr.ReadLine()) != null) // Read every line while not null
                    {
                        if (line.StartsWith("editorpath="))
                        {
                            editor = line.Remove(0, 11);
                        }
                        if (line.StartsWith("startupwithwindows="))
                        {
                            Boolean.TryParse(line.Remove(0, 19), out startupwithwindows);
                        }
                        if (line.StartsWith("startallapplicationsatlaunch="))
                        {
                            Boolean.TryParse(line.Remove(0, 29), out startallapplicationsatlaunch);
                        }
                        if (line.StartsWith("minimizewnmptotray="))
                        {
                            Boolean.TryParse(line.Remove(0, 19), out minimizewnmptotray);
                        }
                        if (line.StartsWith("autocheckforupdates="))
                        {
                            Boolean.TryParse(line.Remove(0, 20), out autocheckforupdates);
                        }
                        if (line.StartsWith("checkforupdatefrequency="))
                        {
                            int.TryParse(line.Remove(0, 24), out checkforupdatefrequency);
                        }
                        if (line.StartsWith("lastcheckforupdate="))
                        {
                            DateTime.TryParse(line.Remove(0, 19), out lastcheckforupdate);
                        }
                        if (line.StartsWith("firstrun="))
                        {
                            Boolean.TryParse(line.Remove(0, 9), out firstrun);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            using (System.IO.StreamWriter sw = new StreamWriter(iniPath))
            {
                sw.WriteLine("; Wnmp Configuration File\r\n;");
                sw.WriteLine("; editor path\r\neditorpath=" + editor);
                sw.WriteLine("; Start Wnmp with Windows\r\nstartupwithwindows=" + startupwithwindows);
                sw.WriteLine("; Start all applications when Wnmp starts\r\nstartallapplicationsatlaunch=" + startallapplicationsatlaunch);
                sw.WriteLine("; Minimize Wnmp to tray when minimized\r\nminimizewnmptotray=" + minimizewnmptotray);
                sw.WriteLine("; Automatically check for updates\r\nautocheckforupdates=" + autocheckforupdates);
                sw.WriteLine("; Update frequency(1, 7, 30)\r\ncheckforupdatefrequency=" + checkforupdatefrequency);
                sw.WriteLine("; Last check for update\r\nlastcheckforupdate=" + lastcheckforupdate);
                sw.WriteLine("; First run\r\nfirstrun=" + firstrun);
            }
        }
    }
}
