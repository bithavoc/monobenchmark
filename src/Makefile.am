SUBDIRS = src
bin_SCRIPTS = monobenchmark monobenchmark-framework.pc
EXTRA_DIST = monobenchmark.in monobenchmark-framework.pc.in

REWRITE = \
	sed -e "s|\@prefix\@|$(prefix)|g"       \
	    -e "s|\@pkglibdir\@|$(pkglibdir)|g" \
	    -e "s|\@bindir\@|$(bindir)|g"		\
	    -e "s|\@MONO\@|$(MONO)|g" 

$(bin_SCRIPTS): $(srcdir)/monobenchmark.in Makefile
	$(REWRITE) $(srcdir)/monobenchmark.in > $@.tmp
	mv $@.tmp $@

monobenchmark-framework.pc: $(srcdir)/monobenchmark-framework.pc.in Makefile
	$(REWRITE) $(srcdir)/monobenchmark-framework.pc.in > $@.tmp
	mv $@.tmp $@

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

