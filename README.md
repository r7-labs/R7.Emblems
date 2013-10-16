r7-emblems
==========

Easy set emblems for files and folders


About
-----

R7.Emblems is simple GTK# frontend for gvfs-info and gvfs-set-attribute utilities, 
"inspired" by lack of emblem support in lastest Nautius and it's derivatives. 
New nautilus-emblems / nemo-emblems packages are too buggy for use (at least for now), 
so I've decided to continue my work on R7.Emblems.

To integrate with Nautilus, I recommend using nautilus-actions package. 
Shortcuts for context menus for Nautilus (r7-emblems-action.desktop) and Nemo (r7-emblems.nemo_action) are provided.
You can also try to use R7.Emblems with any gvfs-based file manager, or it also can use it as separate application.  

Install
-------

Binary package contains script to install application in /usr/local prefix, but consider it experimental - 
it will be replaced by autotools-style makefiles in near future.

Translations
------------

R7.Emblems do have english and russian translations. 
Feel free to add more - sources contain complete MonoDevelop solution, including translation project. 
