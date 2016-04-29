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

using System.IO;

namespace Wnmp.Configuration
{
    public class Option<T>
    {
        public string IniName;
        public string Description;
        public T Value;

        public Option(string IniName, string Description, T Value)
        {
            this.IniName = IniName;
            this.Description = Description;
            this.Value = Value;
        }

        public void PrintIniOption(StreamWriter sw)
        {
            sw.WriteLine("; " + Description);
            sw.WriteLine(IniName + "=" + Value.ToString());
        }

        /// <summary>
        /// Reads an ini value and returns it
        /// </summary>
        public string GetIniValue(string IniFile)
        {
            var OptionName = IniName + "=";
            using (var sr = new StringReader(IniFile)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    if (line.StartsWith(OptionName))
                        return line.Remove(0, OptionName.Length);
                }
            }
            return Value.ToString();
        }
    }
}
