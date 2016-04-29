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
using System.Drawing;
using System.Windows.Forms;

using Wnmp.Configuration;
using Wnmp.UI;

namespace Wnmp.Programs
{
    public class WnmpProgram
    {
        public Label statusLabel { get; set; } // Label that shows the programs status
        public string exeName { get; set; }    // Location of the executable file
        public string procName { get; set; }   // Name of the process
        public string progName { get; set; }   // User-friendly name of the program 
        public Log.LogSection progLogSection { get; set; } // LogSection of the program
        public string startArgs { get; set; }  // Start Arguments
        public string stopArgs { get; set; }   // Stop Arguments if KillStop is false
        public bool killStop { get; set; }     // Kill process instead of stopping it gracefully
        public string confDir { get; set; }    // Directory where all the programs configuration files are
        public string logDir { get; set; }     // Directory where all the programs log files are
        public Ini Settings { get; set; }
        public ContextMenuStrip configContextMenu { get; set; } // Displays all the programs config files in |confDir|
        public ContextMenuStrip logContextMenu { get; set; }    // Displays all the programs log files in |logDir|
  
        public Process ps = new Process();

        public WnmpProgram()
        {
            configContextMenu = new ContextMenuStrip();
            logContextMenu = new ContextMenuStrip();
            configContextMenu.ItemClicked += configContextMenu_ItemClicked;
            logContextMenu.ItemClicked += logContextMenu_ItemClicked;
        }

        /// <summary>
        /// Changes the labels apperance to started
        /// </summary>
        private void SetStartedLabel()
        {
            statusLabel.Text = "\u221A";
            statusLabel.ForeColor = Color.Green;
        }

        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        private void SetStoppedLabel()
        {
            statusLabel.Text = "X";
            statusLabel.ForeColor = Color.DarkRed;
        }

        public void SetStatusLabel()
        {
            if (this.IsRunning() == true)
                SetStartedLabel();
            else
                SetStoppedLabel();
        }

        public void StartProcess(string exe, string args, bool wait = false)
        {
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ps.Start();

            if (wait) {
                ps.WaitForExit();
            }
        }
        public virtual void Start()
        {
            try {
                StartProcess(exeName, startArgs);
                Log.wnmp_log_notice("Started " + progName, progLogSection);
            } catch (Exception ex) {
                Log.wnmp_log_error("Start(): " + ex.Message, progLogSection);
            }
        }

        public virtual void Stop()
        {
            if (killStop == false)
                StartProcess(exeName, stopArgs, true);

            var processes = Process.GetProcessesByName(procName);
            foreach (var process in processes) {
                    process.Kill();
            }
            Log.wnmp_log_notice("Stopped " + progName, progLogSection);
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
            Log.wnmp_log_notice("Restarted " + progName, progLogSection);
        }

        public void ConfigButton(object sender)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            configContextMenu.Show(ptLowerLeft);
        }

        public void LogButton(object sender)
        {
            var btnSender = (Button)sender;
            var ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            logContextMenu.Show(ptLowerLeft);
        }

        private void configContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Settings.Editor.Value, Main.StartupPath + confDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        private void logContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try {
                Process.Start(Settings.Editor.Value, Main.StartupPath + logDir + e.ClickedItem.Text);
            } catch (Exception ex) {
                Log.wnmp_log_error(ex.Message, progLogSection);
            }
        }

        public bool IsRunning()
        {
            var processes = Process.GetProcessesByName(procName);

            return (processes.Length != 0);
        }
    }
}
