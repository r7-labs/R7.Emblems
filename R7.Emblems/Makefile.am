if ENABLE_DEBUG_X86

ASSEMBLY_COMPILER_COMMAND = xbuild
ASSEMBLY_COMPILER_FLAGS = /p:Configuration=Debug
BUILD_DIR = bin/Debug
ASSEMBLY = $(BUILD_DIR)/R7.Emblems.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 

endif

if ENABLE_RELEASE_X86

ASSEMBLY_COMPILER_COMMAND = xbuild
ASSEMBLY_COMPILER_FLAGS = /p:Configuration=Release
BUILD_DIR = bin/Release
ASSEMBLY = $(BUILD_DIR)/R7.Emblems.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

all: $(ASSEMBLY)

PROGRAMFILES =

FILES =

DATA_FILES =

RESOURCES =

EXTRAS =

REFERENCES =

DLL_REFERENCES =

EXTRA_DIST = \
    Makefile.am \
    readme.txt

CLEANFILES = $(BUILD_DIR)/*

include $(top_srcdir)/Makefile.include

$(eval $(call emit_resgen_targets))

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_satellite_assembly_list)
	$(ASSEMBLY_COMPILER_COMMAND) R7.Emblems.csproj $(ASSEMBLY_COMPILER_FLAGS)
