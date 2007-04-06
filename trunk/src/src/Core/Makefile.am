mbcore=MonoBenchmark.Core
mbcoredir=$(pkglibdir)
mbcore_SCRIPTS = MonoBenchmark.Core.dll
EXTRA_DIST = $(mbcore_sources) $(mbcore_sources_in)
CLEANFILES = MonoBenchmark.Core.dll
DISTCLEANFILES = Makefile.in

mbcore_sources_in = AssemblyInfo.cs.in
mbcore_generated_sources = $(mbcore_sources_in:.in=)
mbcore_sources = TestSession.cs TestSessionResult.cs TestMethodInfo.cs TestingWorker.cs TimeFixtureInfo.cs \
		 TimeFixtureResult.cs MethodTimeResult.cs TestTimeResult.cs TestSessionState.cs \
		 mbdebug.cs

mbcore_build_sources = $(addprefix $(srcdir)/, $(mbcore_sources))
mbcore_build_sources += $(mbcore_generated_sources)

MonoBenchmark.Core.dll: $(mbcore_build_sources)
	$(MCS) /target:library -keyfile:$(top_builddir)/src/key.snk /r:$(top_builddir)/src/Framework/MonoBenchmark.Framework.dll -out:$@ $(mbcore_build_sources)

# Install Unstable Mono Libraries (see configure.ac)

install-data-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		$(INSTALL) -c -m 0755 $$ASM $(DESTDIR)$(pkglibdir); \
	done;
	cd $(pkglibdir)
	-gacutil -i $(mbcore_SCRIPTS)

uninstall-hook:
	for ASM in $(INSTALLED_ASSEMBLIES); do \
		rm -f $(DESTDIR)$(pkglibdir)/`basename $$ASM`; \
	done;
	-gacutil -u $(mbcore)
