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
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Wnmp.Configuration
{
    public interface IOption
    {
        void ReadIniValue(string IniFileStr);
        void Convert();
        void PrintIniOption(StreamWriter sw);
    }

    public class Option<T> : IOption
    {
        public string Name;
        public string Description;
        public string iniValue;
        public T Value;

        public void ReadIniValue(string IniFileStr)
        {
            string key = Name + "=";
            using (var sr = new StringReader(IniFileStr)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith(key)) {
                        iniValue = line.Remove(0, key.Length);
                        return;
                    }
                }
            }
            iniValue = "";
        }

        public void PrintIniOption(StreamWriter sw)
        {
            sw.WriteLine("; " + Description);
            sw.WriteLine(Name + "=" + Value.ToString());
        }

        public void Convert()
        {
            if (iniValue == "")
                return;
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null) {
                try {
                    Value = (T)converter.ConvertFromString(iniValue);
                } catch (Exception ex) {
                    // Could be made a bit more elegant but considering its a rare user-caused exception....
                    var message =
                        $"{Name}={iniValue}\n{ex.Message}\n\nThe Default Value '{Value.ToString()}' will be used instead.";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
