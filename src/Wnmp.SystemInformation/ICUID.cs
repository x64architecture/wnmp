/*
 * Copyright (c) 2016, Kurt Cancemi (kurt@x64architecture.com)
 *
 * Permission to use, copy, modify, and/or distribute this software for any
 * purpose with or without fee is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 * WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 * MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 * ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 * WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
 * ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
 * OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;

namespace Wnmp.SystemInformation
{
    public class ICUID
    {
        #region cpuid_feature_t
        public enum cpuid_feature_t
        {
            CPU_FEATURE_PNI = 0,
            CPU_FEATURE_PCLMULDQ,
            CPU_FEATURE_DTS64,
            CPU_FEATURE_MONITOR,
            CPU_FEATURE_DS_CPL,
            CPU_FEATURE_VMX,
            CPU_FEATURE_SMX,
            CPU_FEATURE_EST,
            CPU_FEATURE_TM2,
            CPU_FEATURE_SSSE3,
            CPU_FEATURE_CID,
            CPU_FEATURE_SDBG,
            CPU_FEATURE_FMA,
            CPU_FEATURE_CX16,
            CPU_FEATURE_XTPR,
            CPU_FEATURE_PDCM,
            CPU_FEATURE_PCID,
            CPU_FEATURE_DCA,
            CPU_FEATURE_SSE4_1,
            CPU_FEATURE_SSE4_2,
            CPU_FEATURE_X2APIC,
            CPU_FEATURE_MOVBE,
            CPU_FEATURE_POPCNT,
            CPU_FEATURE_TSC_DEADLINE,
            CPU_FEATURE_AES,
            CPU_FEATURE_XSAVE,
            CPU_FEATURE_OSXSAVE,
            CPU_FEATURE_AVX,
            CPU_FEATURE_F16C,
            CPU_FEATURE_RDRAND,
            CPU_FEATURE_HYPERVISOR,
            CPU_FEATURE_FPU,
            CPU_FEATURE_VME,
            CPU_FEATURE_DE,
            CPU_FEATURE_PSE,
            CPU_FEATURE_TSC,
            CPU_FEATURE_MSR,
            CPU_FEATURE_PAE,
            CPU_FEATURE_MCE,
            CPU_FEATURE_CX8,
            CPU_FEATURE_APIC,
            CPU_FEATURE_SEP,
            CPU_FEATURE_MTRR,
            CPU_FEATURE_PGE,
            CPU_FEATURE_MCA,
            CPU_FEATURE_CMOV,
            CPU_FEATURE_PAT,
            CPU_FEATURE_PSE36,
            CPU_FEATURE_PN,
            CPU_FEATURE_CLFLUSH,
            CPU_FEATURE_DTS,
            CPU_FEATURE_ACPI,
            CPU_FEATURE_MMX,
            CPU_FEATURE_FXSR,
            CPU_FEATURE_SSE,
            CPU_FEATURE_SSE2,
            CPU_FEATURE_SS,
            CPU_FEATURE_HT,
            CPU_FEATURE_TM,
            CPU_FEATURE_IA64,
            CPU_FEATURE_PBE,
            CPU_FEATURE_FSGSBASE,
            CPU_FEATURE_TSC_ADJUST,
            CPU_FEATURE_BMI1,
            CPU_FEATURE_HLE,
            CPU_FEATURE_AVX2,
            CPU_FEATURE_SMEP,
            CPU_FEATURE_BMI2,
            CPU_FEATURE_ERMS,
            CPU_FEATURE_INVPCID,
            CPU_FEATURE_RTM,
            CPU_FEATURE_CQM,
            CPU_FEATURE_MPX,
            CPU_FEATURE_AVX512F,
            CPU_FEATURE_AVX512DQ,
            CPU_FEATURE_RDSEED,
            CPU_FEATURE_ADX,
            CPU_FEATURE_SMAP,
            CPU_FEATURE_PCOMMIT,
            CPU_FEATURE_CLFLUSHOPT,
            CPU_FEATURE_CLWB,
            CPU_FEATURE_AVX512PF,
            CPU_FEATURE_AVX512ER,
            CPU_FEATURE_AVX512CD,
            CPU_FEATURE_SHA,
            CPU_FEATURE_AVX512BW,
            CPU_FEATURE_AVX512VL,
            CPU_FEATURE_LAHF_LM,
            CPU_FEATURE_CMP_LEGACY,
            CPU_FEATURE_SVM,
            CPU_FEATURE_EXTAPIC,
            CPU_FEATURE_CR8_LEGACY,
            CPU_FEATURE_ABM,
            CPU_FEATURE_SSE4A,
            CPU_FEATURE_MISALIGNSSE,
            CPU_FEATURE_3DNOWPREFETCH,
            CPU_FEATURE_OSVW,
            CPU_FEATURE_IBS,
            CPU_FEATURE_XOP,
            CPU_FEATURE_SKINIT,
            CPU_FEATURE_WDT,
            CPU_FEATURE_LWP,
            CPU_FEATURE_FMA4,
            CPU_FEATURE_TCE,
            CPU_FEATURE_NODEID_MSR,
            CPU_FEATURE_TBM,
            CPU_FEATURE_TOPOEXT,
            CPU_FEATURE_PERFCTR_CORE,
            CPU_FEATURE_PERFCTR_NB,
            CPU_FEATURE_BPEXT,
            CPU_FEATURE_PERFCTR_L2,
            CPU_FEATURE_MONITORX,
            CPU_FEATURE_SYSCALL,
            CPU_FEATURE_NX,
            CPU_FEATURE_MMXEXT,
            CPU_FEATURE_FXSR_OPT,
            CPU_FEATURE_PDPE1GB,
            CPU_FEATURE_RDTSCP,
            CPU_FEATURE_LM,
            CPU_FEATURE_3DNOWEXT,
            CPU_FEATURE_3DNOW,
            CPU_FEATURE_TS,
            CPU_FEATURE_FID,
            CPU_FEATURE_VID,
            CPU_FEATURE_TTP,
            CPU_FEATURE_TM_AMD,
            CPU_FEATURE_STC,
            CPU_FEATURE_100MHZSTEPS,
            CPU_FEATURE_HWPSTATE,
            CPU_FEATURE_CONSTANT_TSC,
            CPU_FEATURE_CPB,
            CPU_FEATURE_APERFMPERF,
            CPU_FEATURE_PFI,
            CPU_FEATURE_PA,
            CPU_FEATURE_CLZERO,
            CPU_FEATURE_IRPERF,
            NUM_CPU_FEATURES
        }
        #endregion

        #region cpu_vendor_t
        public enum cpu_vendor_t
        {
            VENDOR_UNKNOWN = 0,
            VENDOR_INTEL,
            VENDOR_AMD,
            VENDOR_CYRIX,
            VENDOR_NEXGEN,
            VENDOR_TRANSMETA,
            VENDOR_UMC,
            VENDOR_CENTAUR,
            VENDOR_RISE,
            VENDOR_SIS,
            VENDOR_NSC,
            VENDOR_VIA,
            VENDOR_HV_KVM,
            VENDOR_HV_HYPERV,
            VENDOR_HV_VMWARE,
            VENDOR_HV_XEN,
            NUM_CPU_VENDORS
        }
        #endregion

        private cpuid_data_t data;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct cpuid_data_t
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string vendor_str;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
            public string brand_str;
            public cpu_vendor_t vendor;
            public byte family;
            public byte model;
            public byte stepping;
            public byte ext_family;
            public byte ext_model;
            public byte type;
            public uint signature;
            public IntPtr codename;
            public uint cpuid_max_basic;
            public uint cpuid_max_ext;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 140)]
            public byte[] flags;
            public uint cores;
            public uint logical_cpus;
            public uint l1_data_cache;
            public uint l1_instruction_cache;
            public uint l2_cache;
            public uint l3_cache;
            public uint l1_associativity;
            public uint l2_associativity;
            public uint l3_associativity;
            public uint l1_cacheline;
            public uint l2_cacheline;
            public uint l3_cacheline;
            public uint physical_address_bits;
            public uint virtual_address_bits;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] xfeatures;
        }

        [DllImport("libicuid.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int icuid_identify(IntPtr raw, ref cpuid_data_t data);

        [DllImport("libicuid.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int cpuid_is_supported();

        [DllImport("libicuid.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr cpu_feature_str(cpuid_feature_t feature);

        public ICUID()
        {
            icuid_identify(IntPtr.Zero, ref data);
        }

        public string GetVendorString() { return data.vendor_str; }
        public string GetBrandString() { return data.brand_str; }
        public string GetCodenameString() { return Marshal.PtrToStringAnsi(data.codename); }
        public string FeatureToString(cpuid_feature_t feature)
        {
            var FeatureStr = Marshal.PtrToStringAnsi(cpu_feature_str(feature));
            if (FeatureStr != null)
                return FeatureStr.ToUpper();

            return "";
        }

        public bool CPUSupports(cpuid_feature_t feature)
        {
            return Convert.ToBoolean(data.flags[(int)feature]);
        }
        public bool CPUIDSupported()
        {
            return Convert.ToBoolean(cpuid_is_supported());
        }
    }
}
