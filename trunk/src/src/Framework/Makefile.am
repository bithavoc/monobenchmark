mbframeworkdir=$(pkglibdir)
mbframework_SCRIPTS = MonoBenchmark.Framework.dll
EXTRA_DIST = $(mbframework_sources) $(mbframework_sources_in)
CLEANFILES = MonoBenchmark.Framework.dll
DISTCLEANFILES = AssemblyInfo.cs Makefile.in

mbframework_sources_in = AssemblyInfo.cs.in
mbframework_generated_sources = $(mbframework_sources_in:.in=)
mbframework_sources = Attributes.cs

mbframework_build_sources = $(addprefix $(srcdir)/, $(mbframework_sources))
mbframework_build_sources += $(mbframework_generated_sources)

MonoBenchmark.Framework.dll: $(mbframework_build_sources)
	$(MCS) /target:library -out:$@ $(mbframework_build_sources)

# Install Unstable Mono Libraries (see configure.ac)

install-data-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		$(INSTALL) -c -m 0755 $$ASM $(DESTDIR)$(pkglibdir); \
	done;

uninstall-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		rm -f $(DESTDIR)$(pkglibdir)/`basename $$ASM`; \
	done;

