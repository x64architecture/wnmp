using System;
using System.Diagnostics;
using NUnit.Framework;

using Wnmp.Helpers;
namespace Wnmp.Tests
{
    public class TestOSInfo
    {
        [Test]
        public void TestW81OSName()
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "/Kernel32.dll");
            var major = fvi.FileMajorPart;
            var minor = fvi.FileMinorPart;

            if (major == 6 && minor == 3)
            {
                Assert.AreEqual("Windows 8.1", OSVersionInfo.Name);
            }
            else if (major == 6 && minor == 2)
            {
                Assert.AreEqual("Windows 8", OSVersionInfo.Name);
            }
            else if (major == 6 && minor == 1)
            {
                Assert.AreEqual("Windows 7", OSVersionInfo.Name);
            }
            else if (major == 6 && minor == 0)
            {
                Assert.AreEqual("Windows Vista", OSVersionInfo.Name);
            }
            else
            {
                Assert.Ignore();
            }
        }
    }
}
