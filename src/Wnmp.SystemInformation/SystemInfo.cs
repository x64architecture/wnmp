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

using System.Text;
using System;
using static Wnmp.SystemInformation.ICUID.cpuid_feature_t;

namespace Wnmp.SystemInformation
{
    /// <summary>
    /// Provides detailed information about the host operating system.
    /// </summary>
    public class SystemInfo
    {
        public ICUID icuid = new ICUID();
        private readonly OSVersionInfo OVI = new OSVersionInfo();

        public string CommonCPUFeatures()
        {
            var sb = new StringBuilder();

            if (icuid.CPUSupports(CPU_FEATURE_SSE))
                sb.Append(" SSE,");
            if (icuid.CPUSupports(CPU_FEATURE_SSE2))
                sb.Append(" SSE2,");
            if (icuid.CPUSupports(CPU_FEATURE_PNI))
                sb.Append(" SSE3,");
            if (icuid.CPUSupports(CPU_FEATURE_SSSE3))
                sb.Append(" SSSE3,");
            if (icuid.CPUSupports(CPU_FEATURE_VMX))
                sb.Append(" VT-x,");
            if (icuid.CPUSupports(CPU_FEATURE_SVM))
                sb.Append(" AMD-V,");
            if (icuid.CPUSupports(CPU_FEATURE_AES))
                sb.Append(" AES,");
            if (icuid.CPUSupports(CPU_FEATURE_AVX))
                sb.Append(" AVX,");
            if (icuid.CPUSupports(CPU_FEATURE_AVX2))
                sb.Append(" AVX2,");

            try {
                sb.Remove(0, 1);
                sb.Remove(sb.Length - 1, 1);
            } catch (IndexOutOfRangeException) { }

            return sb.ToString();
        }
        public string WindowsVersionString()
        {
            return OVI.WindowsVersionString();
        }
    }
}
