mbconsoledir=$(pkglibdir)
mbconsole_SCRIPTS = MonoBenchmark-Console.exe
EXTRA_DIST = $(mbconsole_sources) $(mbconsole_sources_in)
CLEANFILES = MonoBenchmark-Console.exe
DISTCLEANFILES = Makefile.in

mbconsole_sources_in = AssemblyInfo.cs.in
mbconsole_generated_sources = $(mbconsole_sources_in:.in=)
mbconsole_sources = Main.cs

mbconsole_build_sources = $(addprefix $(srcdir)/, $(mbconsole_sources))
mbconsole_build_sources += $(mbconsole_generated_sources)

MonoBenchmark-Console.exe: $(mbconsole_build_sources)
	echo DATAROOTDIR
	echo $(datarootdir)
	$(MCS) /target:exe /r:$(top_builddir)/src/Framework/MonoBenchmark.Framework.dll /r:$(top_builddir)/src/Core/MonoBenchmark.Core.dll -out:$@ $(mbconsole_build_sources)

# Install Unstable Mono Libraries (see configure.ac)

install-data-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		$(INSTALL) -c -m 0755 $$ASM $(DESTDIR)$(pkglibdir); \
	done;

uninstall-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		rm -f $(DESTDIR)$(pkglibdir)/`basename $$ASM`; \
	done;
