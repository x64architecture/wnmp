/*
Copyright (C) Kurt Cancemi

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
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Wnmp.Helpers
{
    public static class Log
    {
        private static RichTextBox rtfLog;

        public static string GetEnumDescription(Enum value)
        {
            object[] customAttributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (customAttributes.Length > 0)
            {
                return ((DescriptionAttribute)customAttributes[0]).Description;
            }

            return string.Empty;
        }

        private static void wnmp_log(string message, Color color, LogSection logSection)
        {
            string str = string.Format("{0} [{1}] - {2}", DateTime.Now.ToString(), GetEnumDescription(logSection), message);
            int textLength = rtfLog.TextLength;
            rtfLog.AppendText(str + "\n");
            if (rtfLog.Find(GetEnumDescription(logSection), textLength, RichTextBoxFinds.MatchCase) != -1)
            {
                rtfLog.SelectionLength = GetEnumDescription(logSection).Length;
                rtfLog.SelectionColor = color;
            }

            rtfLog.ScrollToCaret();
        }

        public static void wnmp_log_error(string message, LogSection logSection)
        {
            wnmp_log(message, Color.Red, logSection);
        }

        public static void wnmp_log_notice(string message, LogSection logSection)
        {
            wnmp_log(message, Color.DarkBlue, logSection);
        }

        public static void setLogComponent(RichTextBox logRichTextBox)
        {
            rtfLog = logRichTextBox;
            wnmp_log_notice("Initializing Control Panel", LogSection.WNMP_MAIN);
        }

        public enum LogSection
        {
            [Description("Wnmp Main")]
            WNMP_MAIN = 0,
            [Description("Wnmp Nginx")]
            WNMP_NGINX = 1,
            [Description("Wnmp PHP")]
            WNMP_PHP = 2,
            [Description("Wnmp MariaDB")]
            WNMP_MARIADB = 3
        }
    }
}
