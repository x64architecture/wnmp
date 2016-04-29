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

namespace Wnmp.SystemInformation
{
    public class OSVersionInfo
    {
        #region PRODUCT
        private const int PRODUCT_UNDEFINED = 0x00000000;
        private const int PRODUCT_ULTIMATE = 0x00000001;
        private const int PRODUCT_HOME_BASIC = 0x00000002;
        private const int PRODUCT_HOME_PREMIUM = 0x00000003;
        private const int PRODUCT_ENTERPRISE = 0x00000004;
        private const int PRODUCT_HOME_BASIC_N = 0x00000005;
        private const int PRODUCT_BUSINESS = 0x00000006;
        private const int PRODUCT_STANDARD_SERVER = 0x00000007;
        private const int PRODUCT_DATACENTER_SERVER = 0x00000008;
        private const int PRODUCT_SMALLBUSINESS_SERVER = 0x00000009;
        private const int PRODUCT_ENTERPRISE_SERVER = 0x0000000A;
        private const int PRODUCT_STARTER = 0x0000000B;
        private const int PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C;
        private const int PRODUCT_STANDARD_SERVER_CORE = 0x0000000D;
        private const int PRODUCT_ENTERPRISE_SERVER_CORE = 0x0000000E;
        private const int PRODUCT_ENTERPRISE_SERVER_IA64 = 0x0000000F;
        private const int PRODUCT_BUSINESS_N = 0x00000010;
        private const int PRODUCT_WEB_SERVER = 0x00000011;
        private const int PRODUCT_CLUSTER_SERVER = 0x00000012;
        private const int PRODUCT_HOME_SERVER = 0x00000013;
        private const int PRODUCT_STORAGE_EXPRESS_SERVER = 0x00000014;
        private const int PRODUCT_STORAGE_STANDARD_SERVER = 0x00000015;
        private const int PRODUCT_STORAGE_WORKGROUP_SERVER = 0x00000016;
        private const int PRODUCT_STORAGE_ENTERPRISE_SERVER = 0x00000017;
        private const int PRODUCT_SERVER_FOR_SMALLBUSINESS = 0x00000018;
        private const int PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 0x00000019;
        private const int PRODUCT_HOME_PREMIUM_N = 0x0000001A;
        private const int PRODUCT_ENTERPRISE_N = 0x0000001B;
        private const int PRODUCT_ULTIMATE_N = 0x0000001C;
        private const int PRODUCT_WEB_SERVER_CORE = 0x0000001D;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT = 0x0000001E;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY = 0x0000001F;
        private const int PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING = 0x00000020;
        private const int PRODUCT_SERVER_FOUNDATION = 0x00000021;
        private const int PRODUCT_HOME_PREMIUM_SERVER = 0x00000022;
        private const int PRODUCT_SERVER_FOR_SMALLBUSINESS_V = 0x00000023;
        private const int PRODUCT_STANDARD_SERVER_V = 0x00000024;
        private const int PRODUCT_DATACENTER_SERVER_V = 0x00000025;
        private const int PRODUCT_ENTERPRISE_SERVER_V = 0x00000026;
        private const int PRODUCT_DATACENTER_SERVER_CORE_V = 0x00000027;
        private const int PRODUCT_STANDARD_SERVER_CORE_V = 0x00000028;
        private const int PRODUCT_ENTERPRISE_SERVER_CORE_V = 0x00000029;
        private const int PRODUCT_HYPERV = 0x0000002A;
        private const int PRODUCT_STORAGE_EXPRESS_SERVER_CORE = 0x0000002B;
        private const int PRODUCT_STORAGE_STANDARD_SERVER_CORE = 0x0000002C;
        private const int PRODUCT_STORAGE_WORKGROUP_SERVER_CORE = 0x0000002D;
        private const int PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE = 0x0000002E;
        private const int PRODUCT_STARTER_N = 0x0000002F;
        private const int PRODUCT_PROFESSIONAL = 0x00000030;
        private const int PRODUCT_PROFESSIONAL_N = 0x00000031;
        private const int PRODUCT_SB_SOLUTION_SERVER = 0x00000032;
        private const int PRODUCT_SERVER_FOR_SB_SOLUTIONS = 0x00000033;
        private const int PRODUCT_STANDARD_SERVER_SOLUTIONS = 0x00000034;
        private const int PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE = 0x00000035;
        private const int PRODUCT_SB_SOLUTION_SERVER_EM = 0x00000036;
        private const int PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM = 0x00000037;
        private const int PRODUCT_SOLUTION_EMBEDDEDSERVER = 0x00000038;
        private const int PRODUCT_SOLUTION_EMBEDDEDSERVER_CORE = 0x00000039;
        // private const int ???? = 0x0000003A;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT = 0x0000003B;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL = 0x0000003C;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC = 0x0000003D;
        private const int PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC = 0x0000003E;
        private const int PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE = 0x0000003F;
        private const int PRODUCT_CLUSTER_SERVER_V = 0x00000040;
        private const int PRODUCT_EMBEDDED = 0x00000041;
        private const int PRODUCT_STARTER_E = 0x00000042;
        private const int PRODUCT_HOME_BASIC_E = 0x00000043;
        private const int PRODUCT_HOME_PREMIUM_E = 0x00000044;
        private const int PRODUCT_PROFESSIONAL_E = 0x00000045;
        private const int PRODUCT_ENTERPRISE_E = 0x00000046;
        private const int PRODUCT_ULTIMATE_E = 0x00000047;
        private const int PRODUCT_ENTERPRISE_EVALUATION = 0x00000048;
        private const int PRODUCT_MULTIPOINT_STANDARD_SERVER = 0x0000004C;
        private const int PRODUCT_MULTIPOINT_PREMIUM_SERVER = 0x0000004D;
        private const int PRODUCT_STANDARD_EVALUATION_SERVER = 0x0000004F;
        private const int PRODUCT_DATACENTER_EVALUATION_SERVER = 0x00000050;
        private const int PRODUCT_ENTERPRISE_N_EVALUATION = 0x00000054;
        private const int PRODUCT_EMBEDDED_AUTOMOTIVE = 0x00000055;
        private const int PRODUCT_EMBEDDED_INDUSTRY_A = 0x00000056;
        private const int PRODUCT_THINPC = 0x00000057;
        private const int PRODUCT_EMBEDDED_A = 0x00000058;
        private const int PRODUCT_EMBEDDED_INDUSTRY = 0x00000059;
        private const int PRODUCT_EMBEDDED_E = 0x0000005A;
        private const int PRODUCT_EMBEDDED_INDUSTRY_E = 0x0000005B;
        private const int PRODUCT_EMBEDDED_INDUSTRY_A_E = 0x0000005C;
        private const int PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER = 0x0000005F;
        private const int PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER = 0x00000060;
        private const int PRODUCT_CORE_ARM = 0x00000061;
        private const int PRODUCT_CORE_N = 0x00000062;
        private const int PRODUCT_CORE_COUNTRYSPECIFIC = 0x00000063;
        private const int PRODUCT_CORE_SINGLELANGUAGE = 0x00000064;
        private const int PRODUCT_CORE = 0x00000065;
        private const int PRODUCT_PROFESSIONAL_WMC = 0x00000067;

