//  
//  MainWindow.cs
//  
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
// 
//  Copyright (c) 2012-2013  Roman M. Yagodin
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Gtk;

namespace R7.Emblems
{
	// TODO: Split EmblemButton.cs on two classes - one for a button, and one for gvfs- utilities

	/// <summary>
	/// Emblem button.
	/// </summary>
	public class EmblemButton: CheckButton
	{
		//public CheckButton Button { get; set; }
		public string IconName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="R7.Nautilus.Emblems.EmblemButton"/> class.
		/// </summary>
		public EmblemButton ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="R7.Nautilus.Emblems.EmblemButton"/> class.
		/// </summary>
		/// <param name='iconName'>
		/// Icon name like "emblem-cool"
		/// </param>
		/// <param name='label'>
		/// Label to show in button.
		/// </param>
		/// <param name='size'>
		/// Icon size, in px.
		/// </param>
		public EmblemButton (string iconName, string label, int size)
		{
			Label = label; 
			TooltipText = iconName;
			IconName = iconName;
			DrawIndicator = true;
			Image = new Image(IconTheme.Default.LoadIcon(iconName, size, (IconLookupFlags)0));
		}
	
	} // class

} // namespace
