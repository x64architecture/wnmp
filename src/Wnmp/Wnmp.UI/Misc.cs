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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Wnmp.UI
{
    class Misc
    {
        private const uint IO_REPARSE_TAG_SYMLINK = 0xA000000C;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [Flags]
        public enum SYMBOLIC_LINK_FLAG
        {
            File = 0,
            Directory = 1,
            AllowUnprivilegedCreate = 2
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I1)]
        private static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SYMBOLIC_LINK_FLAG dwFlags);

        private static bool IsSymbolic(string path)
        {
            FileInfo pathInfo = new FileInfo(path);
            if (pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint))
            {
                WIN32_FIND_DATA FindFileData;
                FindFirstFile(path, out FindFileData);
                if (FindFileData.dwReserved0 == IO_REPARSE_TAG_SYMLINK)
                    return true;
            }
            return false;
        }

        public static bool CreateRelativeLink(string lpSymlinkFileName, string lpTargetFileName, SYMBOLIC_LINK_FLAG dwFlags, bool deleteOldLink=false)
        {
            if (Directory.Exists(lpSymlinkFileName) && !IsSymbolic(lpSymlinkFileName))
            {
                try
                {
                    Directory.Move(lpSymlinkFileName, lpSymlinkFileName + ".old");
                    Log.Notice("Moved " + lpSymlinkFileName + " to " + lpSymlinkFileName + ".old");
                }
                catch (Exception ex)
                {
                    Log.Notice(ex.Message);
                }
            }
            else if (Directory.Exists(lpSymlinkFileName) && IsSymbolic(lpSymlinkFileName))
            {
                if (!deleteOldLink)
                {
                    return true;
                }

                Directory.Delete(lpSymlinkFileName);
            }
            return CreateSymbolicLink(lpSymlinkFileName, lpTargetFileName, dwFlags);
        }

        public static void StartProcessAsync(string filename, string args = "")
        {
            new Thread(() => {
                Process.Start(filename, args);
            }).Start();
        }
        public static void OpenFileEditor(string file)
        {
            try {
                Process.Start(Properties.Settings.Default.TextEditor, file);
            } catch (Exception ex) {
                Log.Error(ex.Message);
            }
        }
    }
}