        // private const int PRODUCT_UNLICENSED = 0xABCDABCD;
        #endregion PRODUCT

        #region VERSIONS
        private const int VER_NT_WORKSTATION = 1;
        //private const int VER_NT_DOMAIN_CONTROLLER = 2;
        private const int VER_NT_SERVER = 3;
        //private const int VER_SUITE_SMALLBUSINESS = 1;
        //private const int VER_SUITE_ENTERPRISE = 2;
        //private const int VER_SUITE_TERMINAL = 16;
        //private const int VER_SUITE_DATACENTER = 128;
        //private const int VER_SUITE_SINGLEUSERTS = 256;
        //private const int VER_SUITE_PERSONAL = 512;
        //private const int VER_SUITE_BLADE = 1024;
        #endregion VERSIONS

        #region EditionToString
        private string EditionToString(int ed)
        {
            var edition = "";
            switch (ed) {
                case PRODUCT_BUSINESS:
                    edition = "Business";
                    break;
                case PRODUCT_BUSINESS_N:
                    edition = "Business N";
                    break;
                case PRODUCT_HOME_SERVER:
                    edition = "Storage Server 2008 R2 Essentials";
                    break;
                case PRODUCT_CLUSTER_SERVER:
                    edition = "HPC Edition";
                    break;
                case PRODUCT_CLUSTER_SERVER_V:
                    edition = "HPC Edition without Hyper-V";
                    break;
                case PRODUCT_DATACENTER_SERVER:
                    edition = "Datacenter Server";
                    break;
                case PRODUCT_DATACENTER_SERVER_CORE:
                    edition = "Datacenter Server (core installation)";
                    break;
                case PRODUCT_DATACENTER_SERVER_V:
                    edition = "Datacenter Server without Hyper-V";
                    break;
                case PRODUCT_DATACENTER_SERVER_CORE_V:
                    edition = "Datacenter Server without Hyper-V (core installation)";
                    break;
                case PRODUCT_EMBEDDED:
                    edition = "Embedded";
                    break;
                case PRODUCT_ENTERPRISE:
                    edition = "Enterprise";
                    break;
                case PRODUCT_ENTERPRISE_N:
                    edition = "Enterprise N";
                    break;
                case PRODUCT_ENTERPRISE_E:
                    edition = "Enterprise E";
                    break;
                case PRODUCT_ENTERPRISE_SERVER:
                    edition = "Enterprise Server";
                    break;
                case PRODUCT_ENTERPRISE_SERVER_CORE:
                    edition = "Enterprise Server (core installation)";
                    break;
                case PRODUCT_ENTERPRISE_SERVER_CORE_V:
                    edition = "Enterprise Server without Hyper-V (core installation)";
                    break;
                case PRODUCT_ENTERPRISE_SERVER_IA64:
                    edition = "Enterprise Server for Itanium-based Systems";
                    break;
                case PRODUCT_ENTERPRISE_SERVER_V:
                    edition = "Enterprise Server without Hyper-V";
                    break;
                case PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT:
                    edition = "Essential Business Server MGMT";
                    break;
                case PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL:
                    edition = "Essential Business Server ADDL";
                    break;
                case PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC:
                    edition = "Essential Business Server MGMTSVC";
                    break;
                case PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC:
                    edition = "Essential Business Server ADDLSVC";
                    break;
                case PRODUCT_HOME_BASIC:
                    edition = "Home Basic";
                    break;
                case PRODUCT_HOME_BASIC_N:
                    edition = "Home Basic N";
                    break;
                case PRODUCT_HOME_BASIC_E:
                    edition = "Home Basic E";
                    break;
                case PRODUCT_HOME_PREMIUM:
                    edition = "Home Premium";
                    break;
                case PRODUCT_HOME_PREMIUM_N:
                    edition = "Home Premium N";
                    break;
                case PRODUCT_HOME_PREMIUM_E:
                    edition = "Home Premium E";
                    break;
                case PRODUCT_HOME_PREMIUM_SERVER:
                    edition = "Home Premium Server";
                    break;
                case PRODUCT_HYPERV:
                    edition = "Microsoft Hyper-V Server";
                    break;
                case PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT:
                    edition = "Windows Essential Business Management Server";
                    break;
                case PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING:
                    edition = "Windows Essential Business Messaging Server";
                    break;
                case PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY:
                    edition = "Windows Essential Business Security Server";
                    break;
                case PRODUCT_PROFESSIONAL:
                    edition = "Professional";
                    break;
                case PRODUCT_PROFESSIONAL_N:
                    edition = "Professional N";
                    break;
                case PRODUCT_PROFESSIONAL_E:
                    edition = "Professional E";
                    break;
                case PRODUCT_SB_SOLUTION_SERVER:
                    edition = "SB Solution Server";
                    break;
                case PRODUCT_SB_SOLUTION_SERVER_EM:
                    edition = "SB Solution Server EM";
                    break;
                case PRODUCT_SERVER_FOR_SB_SOLUTIONS:
                    edition = "Server for SB Solutions";
                    break;
                case PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM:
                    edition = "Server for SB Solutions EM";
                    break;
                case PRODUCT_SERVER_FOR_SMALLBUSINESS:
                    edition = "Windows Essential Server Solutions";
                    break;
                case PRODUCT_SERVER_FOR_SMALLBUSINESS_V:
                    edition = "Windows Essential Server Solutions without Hyper-V";
                    break;
                case PRODUCT_SERVER_FOUNDATION:
                    edition = "Server Foundation";
                    break;
                case PRODUCT_SMALLBUSINESS_SERVER:
                    edition = "Windows Small Business Server";
                    break;
                case PRODUCT_SMALLBUSINESS_SERVER_PREMIUM:
                    edition = "Windows Small Business Server Premium";
                    break;
                case PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE:
                    edition = "Windows Small Business Server Premium (core installation)";
                    break;
                case PRODUCT_SOLUTION_EMBEDDEDSERVER:
                    edition = "Solution Embedded Server";
                    break;
                case PRODUCT_SOLUTION_EMBEDDEDSERVER_CORE:
                    edition = "Solution Embedded Server (core installation)";
                    break;
                case PRODUCT_STANDARD_SERVER:
                    edition = "Standard Server";
                    break;
                case PRODUCT_STANDARD_SERVER_CORE:
                    edition = "Standard Server (core installation)";
                    break;
                case PRODUCT_STANDARD_SERVER_SOLUTIONS:
                    edition = "Standard Server Solutions";
                    break;
                case PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE:
                    edition = "Standard Server Solutions (core installation)";
                    break;
                case PRODUCT_STANDARD_SERVER_CORE_V:
                    edition = "Standard Server without Hyper-V (core installation)";
                    break;
                case PRODUCT_STANDARD_SERVER_V:
                    edition = "Standard Server without Hyper-V";
                    break;
                case PRODUCT_STARTER:
                    edition = "Starter";
                    break;
                case PRODUCT_STARTER_N:
                    edition = "Starter N";
                    break;
                case PRODUCT_STARTER_E:
                    edition = "Starter E";
                    break;
                case PRODUCT_STORAGE_ENTERPRISE_SERVER:
                    edition = "Enterprise Storage Server";
                    break;
                case PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE:
                    edition = "Enterprise Storage Server (core installation)";
                    break;
                case PRODUCT_STORAGE_EXPRESS_SERVER:
                    edition = "Express Storage Server";
                    break;
                case PRODUCT_STORAGE_EXPRESS_SERVER_CORE:
                    edition = "Express Storage Server (core installation)";
                    break;
                case PRODUCT_STORAGE_STANDARD_SERVER:
                    edition = "Standard Storage Server";
                    break;
                case PRODUCT_STORAGE_STANDARD_SERVER_CORE:
                    edition = "Standard Storage Server (core installation)";
                    break;
                case PRODUCT_STORAGE_WORKGROUP_SERVER:
                    edition = "Workgroup Storage Server";
                    break;
                case PRODUCT_STORAGE_WORKGROUP_SERVER_CORE:
                    edition = "Workgroup Storage Server (core installation)";
                    break;
                case PRODUCT_UNDEFINED:
                    edition = "Unknown product";
                    break;
                case PRODUCT_ULTIMATE:
                    edition = "Ultimate";
                    break;
                case PRODUCT_ULTIMATE_N:
                    edition = "Ultimate N";
                    break;
                case PRODUCT_ULTIMATE_E:
                    edition = "Ultimate E";
                    break;
                case PRODUCT_WEB_SERVER:
                    edition = "Web Server";
                    break;
                case PRODUCT_WEB_SERVER_CORE:
                    edition = "Web Server (core installation)";
                    break;
                case PRODUCT_ENTERPRISE_EVALUATION:
                    edition = "Server Enterprise (evaluation installation)";
                    break;
                case PRODUCT_MULTIPOINT_STANDARD_SERVER:
                    edition = "Windows MultiPoint Server Standard (full installation)";
                    break;
                case PRODUCT_MULTIPOINT_PREMIUM_SERVER:
                    edition = "Windows MultiPoint Server Premium (full installation)";
                    break;
                case PRODUCT_STANDARD_EVALUATION_SERVER:
                    edition = "Server Standard (evaluation installation)";
                    break;
                case PRODUCT_DATACENTER_EVALUATION_SERVER:
                    edition = "Server Datacenter (evaluation installation)";
                    break;
                case PRODUCT_ENTERPRISE_N_EVALUATION:
                    edition = "Enterprise N (evaluation installation)";
                    break;
                case PRODUCT_EMBEDDED_AUTOMOTIVE:
                    edition = "PRODUCT_EMBEDDED_AUTOMOTIVE"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_INDUSTRY_A:
                    edition = "PRODUCT_EMBEDDED_INDUSTRY_A"; // No known definition
                    break;
                case PRODUCT_THINPC:
                    edition = "PRODUCT_THINPC"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_A:
                    edition = "PRODUCT_EMBEDDED_A"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_INDUSTRY:
                    edition = "PRODUCT_EMBEDDED_INDUSTRY"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_E:
                    edition = "PRODUCT_EMBEDDED_E"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_INDUSTRY_E:
                    edition = "PRODUCT_EMBEDDED_INDUSTRY_E"; // No known definition
                    break;
                case PRODUCT_EMBEDDED_INDUSTRY_A_E:
                    edition = "PRODUCT_EMBEDDED_INDUSTRY_A_E"; // No known definition
                    break;
                case PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER:
                    edition = "Storage Server Workgroup (evaluation installation)";
                    break;
                case PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER:
                    edition = "Storage Server Standard (evaluation installation)";
                    break;
                case PRODUCT_CORE_ARM:
                    edition = "PRODUCT_CORE_ARM"; // No known definition
                    break;
                case PRODUCT_CORE_N:
                    edition = "Home N";
                    break;
                case PRODUCT_CORE_COUNTRYSPECIFIC:
                    edition = "Home China";
                    break;
                case PRODUCT_CORE_SINGLELANGUAGE:
                    edition = "Home Single Language";
                    break;
                case PRODUCT_CORE:
                    edition = "Home";
                    break;
                case PRODUCT_PROFESSIONAL_WMC:
                    edition = "Professional with Media Center";
                    break;
            }
            return edition;
        }
        #endregion

