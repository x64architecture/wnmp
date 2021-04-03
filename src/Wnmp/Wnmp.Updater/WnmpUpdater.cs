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
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using Wnmp.Configuration;
using Wnmp.UI;
using System.Collections;
using System.Collections.Generic;

namespace Wnmp.Updater
{
    /// <summary>
    /// Updater for Wnmp
    /// </summary>
    class WnmpUpdater
    {
        private readonly MainFrm mainForm;
        private readonly Updater updater = new();

        public WnmpUpdater(MainFrm form)
        {
            mainForm = form;
        }

        /// <summary>
        /// Checks for updates
        /// </summary>
        public void CheckForUpdates()
        {
            updater.CurrentVersion = new Version(Application.ProductVersion);
            updater.UpdateInfoURL = new Uri("https://wnmp.x64architecture.com/update.xml");
            updater.SaveFileName = Program.StartupPath + "\\Wnmp-Upgrade-Installer.exe";

            updater.CheckForUpdate();

            if (updater.UpdateAvailable) {
                var UpdatePrompt = new UpdatePromptFrm("https://github.com/wnmp/wnmp/releases/latest", updater.CurrentVersion, updater.NewVersion) {
                    StartPosition = FormStartPosition.CenterParent
                };
                if (UpdatePrompt.ShowDialog() == DialogResult.Yes) {
                    mainForm.Enabled = false;
                    updater.Update(UpdateCanceled, UpdateDownloaded);
                }
            } else {
                Log.Notice(Language.Resource.YOUR_VERSION_VER_IS_UP_TO_DATE_DOT.Replace("{CURRENTVERSION}", Application.ProductVersion));
            }
        }

        private void UpdateCanceled()
        {
            mainForm.Enabled = true;
        }

        private void UpdateDownloaded()
        {
            mainForm.StopAll();
            DoBackUp();
            KillProcesses();
            Process.Start(updater.SaveFileName);
            Application.Exit();
        }

        /// <summary>
        /// Backs up the configuration files for Nginx, MariaDB, and PHP
        /// </summary>
        private static void DoBackUp()
        {
            string[] files = { "\\php\\php.ini", "\\conf\\nginx.conf", "\\mariadb\\data\\my.ini" };
            foreach (string file in files) {
                string srcFile = Program.StartupPath + file;
                if (File.Exists(srcFile)) {
                    string destFile = $"{srcFile}.old";
                    File.Copy(srcFile, destFile, true);
                    Log.Notice($"{Language.Resource.BACKED_UP} {srcFile} -> {destFile}");
                }
            }
        }

        /// <summary>
        /// Kills Nginx, MariaDB, and PHP
        /// </summary>
        private static void KillProcesses()
        {
            var processesToKill = new HashSet<string>(new string[] { "php-cgi", "nginx", "mysqld" });
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes) {
                if (processesToKill.Contains(process.ProcessName))
                    process.Kill();
            }
        }

        public void DoDateEclasped()
        {
            DateTime LastCheckForUpdate = Properties.Settings.Default.LastCheckForUpdate;
            DateTime expiryDate = LastCheckForUpdate.AddDays(Properties.Settings.Default.UpdateFrequency);

            if (DateTime.Now < expiryDate)
                return;

            CheckForUpdates();

            Properties.Settings.Default.LastCheckForUpdate = DateTime.Now;
            Properties.Settings.Default.Save();
        }
    }
}