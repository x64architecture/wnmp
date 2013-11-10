using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Wnmp
{
    static class NativeMethods
    {
        #region PINVOKE

        #region PRODUCT INFO
        [DllImport("Kernel32.dll")]
        internal static extern bool GetProductInfo(
            int osMajorVersion,
            int osMinorVersion,
            int spMajorVersion,
            int spMinorVersion,
            out int edition);
        #endregion PRODUCT INFO

        #region VERSION
        [DllImport("kernel32.dll")]
        internal static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
        #endregion VERSION

        #region SYSTEMMETRICS
        [DllImport("user32")]
        internal static extern int GetSystemMetrics(int nIndex);
        #endregion SYSTEMMETRICS

        #region OSVERSIONINFOEX
        [StructLayout(LayoutKind.Sequential)]
        internal struct OSVERSIONINFOEX
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

        #endregion PINVOKE
    }
}
