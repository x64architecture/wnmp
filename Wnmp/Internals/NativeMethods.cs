/*
Copyright (c) Kurt Cancemi 2012-2014

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
using System.Runtime.InteropServices;

namespace Wnmp.Internals
{
    /// <summary>
    /// Native methods (P/Invokes)
    /// </summary>
    static class NativeMethods
    {
        #region PINVOKE

        #region PRODUCT INFO
        [DllImport("Kernel32.dll")]
        public static extern bool GetProductInfo(
            int osMajorVersion,
            int osMinorVersion,
            int spMajorVersion,
            int spMinorVersion,
            out int edition);
        #endregion PRODUCT INFO

        #region VERSION
        [DllImport("kernel32.dll")]
        public static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
        #endregion VERSION

        #region SYSTEMMETRICS
        [DllImport("user32")]
        public static extern int GetSystemMetrics(int nIndex);
        #endregion SYSTEMMETRICS

        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        public struct OSVERSIONINFOEX
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
        #endregion OSVERSIONINFOEX

        #region InternetGetConnectedState
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [Flags]
        public enum ConnectionStates
        {
            Modem = 0x1, // 1
            LAN = 0x2, // 2
            Proxy = 0x4, // 4
            RasInstalled = 0x10, // 16
            Offline = 0x20, // 32
            Configured = 0x40, // 64
        }
        #endregion

        #endregion PINVOKE
    }
}
