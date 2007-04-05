SUBDIRS = src
bin_SCRIPTS = monobenchmark
EXTRA_DIST = monobenchmark.in

$(bin_SCRIPTS): $(srcdir)/monobenchmark.in Makefile
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

