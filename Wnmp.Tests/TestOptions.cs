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
            ini.RunAppsAtLaunch = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.RunAppsAtLaunch);
        }
        [Test]
        public void TestMinimizeWnmpToTraySetting()
        {
            ini.UpdateSettings();
            ini.MinimizeWnmpToTray = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.MinimizeWnmpToTray);
        }
        [Test]
        public void TestAutoCheckForUpdatesSetting()
        {
            ini.UpdateSettings();
            ini.AutoCheckForUpdates = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.AutoCheckForUpdates);
        }
        [Test]
        public void TestCheckForUpdateFrequencySetting()
        {
            ini.UpdateSettings();
            ini.UpdateFrequency = 1;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(1, ini.UpdateFrequency);
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
            ini.FirstRun = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.FirstRun);
        }

    }
}
