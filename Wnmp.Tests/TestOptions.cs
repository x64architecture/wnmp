using System;
using NUnit.Framework;

using Wnmp.Configuration;
namespace Wnmp.Tests
{
    public class TestOptions
    {
        private readonly Ini ini = new Ini();

        [Test]
        public void TestEditorSetting()
        {
            ini.UpdateSettings();
            ini.Editor = "C:/TestEditor";
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual("C:/TestEditor", ini.Editor);
        }
        [Test]
        public void TestStartUpWithWindowsSetting()
        {
            ini.UpdateSettings();
            ini.Startupwithwindows = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.Startupwithwindows);
        }
        [Test]
        public void TestStartAllAppsAtLaunchSetting()
        {
            ini.UpdateSettings();
            ini.Startallappsatlaunch = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.Startallappsatlaunch);
        }
        [Test]
        public void TestMinimizeWnmpToTraySetting()
        {
            ini.UpdateSettings();
            ini.Minimizewnmptotray = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.Minimizewnmptotray);
        }
        [Test]
        public void TestAutoCheckForUpdatesSetting()
        {
            ini.UpdateSettings();
            ini.Autocheckforupdates = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.Autocheckforupdates);
        }
        [Test]
        public void TestCheckForUpdateFrequencySetting()
        {
            ini.UpdateSettings();
            ini.Checkforupdatefrequency = 1;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(1, ini.Checkforupdatefrequency);
        }
        [Test]
        public void TestLastCheckForUpdateSetting()
        {
            ini.UpdateSettings();
            ini.Lastcheckforupdate = DateTime.Now;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(DateTime.Now.ToShortDateString(), ini.Lastcheckforupdate.ToShortDateString());
        }
        [Test]
        public void TestFirstRunSetting()
        {
            ini.UpdateSettings();
            ini.Firstrun = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.Firstrun);
        }

    }
}
