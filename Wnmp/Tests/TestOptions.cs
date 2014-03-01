using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Wnmp.Configuration;

namespace Wnmp.Tests
{
    class TestOptions
    {
        private Ini ini = new Ini();

        [Test]
        public void TestEditorSetting()
        {
            ini.UpdateSettings();
            ini.editor = "C:/TestEditor";
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual("C:/TestEditor", ini.editor);
        }
        [Test]
        public void TestStartUpWithWindowsSetting()
        {
            ini.UpdateSettings();
            ini.startupwithwindows = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.startupwithwindows);
        }
        [Test]
        public void TestStartAllAppsAtLaunchSetting()
        {
            ini.UpdateSettings();
            ini.startallapplicationsatlaunch = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.startallapplicationsatlaunch);
        }
        [Test]
        public void TestMinimizeWnmpToTraySetting()
        {
            ini.UpdateSettings();
            ini.minimizewnmptotray = true;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(true, ini.minimizewnmptotray);
        }
        [Test]
        public void TestAutoCheckForUpdatesSetting()
        {
            ini.UpdateSettings();
            ini.autocheckforupdates = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.autocheckforupdates);
        }
        [Test]
        public void TestCheckForUpdateFrequencySetting()
        {
            ini.UpdateSettings();
            ini.checkforupdatefrequency = 1;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(1, ini.checkforupdatefrequency);
        }
        [Test]
        public void TestLastCheckForUpdateSetting()
        {
            ini.UpdateSettings();
            ini.lastcheckforupdate = DateTime.Now;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(DateTime.Now.ToShortDateString(), ini.lastcheckforupdate.ToShortDateString());
        }
        [Test]
        public void TestFirstRunSetting()
        {
            ini.UpdateSettings();
            ini.firstrun = false;
            ini.UpdateSettings();
            ini.ReadSettings();

            Assert.AreEqual(false, ini.firstrun);
        }

    }
}