        #region OSVERSIONINFOEX
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
        #endregion

        [DllImport("kernel32.dll")]
        private static extern bool GetProductInfo(int osMajorVersion, int osMinorVersion,
                                                  int spMajorVersion, int spMinorVersion,
                                                  out int edition);
        [DllImport("kernel32.dll")]
        private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);

        private OSVERSIONINFOEX osVersionInfo;
        private readonly int major;
        private readonly int minor;
        public OSVersionInfo()
        {
            osVersionInfo = new OSVERSIONINFOEX {
                dwOSVersionInfoSize = Marshal.SizeOf(typeof (OSVERSIONINFOEX))
            };
            GetVersionEx(ref osVersionInfo);
            var fvi = FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "/kernel32.dll");
            major = fvi.FileMajorPart;
            minor = fvi.FileMinorPart;
        }

        private string GetName()
        {
            var name = "Unknown Name";
            switch (Environment.OSVersion.Platform) {
                case PlatformID.Win32NT:
                    var productType = osVersionInfo.wProductType;

                    switch (major) {
                        case 6:
                            switch (minor) {
                                case 0:
                                    switch (productType) {
                                        case VER_NT_WORKSTATION:
                                            name = "Windows Vista";
                                            break;
                                        case VER_NT_SERVER:
                                            name = "Windows Server 2008";
                                            break;
                                    }
                                    break;

                                case 1:
                                    switch (productType) {
                                        case VER_NT_WORKSTATION:
                                            name = "Windows 7";
                                            break;
                                        case VER_NT_SERVER:
                                            name = "Windows Server 2008 R2";
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (productType) {
                                        case VER_NT_WORKSTATION:
                                            name = "Windows 8";
                                            break;
                                        case VER_NT_SERVER:
                                            name = "Windows Server 2012";
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (productType) {
                                        case VER_NT_WORKSTATION:
                                            name = "Windows 8.1";
                                            break;
                                        case VER_NT_SERVER:
                                            name = "Windows Server 2012 R2";
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 10:
                            switch (productType) {
                                case VER_NT_WORKSTATION:
                                    name = "Windows 10";
                                    break;
                                case VER_NT_SERVER:
                                    name = "Windows Server 2016";
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return name;
        }

        private string GetEdition()
        {
            var edition = "";

            // We only support Windows Vista+
            if (major == 6) {
                int ed;
                if (GetProductInfo(major, minor, osVersionInfo.wServicePackMajor,
                    osVersionInfo.wServicePackMinor, out ed))
                {
                    edition = EditionToString(ed);
                }
            } else if (major == 10) {
                int ed;
                if (GetProductInfo(major, minor, osVersionInfo.wServicePackMajor,
                    osVersionInfo.wServicePackMinor, out ed)) {
                    edition = EditionToString(ed);
                }

            }
            return edition;
        }

        private string GetServicePack()
        {
            return osVersionInfo.szCSDVersion;
        }

        public string WindowsVersionString()
        {
            var sb = new StringBuilder();
            string name = GetName();
            string edition = GetEdition();
            string servicepack = GetServicePack();

            sb.Append("Windows Version: " + name);
            if (edition != "")
                sb.Append(" " + edition);
            if (servicepack != "")
                sb.Append(" " + servicepack);
            return sb.ToString();
        }
    }
}