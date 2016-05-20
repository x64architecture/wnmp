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
using System.Collections.Generic;
using System.IO;

namespace Wnmp.Configuration
{
    /// <summary>
    /// Manages the settings
    /// </summary>
    public class Ini
    {
        public Option<string> Editor = new Option<string> {
            Name = "editor", Description = "Editor Path", Value = "notepad.exe",
        };
        public Option<bool> StartWithWindows = new Option<bool> {
            Name = "startupwithwindows", Description = "Start Wnmp with Windows", Value = false,
        };
        public Option<bool> StartNginxOnLaunch = new Option<bool> {
            Name = "startnginxonlaunch", Description = "Start Nginx when Wnmp starts", Value = false,
        };
        public Option<bool> StartMySQLOnLaunch = new Option<bool> {
            Name = "startmysqlonlaunch", Description = "Start MySQL when Wnmp starts", Value = false,
        };
        public Option<bool> StartPHPOnLaunch = new Option<bool> {
            Name = "startphponlaunch", Description = "Start PHP when Wnmp starts", Value = false,
        };
        public Option<bool> MinimizeWnmpToTray = new Option<bool> {
            Name = "minimizewnmptotray", Description = "Minimize to tray instead of minimizing", Value = false,
        };
        public Option<bool> AutoCheckForUpdates = new Option<bool> {
            Name = "autocheckforupdates", Description = "Automatically check for updates", Value = true,
        };
        public Option<uint> UpdateFrequency = new Option<uint> {
            Name = "updatefrequency", Description = "Update frequency(In days)", Value = 7,
        };
        public Option<string> phpBin = new Option<string> {
            Name = "phpbin", Description = "PHP version to use", Value = "Default",
        };
        public Option<short> PHP_Port = new Option<short> {
            Name = "phpport", Description = "Starting PHP Port", Value = 9001,
        };
        public Option<uint> PHP_Processes = new Option<uint> {
            Name = "phpprocesses", Description = "Amount of PHP processes", Value = 2,
        };
        public Option<DateTime> LastCheckForUpdate = new Option<DateTime> {
            Name = "lastcheckforupdate", Description = "Last check for update", Value = DateTime.MinValue,
        };
        public Option<bool> FirstRun = new Option<bool> {
            Name = "firstrun", Description = "First run", Value = true,
        };
        public Option<bool> MinimizeInsteadOfClosing = new Option<bool> {
            Name = "minimizeinsteadofclosing", Description = "Minimize to tray instead of closing", Value = false,
        };
        public Option<bool> StartMinimizedToTray = new Option<bool> {
            Name = "startminimizedtotray", Description = "Start Wnmp minimized to tray", Value = false,
        };

        private List<IOption> options = new List<IOption>();

        public Ini()
        {
            options.Add(Editor);
            options.Add(StartWithWindows);
            options.Add(StartNginxOnLaunch);
            options.Add(StartMySQLOnLaunch);
            options.Add(StartPHPOnLaunch);
            options.Add(StartMinimizedToTray);
            options.Add(MinimizeWnmpToTray);
            options.Add(MinimizeInsteadOfClosing);
            options.Add(AutoCheckForUpdates);
            options.Add(FirstRun);
            options.Add(UpdateFrequency);
            options.Add(PHP_Processes);
            options.Add(PHP_Port);
            options.Add(LastCheckForUpdate);
            options.Add(phpBin);
        }

        private readonly string IniFile = UI.Main.StartupPath + @"\Wnmp.ini";
        private string IniFileStr;
        private bool LoadIniFile()
        {
            if (!File.Exists(IniFile))
                return false;

            using (var sr = new StreamReader(IniFile)) {
                IniFileStr = sr.ReadToEnd();
            }

            return true;
        }

        /// <summary>
        /// Reads the settings from the ini
        /// </summary>
        public void ReadSettings()
        {
            if (!LoadIniFile()) {
                UpdateSettings(); // Add options with default values
                return;
            }

            foreach (var option in options) {
                option.ReadIniValue(IniFileStr);
                option.Convert();
            }

            UpdateSettings();
        }

        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            using (var sw = new StreamWriter(IniFile)) {
                sw.WriteLine("[WNMP]");
                foreach (var option in options) {
                    option.PrintIniOption(sw);
                }
            }
        }
    }
}
