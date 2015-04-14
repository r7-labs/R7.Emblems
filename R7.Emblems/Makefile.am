
PROJECT_FILE = R7.Emblems.csproj
ASSEMBLY_COMPILER_COMMAND = xbuild
ASSEMBLY = $(BUILD_DIR)/R7.Emblems.exe
PROJECT_REFERENCES = 

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_FLAGS = /p:Configuration=Debug
BUILD_DIR = bin/Debug
ASSEMBLY_MDB = $(ASSEMBLY).mdb
endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_FLAGS = /p:Configuration=Release
BUILD_DIR = bin/Release
ASSEMBLY_MDB = 
endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

STARTER_SCRIPT_SOURCE = r7-emblems.sh.in
STARTER_SCRIPT = r7-emblems.sh

all: $(STARTER_SCRIPT) $(ASSEMBLY) 

FILES = \
	$(PROJECT_FILE) \
	gtk-gui/generated.cs \
	gtk-gui/MainWindow.cs \
	MainWindow.cs \
	AssemblyInfo.cs \
	EmblemButton.cs \
	Gvfs.cs \
	Main.cs

EXTRA_DIST = \
	$(STARTER_SCRIPT_SOURCE) \
	Makefile.am \
	readme.txt

$(STARTER_SCRIPT): $(STARTER_SCRIPT_SOURCE)
	$(AM_V_GEN) sed -e 's|@libdir[@]|$(libdir)|g' $< > $@
	chmod +x $@

CLEANFILES = $(BUILD_DIR)/* $(STARTER_SCRIPT)

bin_SCRIPTS = $(STARTER_SCRIPT)

desktopdir = $(datarootdir)/applications
dist_desktop_DATA = r7-emblems.desktop

templatesdir = $(libdir)/$(PACKAGE)
dist_templates_DATA = \
	r7-emblems.nemo_action \
	r7-emblems-action.desktop

assemblydir = $(libdir)/$(PACKAGE)
assembly_DATA = $(ASSEMBLY)

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(PROJECT_FILE)
	$(ASSEMBLY_COMPILER_COMMAND) $(PROJECT_FILE) $(ASSEMBLY_COMPILER_FLAGS)
