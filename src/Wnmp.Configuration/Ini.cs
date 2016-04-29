/*
 * Copyright (c) 2012 - 2016, Kurt Cancemi (kurt@x64architecture.com)
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

namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        public Option<string> Editor = new Option<string>("editor", "Editor Path", "notepad.exe");
        public Option<bool> StartWithWindows = new Option<bool>("startupwithwindows", "Start Wnmp with Windows", false);
        public Option<bool> StartNginxOnLaunch = new Option<bool>("startnginxonlaunch", "Start Nginx when Wnmp starts", false);
        public Option<bool> StartMySQLOnLaunch = new Option<bool>("startmysqlonlaunch", "Start MySQL when Wnmp starts", false);
        public Option<bool> StartPHPOnLaunch = new Option<bool>("startphponlaunch", "Start PHP when Wnmp starts", false);
        public Option<bool> MinimizeWnmpToTray = new Option<bool>("minimizewnmptotray", "Minimize Wnmp to tray when minimized", false);
        public Option<bool> AutoCheckForUpdates = new Option<bool>("autocheckforupdates", "Automatically check for updates", true);
        public Option<int> UpdateFrequency = new Option<int>("updatefrequency", "Update frequency(In days)", 7);
        public Option<string> phpBin = new Option<string>("phpbin", "PHP version to use", "Default");
        public Option<short> PHP_Port = new Option<short>("phpport", "Starting PHP Port", 9001);
        public Option<int> PHP_Processes = new Option<int>("phpprocesses", "Amount of PHP processes", 2);
        public Option<DateTime> LastCheckForUpdate = new Option<DateTime>("lastcheckforupdate", "Last check for update", DateTime.MinValue);
        public Option<bool> FirstRun = new Option<bool>("firstrun", "First run", true);

        public string StartupPath { get; set; }
        private readonly string iniPath;
        public Ini()
        {
            iniPath = StartupPath + @"\Wnmp.ini";
        }

        private string IniFile;
        private bool LoadIniFile()
        {
            if (!File.Exists(iniPath))
                return false;

            var sr = new StreamReader(iniPath);
            IniFile = sr.ReadToEnd();
            sr.Close();

            return true;
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

            Editor.Value = Editor.GetIniValue(IniFile);
            bool.TryParse(StartWithWindows.GetIniValue(IniFile), out StartWithWindows.Value);
            bool.TryParse(StartNginxOnLaunch.GetIniValue(IniFile), out StartNginxOnLaunch.Value);
            bool.TryParse(StartMySQLOnLaunch.GetIniValue(IniFile), out StartMySQLOnLaunch.Value);
            bool.TryParse(StartPHPOnLaunch.GetIniValue(IniFile), out StartPHPOnLaunch.Value);
            bool.TryParse(MinimizeWnmpToTray.GetIniValue(IniFile),  out MinimizeWnmpToTray.Value);
            bool.TryParse(AutoCheckForUpdates.GetIniValue(IniFile), out AutoCheckForUpdates.Value);
            bool.TryParse(FirstRun.GetIniValue(IniFile), out FirstRun.Value);
            int.TryParse(UpdateFrequency.GetIniValue(IniFile), out UpdateFrequency.Value);
            int.TryParse(PHP_Processes.GetIniValue(IniFile), out PHP_Processes.Value);
            short.TryParse(PHP_Port.GetIniValue(IniFile), out PHP_Port.Value);
            DateTime.TryParse(LastCheckForUpdate.GetIniValue(IniFile), out LastCheckForUpdate.Value);
            phpBin.Value = phpBin.GetIniValue(IniFile);
            UpdateSettings();
        }

        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            if (PHP_Port.Value == 9000)
                PHP_Port.Value++;

            using (var sw = new StreamWriter(iniPath)) {
                sw.WriteLine("[WNMP]");
                Editor.PrintIniOption(sw);
                StartWithWindows.PrintIniOption(sw);
                StartNginxOnLaunch.PrintIniOption(sw);
                StartMySQLOnLaunch.PrintIniOption(sw);
                StartPHPOnLaunch.PrintIniOption(sw);
                MinimizeWnmpToTray.PrintIniOption(sw);
                AutoCheckForUpdates.PrintIniOption(sw);
                UpdateFrequency.PrintIniOption(sw);
                LastCheckForUpdate.PrintIniOption(sw);
                FirstRun.PrintIniOption(sw);
                sw.WriteLine("[PHP]");
                PHP_Processes.PrintIniOption(sw);
                PHP_Port.PrintIniOption(sw);
                phpBin.PrintIniOption(sw);
                sw.Close();
            }
        }
    }
}
