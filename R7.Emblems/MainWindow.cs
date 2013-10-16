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

// TODO: "Reset all" button / option
// TODO: Refactoring and exception handling, e.g. if file deleted / moved
// THINK: Automatically update Nautilus window to reflect changes (without F5)
// THINK: Support for system catalogs in localization
// THINK: Support for user-defined emblems with localization
// THINK: Using iconview to select emblems

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Mono.Unix;

namespace R7.Emblems
{
	public partial class MainWindow: Gtk.Window
	{	
		/// <summary>
		/// A dummy method just to create gettext catalog entries,
		/// cause those strings have not explicitly showed up in UI 
		/// </summary>
		protected void LocalizeDummy ()
		{
			Catalog.GetString("remmina-vnc");
			Catalog.GetString("remmina-sftp");
			Catalog.GetString("emblem-sales");
			Catalog.GetString("emblem-money");
			Catalog.GetString("emblem-sound");
			Catalog.GetString("emblem-documents-symbolic");
			Catalog.GetString("emblem-marketing");
			Catalog.GetString("emblem-shared");
			Catalog.GetString("emblem-development");
			Catalog.GetString("emblem-system");
			Catalog.GetString("emblem-mail");
			Catalog.GetString("emblem-ubuntuone-synchronized");
			Catalog.GetString("emblem-cool");
			Catalog.GetString("emblem-synchronizing-symbolic");
			Catalog.GetString("emblem-urgent");
			Catalog.GetString("emblem-presentation");
			Catalog.GetString("emblem-nowrite");
			Catalog.GetString("remmina-xdmcp");
			Catalog.GetString("emblem-music-symbolic");
			Catalog.GetString("emblem-ok-symbolic");
			Catalog.GetString("emblem-important");
			Catalog.GetString("emblem-important-symbolic");
			Catalog.GetString("slideshow-emblem");
			Catalog.GetString("emblem-documents");
			Catalog.GetString("emblem-downloads");
			Catalog.GetString("emblem-photos-symbolic");
			Catalog.GetString("emblem-OK");
			Catalog.GetString("emblem-camera");
			Catalog.GetString("emblem-multimedia");
			Catalog.GetString("emblem-readonly");
			Catalog.GetString("remmina-nx");
			Catalog.GetString("emblem-desktop");
			Catalog.GetString("emblem-favorite");
			Catalog.GetString("emblem-unreadable");
			Catalog.GetString("emblem-web");
			Catalog.GetString("emblem-new");
			Catalog.GetString("emblem-system-symbolic");
			Catalog.GetString("emblem-shared-symbolic");
			Catalog.GetString("emblem-favorite-symbolic");
			Catalog.GetString("emblem-videos-symbolic");
			Catalog.GetString("emblem-photos");
			Catalog.GetString("remmina-rdp");
			Catalog.GetString("emblem-art");
			Catalog.GetString("emblem-generic");
			Catalog.GetString("emblem-default-symbolic");
			Catalog.GetString("emblem-ubuntuone-updating");
			Catalog.GetString("emblem-people");
			Catalog.GetString("emblem-ohno");
			Catalog.GetString("emblem-ubuntuone-unsynchronized");
			Catalog.GetString("emblem-package");
			Catalog.GetString("emblem-videos");
			Catalog.GetString("remmina-rdp-ssh");
			Catalog.GetString("emblem-personal");
			Catalog.GetString("emblem-noread");
			Catalog.GetString("emblem-pictures");
			Catalog.GetString("emblem-draft");
			Catalog.GetString("emblem-danger");
			Catalog.GetString("remmina-xdmcp-ssh");
			Catalog.GetString("emblem-default");
			Catalog.GetString("emblem-plan");
			Catalog.GetString("emblem-synchronizing");
			Catalog.GetString("remmina-vnc-ssh");
			Catalog.GetString("emblem-symbolic-link");
		}

