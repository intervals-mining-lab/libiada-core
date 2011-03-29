
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/MDA.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

LIBIADA_0_8_DLL_SOURCE=../../0.8/dll/libiada_0.8.dll
MDA_EXE_MDB_SOURCE=bin/Debug/MDA.exe.mdb
MDA_EXE_MDB=$(BUILD_DIR)/MDA.exe.mdb

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/MDA.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

LIBIADA_0_8_DLL_SOURCE=../../0.8/dll/libiada_0.8.dll
MDA_EXE_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(LIBIADA_0_8_DLL) \
	$(MDA_EXE_MDB)  

BINARIES = \
	$(MDA)  


RESGEN=resgen2

LIBIADA_0_8_DLL = $(BUILD_DIR)/libiada_0.8.dll
MDA = $(BUILD_DIR)/mda

FILES = \
	Main.cs \
	MyProgram.cs \
	AssemblyInfo.cs \
	Reader.cs \
	Composition.cs \
	DisplayData.cs \
	Difference.cs \
	FMotiv.cs \
	Lexicon.cs \
	FMName.cs \
	FMArray.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Drawer.cs \
	mda.in 

REFERENCES =  \
	System \
	-pkg:gtk-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:glade-sharp-2.0 \
	-pkg:gnome-sharp-2.24 \
	System.Xml

DLL_REFERENCES =  \
	../../0.8/dll/libiada_0.8.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,LIBIADA_0_8_DLL))
$(eval $(call emit-deploy-wrapper,MDA,mda,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY) $(ASSEMBLY_MDB): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(LIBIADA_0_8_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(MDA_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(MDA),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(LIBIADA_0_8_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MDA_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(MDA),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
