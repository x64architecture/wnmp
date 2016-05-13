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

using System.IO;

namespace Wnmp.Configuration
{
    class PHPConfigurationManager
    {
        public bool[] UserPHPExtentionValues;
        public string[] phpExtName;
        public bool[] phpExtEnabled;

        private bool[] zendExt;
        private string ExtensionPath;
        private string IniFilePath;
        private string TmpIniFile;

        private void LoadPHPIni()
        {
            TmpIniFile = File.ReadAllText(IniFilePath);
        }

        public void LoadPHPExtensions(string phpBinPath)
        {
            if (phpBinPath == "Default") {
                ExtensionPath = UI.Main.StartupPath + "/php/ext/";
                IniFilePath = UI.Main.StartupPath + "/php/php.ini";
            } else {
                ExtensionPath = UI.Main.StartupPath + "/php/phpbins/" + phpBinPath + "/ext/";
                IniFilePath = UI.Main.StartupPath + "/php/phpbins/" + phpBinPath + "/php.ini";
            }

            if (!Directory.Exists(ExtensionPath))
                return;
            phpExtName = Directory.GetFiles(ExtensionPath, "*.dll");
            phpExtEnabled = new bool[phpExtName.Length];
            zendExt = new bool[phpExtName.Length];
            UserPHPExtentionValues = new bool[phpExtName.Length];

            for (var i = 0; i < phpExtName.Length; i++) {
                phpExtName[i] = phpExtName[i].Remove(0, ExtensionPath.Length);
            }

            LoadPHPIni();
            ParsePHPIni();
        }

        public void ParsePHPIni()
        {
            using (var sr = new StringReader(TmpIniFile)) {
                string str;
                while ((str = sr.ReadLine()) != null) {
                    for (var i = 0; i < phpExtName.Length; i++) {
                        if (str.StartsWith(";extension=" + phpExtName[i])) {
                            phpExtEnabled[i] = false;
                            zendExt[i] = false;
                            break;
                        }
                        if (str.StartsWith("extension=" + phpExtName[i])) {
                            phpExtEnabled[i] = true;
                            zendExt[i] = false;
                            break;
                        }
                        if (str.StartsWith(";zend_extension=" + phpExtName[i])) {
                            phpExtEnabled[i] = false;
                            zendExt[i] = true;
                            break;
                        }
                        if (str.StartsWith("zend_extension=" + phpExtName[i])) {
                            phpExtEnabled[i] = true;
                            zendExt[i] = true;
                            break;
                        }
                    }
                }
            }
        }

        public void SavePHPIniOptions()
        {
            for (var i = 0; i < phpExtName.Length; i++) {
                if (zendExt[i] == false) {
                    if (UserPHPExtentionValues[i]) {
                        if (phpExtEnabled[i] == false)
                            TmpIniFile = TmpIniFile.Replace(";extension=" + phpExtName[i], "extension=" + phpExtName[i]);
                    } else {
                        if (phpExtEnabled[i] == true)
                            TmpIniFile = TmpIniFile.Replace("extension=" + phpExtName[i], ";extension=" + phpExtName[i]);
                    }
                } else { // Special case zend_extension
                    if (UserPHPExtentionValues[i]) {
                        if (phpExtEnabled[i] == false)
                            TmpIniFile = TmpIniFile.Replace(";zend_extension=" + phpExtName[i], "zend_extension=" + phpExtName[i]);
                    } else {
                        if (phpExtEnabled[i] == true)
                            TmpIniFile = TmpIniFile.Replace("zend_extension=" + phpExtName[i], ";zend_extension=" + phpExtName[i]);
                    }
                }
            }
            File.WriteAllText(IniFilePath, TmpIniFile);
        }
    }
}
