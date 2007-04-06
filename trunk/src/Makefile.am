SUBDIRS = src
bin_SCRIPTS = monobenchmark
EXTRA_DIST = monobenchmark.in

pkgconfigdir = $(prefix)/lib/pkgconfig
pkgconfig_DATA = monobenchmark-framework.pc

REWRITE = \
	sed -e "s|\@prefix\@|$(prefix)|g"       \
	    -e "s|\@pkglibdir\@|$(pkglibdir)|g" \
	    -e "s|\@bindir\@|$(bindir)|g"		\
	    -e "s|\@MONO\@|$(MONO)|g" 

$(bin_SCRIPTS): $(srcdir)/monobenchmark.in Makefile
	$(REWRITE) $(srcdir)/monobenchmark.in > $@.tmp
	mv $@.tmp $@

run-console: all
	$(mono) src/Console/MonoBenchmark-Console.exe

CLEANFILES = monobenchmark monobenchmark-framework.pc

DISTCLEANFILES = \
	configure \
	config.guess \
	config.sub \
	Makefile.in \
	install-sh \
	aclocal.m4 \
	INSTALL \
	COPYING \
	missing

