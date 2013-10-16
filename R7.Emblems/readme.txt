== Installation ==

	1) Install nautilus-actions package, if you want:
	>  sudo apt-get install nautilus-actions
	2) Unpack downloaded binary package.
	3) Go to package folder and run install script:
	>  ./install.sh
	
	Program will be installed with /usr/local prefix by default,
	and will make shortcut in ~/.local/share/file-manager/actions
	for nautilus-actions package
	
== R7.Emblems changelog ==	
	
Feature versions:	
	
	? Add program icon to a window
	? Install nautilus-actions desktop shortcut for all users.
	? Uninstall nautilus-actions desktop shortcut.
	? Use Autotools to make tarball package.	
	? Using expanders to visually categorize icons: common, symbolic, ubuntuone, remmina, etc.
	? Sort icons by selection status.
	? "Unselect all" button.
	? Rows / columns count passing from command-line (or in app.config?)
	? Explore gnome-vfs-sharp features.
	
Version 1.1

	- Simple install / uninstall / run scripts.
	- Checking nautilus-actions installation in install.sh.
	- Start application w/o parameters (filechooser button used).
	- Ability to select file or folder in filechooser
	- Project updated to NET 4.0 profile.
	- Use current icon theme to fill emblems list instead of scanning for files.
	- Added scrollbars to table with icons (there are many of them now).
	- Icon name to button label mapping are up gettext, added EN translation.
	- Fixed current locale. Shell script emblems.sh no longer needed and removed.
	- Monodevelop packaging project in solution.
	- Desktop shortcut files for menu and nautilus-actions.
	- Some code refactoring.
	
Version 1.0

	- Initial release.
