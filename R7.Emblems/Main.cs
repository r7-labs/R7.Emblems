//  
//  MainWindow.cs
//  
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
// 
//  Copyright (c) 2012-2015 Roman M. Yagodin
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
using System.Reflection;
using System.Globalization;
using Gtk;
using Mono.Unix;

namespace R7.Emblems
{
	class Program
	{
		/// <summary>
		/// Gets or sets the filename to work with
		/// </summary>
		/// <value>
		/// The filename.
		/// </value>
		public static string Filename { get; set; }
				
		public static int Main (string[] args)
		{
			Catalog.Init ("r7-emblems", 
			              System.IO.Path.GetDirectoryName (
								Assembly.GetCallingAssembly ().Location) + "/locale"); 

			try
			{
				Filename = (args.Length > 0)? args [0] : null;
		
				Application.Init ();
				MainWindow win = new MainWindow ();
				win.Show ();
				Application.Run ();

				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}
		}
	
	} // class

} // namespace
