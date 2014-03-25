R7.Emblems
==========

Simple GTK# application to easily set emblems for files and folders

About
-----

R7.Emblems is simple GTK# frontend for gvfs-info and gvfs-set-attribute utilities, 
"inspired" by lack of emblem support in lastest Nautius and it's derivatives. 
New nautilus-emblems / nemo-emblems packages are too buggy for use (at least for now), 
so I've decided to continue my work on R7.Emblems.

Shortcuts for context menus for Nautilus (r7-emblems-action.desktop) and Nemo (r7-emblems.nemo_action) are provided.
You can also try to use R7.Emblems with any gvfs-based file manager, or it also can be used as separate application.  

*Note:* To get full control on Nautilus actions, I recommend using nautilus-actions package.

Install (experimental)
----------------------

Binary package contains script to install application in /usr/local prefix, but consider it experimental - 
I planning to replace them by autotools-style makefiles in near future.

<pre>wget https://github.com/roman-yagodin/r7-emblems/releases/download/1.1-alpha/R7.Emblems-1.1-Binaries.tar.gz
tar -zxvf R7.Emblems-1.1-Binaries.tar.gz
cd R7.Emblems-1.1-Binaries
./install.sh</pre>

After this, according to which filemanager you like to install context menu action, run:

<pre>./install-action-nautilus.sh</pre>

or

<pre>./install-action-nemo.sh</pre>

Uninstall (experimental)
------------------------

Just run uninstall script from program folder, like this:

<pre>cd /usr/local/lib/r7-emblems
./uninstall.sh</pre>

Localization
------------

R7.Emblems do have english and russian translations. 
Feel free to add more - sources contain complete MonoDevelop solution, including translation project. 
