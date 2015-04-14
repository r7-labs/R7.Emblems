
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

PROGRAMFILES =

FILES =

DATA_FILES =

RESOURCES =

REFERENCES =

DLL_REFERENCES =

EXTRA_DIST = \
	Makefile.am \
	$(STARTER_SCRIPT_SOURCE) \
	readme.txt

$(STARTER_SCRIPT): $(STARTER_SCRIPT_SOURCE)
	$(AM_V_GEN) sed -e 's|@libdir[@]|$(libdir)|g' $< > $@
	chmod +x $@

CLEANFILES = $(BUILD_DIR)/* $(STARTER_SCRIPT)

bin_SCRIPTS = $(STARTER_SCRIPT)

desktopdir = $(datarootdir)/applications
desktop_DATA = r7-emblems.desktop

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(PROJECT_FILE)
	$(ASSEMBLY_COMPILER_COMMAND) $(PROJECT_FILE) $(ASSEMBLY_COMPILER_FLAGS)
