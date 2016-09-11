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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Wnmp.SystemInformation
{
    public class OSVersionInfo
    {
        #region Native
        private const int VER_NT_WORKSTATION = 1;
        private const int VER_NT_SERVER = 3;

        private struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public short wServicePackMajor;
            public short wServicePackMinor;
            public short wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetProductInfo(int osMajorVersion, int osMinorVersion,
                                                  int spMajorVersion, int spMinorVersion,
                                                  out int edition);
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);

        #endregion

        private OSVERSIONINFOEX osVersionInfo;
        public OSVersionInfo()
        {
            osVersionInfo = new OSVERSIONINFOEX {
                dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
            };
            GetVersionEx(ref osVersionInfo);
        }

        private string GetName()
        {
            var name = "Unknown Name";
            var productType = osVersionInfo.wProductType;

            switch (Environment.OSVersion.Version.Major) {
                case 6:
                    switch (Environment.OSVersion.Version.Minor) {
                        case 0:
                            switch (productType) {
                                case VER_NT_WORKSTATION:
                                    name = "Vista";
                                    break;
                                case VER_NT_SERVER:
                                    name = "Server 2008";
                                    break;
                            }
                            break;

                        case 1:
                            switch (productType) {
                                case VER_NT_WORKSTATION:
                                    name = "7";
                                    break;
                                case VER_NT_SERVER:
                                    name = "Server 2008 R2";
                                    break;
                            }
                            break;
                        case 2:
                            switch (productType) {
                                case VER_NT_WORKSTATION:
                                    name = "8";
                                    break;
                                case VER_NT_SERVER:
                                    name = "Server 2012";
                                    break;
                            }
                            break;
                        case 3:
                            switch (productType) {
                                case VER_NT_WORKSTATION:
                                    name = "8.1";
                                    break;
                                case VER_NT_SERVER:
                                    name = "Server 2012 R2";
                                    break;
                            }
                            break;
                    }
                    break;
                case 10:
                    switch (productType) {
                        case VER_NT_WORKSTATION:
                            name = "10";
                            break;
                        case VER_NT_SERVER:
                            name = "Server 2016";
                            break;
                    }
                    break;
            }
            return name;
        }

        private string GetServicePack()
        {
            return osVersionInfo.szCSDVersion;
        }

        public string WindowsVersionString()
        {
            var sb = new StringBuilder();
            string OSName = GetName();
            string ServicePack = GetServicePack();

            sb.Append("Windows " + OSName);
            if (ServicePack != "")
                sb.Append(" " + ServicePack);

            return sb.ToString();
        }
    }
}
