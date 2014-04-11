/*
Copyright (c) Kurt Cancemi 2012-2014

This file is part of Wnmp.

    Wnmp is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Wnmp is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Wnmp.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Drawing;
using System.Windows.Forms;

namespace Wnmp.Internals
{
    /// <summary>
    /// Commonly used variables
    /// </summary>
    class Common
    {
        public const int WS_THICKFRAME = 0x00040000;

        /// <summary>
        /// Changes the labels apperance to started
        /// </summary>
        /// <param name="label"></param>
        public static void ToStartedLabel(Label label)
        {
            label.Text = "\u221A";
            label.ForeColor = Color.Green;
        }
        /// <summary>
        /// Changes the labels apperance to stopped
        /// </summary>
        /// <param name="label"></param>
        public static void ToStoppedLabel(Label label)
        {
            label.Text = "X";
            label.ForeColor = Color.DarkRed;
        }
    }
}
