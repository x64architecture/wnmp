/*
 * Copyright (c) 2012 - 2015, Kurt Cancemi (kurt@x64architecture.com)
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
using System.IO;

using Wnmp.Forms;
namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        // Variables that contain the default values
        private readonly string iniPath = Main.StartupPath + "/Wnmp.ini";
        public string Editor = "notepad.exe";
        public bool StartWithWindows = false;
        public bool RunAppsAtLaunch = false;
        public bool MinimizeWnmpToTray = false;
        public bool AutoCheckForUpdates = true;
        public int UpdateFrequency = 7;
        public string phpBin = "Default";
        public short PHP_Port = 9001;
        public int PHP_Processes = 2;
        public DateTime Lastcheckforupdate = DateTime.MinValue;
        public bool FirstRun = true;
        private string IniFile;

        private bool LoadIniFile()
        {
            if (!File.Exists(iniPath))
                return false;

            StreamReader sr = new StreamReader(iniPath);
            IniFile = sr.ReadToEnd();
            sr.Close();

            return true;
        }

        /// <summary>
        /// Reads an ini value and returns it
        /// </summary>
        /// <param name="Option"></param>
        /// <returns></returns>
        private string ReadIniValue(string Option, object defaultValue)
        {      
            string str = Option + "=";
            using (var sr = new StringReader(IniFile)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                        if (line.StartsWith(str))
                            return line.Remove(0, str.Length);
                }
            }
            return defaultValue.ToString();
        }

        /// <summary>
        /// Reads the settings from the ini
        /// </summary>
        public void ReadSettings()
        {
            if (!File.Exists(iniPath))
                UpdateSettings(); // Update options with default values

            if (!LoadIniFile())
                return;
            Editor = ReadIniValue("editorpath", Editor);
            Boolean.TryParse(ReadIniValue("startupwithwindows", StartWithWindows), out StartWithWindows);
            Boolean.TryParse(ReadIniValue("startallapplicationsatlaunch", RunAppsAtLaunch), out RunAppsAtLaunch);
            Boolean.TryParse(ReadIniValue("minimizewnmptotray", MinimizeWnmpToTray),  out MinimizeWnmpToTray);
            Boolean.TryParse(ReadIniValue("autocheckforupdates", AutoCheckForUpdates), out AutoCheckForUpdates);
            Boolean.TryParse(ReadIniValue("firstrun", FirstRun), out FirstRun);
            int.TryParse(ReadIniValue("checkforupdatefrequency", UpdateFrequency), out UpdateFrequency);
            int.TryParse(ReadIniValue("phpprocesses", PHP_Processes), out PHP_Processes);
            short.TryParse(ReadIniValue("phpport", PHP_Port), out PHP_Port);
            DateTime.TryParse(ReadIniValue("lastcheckforupdate", Lastcheckforupdate), out Lastcheckforupdate);
            phpBin = ReadIniValue("phpbin", phpBin);
            UpdateSettings();
        }
        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            if (PHP_Port == 9000)
                PHP_Port++;

            using (var sw = new StreamWriter(iniPath)) {
                sw.WriteLine("[WNMP]");
                sw.WriteLine("; Editor path\r\neditorpath=" + Editor);
                sw.WriteLine("; Start Wnmp with Windows\r\nstartupwithwindows=" + StartWithWindows);
                sw.WriteLine("; Start all applications when Wnmp starts\r\nstartallapplicationsatlaunch=" + RunAppsAtLaunch);
                sw.WriteLine("; Minimize Wnmp to tray when minimized\r\nminimizewnmptotray=" + MinimizeWnmpToTray);
                sw.WriteLine("; Automatically check for updates\r\nautocheckforupdates=" + AutoCheckForUpdates);
                sw.WriteLine("; Update frequency(In days)\r\ncheckforupdatefrequency=" + UpdateFrequency);
                sw.WriteLine("; Last check for update\r\nlastcheckforupdate=" + Lastcheckforupdate);
                sw.WriteLine("; First run\r\nfirstrun=" + FirstRun);
                sw.WriteLine("[PHP]");
                sw.WriteLine("; Amount of PHP processes\r\nphpprocesses=" + PHP_Processes);
                sw.WriteLine("; PHP Port\r\nphpport=" + PHP_Port);
                sw.WriteLine("; PHP Version to use\r\nphpbin=" + phpBin);
            }
        }
    }
}
