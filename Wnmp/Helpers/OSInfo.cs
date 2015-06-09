/*
Copyright (c) Kurt Cancemi 2012-2015

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

using System.Text;
using System.Management;
using System.Linq;

namespace Wnmp.Helpers
{
    /// <summary>
    /// Provides detailed information about the host operating system.
    /// </summary>
    public static class OSVersionInfo
    {
        static public string WindowsVersionString()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).First();
            return name != null ? name.ToString() : "Unknown";
        }
    }
}
