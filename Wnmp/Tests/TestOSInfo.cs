using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Wnmp.Helpers;

namespace Wnmp.Tests
{
    class TestOSInfo
    {
        [Test]
        public void TestW81OSName()
        {
            int major = Environment.OSVersion.Version.Major;
            int minor = Environment.OSVersion.Version.Minor;

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
