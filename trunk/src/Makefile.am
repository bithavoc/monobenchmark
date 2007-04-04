SUBDIRS = src/Framework src/Core src/Console
bin_SCRIPTS = monobenchmark
EXTRA_DIST = monobenchmark.in

REWRITE = \
	sed -e "s|\@prefix\@|$(prefix)|g"       \
	    -e "s|\@pkglibdir\@|$(pkglibdir)|g" \
	    -e "s|\@bindir\@|$(bindir)|g"		\
	    -e "s|\@MONO\@|$(MONO)|g" 

$(bin_SCRIPTS): $(srcdir)/monobenchmark.in Makefile
	$(REWRITE) $(srcdir)/monobenchmark.in > $@.tmp
	mv $@.tmp $@

CLEANFILES = \
	monobenchmark

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

