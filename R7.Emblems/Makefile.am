
EXTRA_DIST = \
    Makefile.am \
    readme.txt

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86

ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/R7.Emblems.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

R7_EMBLEMS_EXE_MDB_SOURCE=bin/Debug/R7.Emblems.exe.mdb
R7_EMBLEMS_EXE_MDB=$(BUILD_DIR)/R7.Emblems.exe.mdb
#README_TXT_SOURCE=readme.txt
#R7_EMBLEMS_NEMO_ACTION_SOURCE=r7-emblems.nemo_action
#INSTALL_ACTION_NEMO_SH_SOURCE=install-action-nemo.sh
#INSTALL_ACTION_NAUTILUS_SH_SOURCE=install-action-nautilus.sh
#R7_EMBLEMS_DESKTOP_SOURCE=r7-emblems.desktop
#R7_EMBLEMS_ACTION_DESKTOP_SOURCE=r7-emblems-action.desktop

endif

if ENABLE_RELEASE_X86

ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/R7.Emblems.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

R7_EMBLEMS_EXE_MDB=
#README_TXT_SOURCE=readme.txt
#R7_EMBLEMS_NEMO_ACTION_SOURCE=r7-emblems.nemo_action
#INSTALL_ACTION_NEMO_SH_SOURCE=install-action-nemo.sh
#INSTALL_ACTION_NAUTILUS_SH_SOURCE=install-action-nautilus.sh
#R7_EMBLEMS_DESKTOP_SOURCE=r7-emblems.desktop
#R7_EMBLEMS_ACTION_DESKTOP_SOURCE=r7-emblems-action.desktop

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES =  \
	r7-emblems-action.desktop \
    r7-emblems.nemo_action

RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) 

FILES =  \
	AssemblyInfo.cs \
	EmblemButton.cs \
	gtk-gui/generated.cs \
	gtk-gui/R7.Emblems.MainWindow.cs \
	Gvfs.cs \
	Main.cs \
	MainWindow.cs 

DATA_FILES = r7-emblems.desktop

RESOURCES = gtk-gui/gui.stetic 

EXTRAS =

REFERENCES =  \
	Mono.Posix \
	-pkg:gtk-sharp-2.0 \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) 

include $(top_srcdir)/Makefile.include
    
R7_EMBLEMS_NEMO_ACTION = r7-emblems.nemo_action
#R7_EMBLEMS_DESKTOP = r7-emblems.desktop
R7_EMBLEMS_ACTION_DESKTOP = r7-emblems-action.desktop

$(eval $(call emit-deploy-target,ASSEMBLY))
$(eval $(call emit-deploy-target,R7_EMBLEMS_NEMO_ACTION))
#$(eval $(call emit-deploy-target,R7_EMBLEMS_DESKTOP))
$(eval $(call emit-deploy-target,R7_EMBLEMS_ACTION_DESKTOP))

$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
