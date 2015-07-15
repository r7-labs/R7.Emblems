//
//  Gvfs.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace R7.Emblems
{
	public class Gvfs
	{
		/// <summary>
		/// Gets the emblems for file via gvfs-info
		/// </summary>
		/// <returns>
		/// The emblem names array.
		/// </returns>
		/// <param name='filename'>
		/// Filename.
		/// </param>
		public static string[] GetEmblems (string filename)
		{
			var command = new Process ();
			command.StartInfo.FileName = "gvfs-info";
			command.StartInfo.Arguments = string.Format ("-a metadata::emblems \"{0}\"", filename);
			command.StartInfo.UseShellExecute = false;
			command.StartInfo.RedirectStandardOutput = true;
			command.Start ();
			
			if (command.WaitForExit (10 * 1000)) // 10 sec
			{
				if (!command.StandardOutput.EndOfStream)
				{
					var output = command.StandardOutput.ReadToEnd ();
					output = Regex.Match (output, @"\[(.+)\]").Groups [1].Value;
					return output.Split (new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
				}
			}
			
			return null;
		}
		
		/// <summary>
		/// Unsets all emblems for file.
		/// </summary>
		/// <param name='filename'>
		/// Filename.
		/// </param>
		public static void UnsetEmblems (string filename)
		{
			var command = new Process ();
			command.StartInfo.FileName = "gvfs-set-attribute";
			command.StartInfo.Arguments = string.Format ("-t unset \"{0}\" metadata::emblems", filename);
			if (command.Start ())
				command.WaitForExit (10 * 1000);
		}
		
		/// <summary>
		/// Sets one emblem for a file via gvfs-set-attribute
		/// </summary>
		/// <param name='filename'>
		/// Filename.
		/// </param>
		/// <param name='emblemName'>
		/// Emblem name.
		/// </param>
		public static void SetEmblem (string filename, string emblemName)
		{
			var command = new Process ();
			command.StartInfo.FileName = "gvfs-set-attribute";
			command.StartInfo.Arguments = string.Format ("-t stringv \"{0}\" metadata::emblems {1}", filename, emblemName);
			if (command.Start ())
				command.WaitForExit (10 * 1000);
		}
		
		/// <summary>
		/// Sets the emblems for file via gvfs-set-attribute
		/// </summary>
		/// <param name='filename'>
		/// Filename.
		/// </param>
		/// <param name='emblemNames'>
		/// Emblem names array.
		/// </param>
		public static void SetEmblems (string filename, string [] emblemNames)
		{
			Process command = new Process ();
			command.StartInfo.FileName = "gvfs-set-attribute";
			command.StartInfo.Arguments = string.Format ("-t stringv \"{0}\" metadata::emblems {1}", 
			                                             filename, string.Join (" ", emblemNames));
			if (command.Start ())
				command.WaitForExit (10 * 1000);
		}
	}
}