		/// <summary>
		/// Tries the get local label for icon name
		/// </summary>
		/// <returns>
		/// The local label.
		/// </returns>
		/// <param name='iconname'>
		/// Icon name.
		/// </param>
		protected string TryGetLocalLabel (string iconname)
		{
			// try get a local name
			var label = Catalog.GetString (iconname);

			if (label == iconname)
			{
				// apply some transformations 
				// in attempt to get "valid" English name - 
				// too entusiastic?

				// remove known prefixes and suffixes
				label = label.Replace ("emblem-", "")
						   .Replace("-emblem","")
						   .Replace("-symbolic","")
						   .Replace("ubuntuone-","");

				// Remmina icons are for protocols, 
				// so uppercase them looks fine
				if (label.ToLowerInvariant().StartsWith("remmina-"))
				{
					label = label.Replace("remmina-","").ToUpper();
				}
				else 
				{
					// Replace dashes with spaces - 
					// but not for remmina:
					label = label.Replace("-", " ");
				}

				// Remove duplicate spaces
				label = Regex.Replace(label, @"\s+", " ");

				// Uppercase first character
				label = label.ToUpper () [0].ToString () + label.Substring(1);
			}
				
			return label;
		}

		/// <summary>
		/// Gets or sets the emblembuttons list.
		/// </summary>
		/// <value>
		/// The emblems.
		/// </value>
		protected List<EmblemButton> Emblems { get; set; }

		protected void ResetEmblemButtons (List<EmblemButton> emblems)
		{
			foreach (var emblem in emblems)
				emblem.Active = false;
		}

		protected List<EmblemButton> CreateEmblemButtons ()
		{
			IconTheme theme = IconTheme.Default;
			var icons = theme.ListIcons("Emblems");
			
			/* // list all emblems in default theme
			foreach (string icon in icons)
				Console.WriteLine(icon);
				*/
			
			Emblems = new List<EmblemButton>(icons.Length);
			
			foreach (var icon in icons)
				Emblems.Add(new EmblemButton (icon, TryGetLocalLabel(icon), 24));

			return Emblems;
		}

		protected void FillTable (uint ncolumns, List<EmblemButton> emblems)
		{
			tableEmblems.NColumns = ncolumns;
			tableEmblems.NRows = (uint)Math.Ceiling ((double)emblems.Count / tableEmblems.NColumns);
		
			// attach indexes
			long left = 0;
			long top = 0;
		
			foreach (var emblem in emblems)
			{
				tableEmblems.Attach (emblem, 
			                     (uint)left, (uint)(left + 1), (uint)top, (uint)(top + 1), 
			                     AttachOptions.Expand | AttachOptions.Fill, 
			                     AttachOptions.Expand | AttachOptions.Fill, 0, 0);
			
				top = (left + 1 > tableEmblems.NColumns - 1) ? top + 1 : top;
				left = (left + 1) % tableEmblems.NColumns;
			}
			tableEmblems.ShowAll ();
		}

		protected void ApplyFileEmblems (List<EmblemButton> emblems, string [] fileEmblems)
		{
			foreach (var emblem in emblems)
			{
				emblem.Active = false;
				
				foreach (var e1 in fileEmblems)
					if (e1 == emblem.IconName || "emblem-" + e1 == emblem.IconName)
				{
					emblem.Active = true;
					break;
				}
			}
		}

		/// <summary>
		/// Updates the filemanager view of specified filename to show emblem changes
		/// </summary>
		/// <param name='filename'>
		/// Filename to update view.
		/// </param>
		protected void UpdateView (string filename)
		{
			try
			{
				// HACK: renaming file or folder twice, so filemanager is "forced" to update view. Using gnome-vfs-sharp for this?
				var suffix = "_" + Guid.NewGuid ().ToString ();
				File.Move (filename, filename + suffix);
				File.Move (filename + suffix, filename);
			}
			catch
			{
				// just let it be...
			}
		}

