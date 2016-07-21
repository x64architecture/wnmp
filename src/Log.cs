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
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using Wnmp.SystemInformation;

namespace Wnmp
{
    /// <summary>
    /// Logs information and errors to a RichTextBox
    /// </summary>
    public static class Log
    {
        private static RichTextBox rtfLog;

        public enum LogSection
        {
            WNMP_MAIN = 0,
            WNMP_NGINX,
            WNMP_MARIADB,
            WNMP_PHP,
        }
        public static string LogSectionToString(LogSection logSection)
        {
            switch (logSection) {
                case LogSection.WNMP_MAIN:
                    return "Wnmp Main";
                case LogSection.WNMP_NGINX:
                    return "Wnmp Nginx";
                case LogSection.WNMP_MARIADB:
                    return "Wnmp MariaDB";
                case LogSection.WNMP_PHP:
                    return "Wnmp PHP";
                default:
                    return "";
            }
    }

        private static void wnmp_log(string message, Color color, LogSection logSection)
        {
            var SectionName = LogSectionToString(logSection);
            var DateNow = DateTime.Now.ToString();
            var str = $"{DateNow} [{SectionName}] - {message}";
            var textLength = rtfLog.TextLength;
            rtfLog.AppendText(str + "\n");
            if (rtfLog.Find(SectionName, textLength, RichTextBoxFinds.MatchCase) != -1) {
                rtfLog.SelectionLength = SectionName.Length;
                rtfLog.SelectionColor = color;
            }

            rtfLog.ScrollToCaret();
            rtfLog.SelectionStart = rtfLog.TextLength; // Deselect text
        }
        /// <summary>
        /// Log error
        /// </summary>
        public static void wnmp_log_error(string message, LogSection logSection)
        {
            wnmp_log(message, Color.Red, logSection);
        }
        /// <summary>
        /// Log information
        /// </summary>
        public static void wnmp_log_notice(string message, LogSection logSection)
        {
            wnmp_log(message, Color.DarkBlue, logSection);
        }

        public static void setLogComponent(RichTextBox logRichTextBox)
        {
            rtfLog = logRichTextBox;
            var logContextMenu = new ContextMenu();
            var CopyItem = new MenuItem("&Copy");
            CopyItem.Click += (s, e) => {
                if (rtfLog.SelectedText != String.Empty)
                    Clipboard.SetText(rtfLog.SelectedText);
            };
            logContextMenu.MenuItems.Add(CopyItem);
            rtfLog.ContextMenu = logContextMenu;

            wnmp_log_notice("Initializing Control Panel", LogSection.WNMP_MAIN);
            wnmp_log_notice("Control Panel Version: " + Constants.CPVER, LogSection.WNMP_MAIN);
            wnmp_log_notice("Wnmp Version: " + Application.ProductVersion, LogSection.WNMP_MAIN);
            var systemInfo = new SystemInfo();
            wnmp_log_notice(systemInfo.WindowsVersionString(), LogSection.WNMP_MAIN);
            if (systemInfo.icuid.CPUIDSupported()) {
                wnmp_log_notice("CPU: " + systemInfo.icuid.GetBrandString(), LogSection.WNMP_MAIN);
                wnmp_log_notice("CPU Features: " + systemInfo.CommonCPUFeatures(), LogSection.WNMP_MAIN);
            }
            wnmp_log_notice("Wnmp Directory: " + Application.StartupPath, LogSection.WNMP_MAIN);
        }
    }
}