		/// <summary>
		/// Sets the file chooser action and changes title and corresponding radiogroup state
		/// </summary>
		/// <param name='fc'>
		/// File chooser button.
		/// </param>
		/// <param name='action'>
		/// Action to set.
		/// </param>
		protected void SetFileChooserAction (FileChooserButton fc, FileChooserAction action)
		{
			fc.Action = action;

			if (fc.Action == FileChooserAction.Open)
			{
				radioFile.Active = true;
				fc.Title = Catalog.GetString ("Select a file");
			}
			else
			{
				radioFolder.Active = true;
				fc.Title = Catalog.GetString ("Select a folder");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="R7.Nautilus.Emblems.MainWindow"/> class
		/// </summary>
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			this.Build ();

			this.Title = Catalog.GetString ("Emblems");

			// FIXME: Icon in a window is blurry, is it really SVG?
			// FIXME: emblem-favorite or other may not exist in a theme!
			this.Icon = IconTheme.Default.LoadIcon("emblem-favorite", 48, IconLookupFlags.ForceSvg);

			Emblems = CreateEmblemButtons ();
			FillTable (3, Emblems);

			// TODO: Check if file exists and accessible

			// Stetic not saving properties fix
			filechooser1.BorderWidth = 6;

			// no file passed to commandline, set home folder
			if (string.IsNullOrWhiteSpace (Program.Filename))
			{
				SetFileChooserAction (filechooser1,  FileChooserAction.SelectFolder);

				filechooser1.SetCurrentFolder (
						Environment.GetFolderPath (Environment.SpecialFolder.Personal));

				//Console.WriteLine (Environment.GetFolderPath (Environment.SpecialFolder.Personal));
			}
			// directory passed, set it
			else if ((File.GetAttributes (Program.Filename) & FileAttributes.Directory) > 0)
			{
				SetFileChooserAction (filechooser1, FileChooserAction.SelectFolder);
				filechooser1.SetCurrentFolder (Program.Filename);
			}
			// file passed, set it
			else
			{
				SetFileChooserAction (filechooser1, FileChooserAction.Open);
				filechooser1.SetFilename (Program.Filename);
			}

			if (string.IsNullOrWhiteSpace (Program.Filename))
			{
				tableEmblems.Sensitive = false;
			}
			else
			{
				filechooser1.SetFilename(Program.Filename);
				var fileEmblems = Gvfs.GetEmblems (Program.Filename);
				ApplyFileEmblems(Emblems, fileEmblems);
			}
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}

		protected void OnButton3Clicked (object sender, System.EventArgs e)
		{
			Application.Quit ();
		}

		protected void OnButton2Clicked (object sender, System.EventArgs e)
		{
			var selectedEmblems = new List<string> (Emblems.Count);

			foreach (var em in Emblems)
				if (em.Active)
					selectedEmblems.Add(em.IconName.Replace("emblem-", ""));
			
			if (selectedEmblems.Count > 0)
				Gvfs.SetEmblems (Program.Filename, selectedEmblems.ToArray());
			else
				Gvfs.UnsetEmblems (Program.Filename);

			UpdateView (Program.Filename);

			Application.Quit ();
		}

		protected void OnFilechooser1SelectionChanged (object sender, EventArgs e)
		{
			tableEmblems.Sensitive = true;
			Program.Filename = filechooser1.Filename;
			var fileEmblems = Gvfs.GetEmblems (Program.Filename);
			ResetEmblemButtons(Emblems);
			ApplyFileEmblems(Emblems, fileEmblems);
		}

		protected void OnButtonAboutClicked (object sender, EventArgs e)
		{
			var about = new AboutDialog();
			about.ProgramName = Catalog.GetString("Emblems");
			about.Authors = new string [] { Catalog.GetString("Roman M. Yagodin <roman.yagodin@gmail.com>") };
			about.TranslatorCredits = Catalog.GetString("English, Russian") + " - " + Catalog.GetString("Roman M. Yagodin <roman.yagodin@gmail.com>");
			about.WebsiteLabel = "github.com/roman-yagodin/r7-emblems";
			about.Website = "https://github.com/roman-yagodin/r7-emblems";
			about.Copyright = "2012-2013 " + Catalog.GetString("Roman M. Yagodin <roman.yagodin@gmail.com>");

			// FIXME: If icon was not found, causes dialog to crash
			about.Logo = IconTheme.Default.LoadIcon("emblem-favorite", 48, 0);
			about.Run ();
			about.Destroy ();
		}

		protected void OnRadioFileToggled (object sender, EventArgs e)
		{
			SetFileChooserAction (filechooser1, (sender as RadioButton).Active? 
				FileChooserAction.Open : FileChooserAction.SelectFolder);
		}	
	}
}
