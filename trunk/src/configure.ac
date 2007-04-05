AC_INIT([monobenchmark],[0.1])
AC_CANONICAL_SYSTEM
AM_INIT_AUTOMAKE([1.9 tar-ustar])
AM_MAINTAINER_MODE

AC_PROG_INSTALL

dnl pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
	AC_MSG_ERROR([You need to install pkg-config])
fi

dnl C# compiler
AC_PATH_PROG(GMCS,gmcs,no)
AC_PATH_PROG(MONO, mono, no)

CS="C#"
if test "x$GMCS" = "xno" ; then
	AC_MSG_ERROR([You need to install a $CS compiler with 2.0(Generics,Partial Classes, Anonynous Methods) Support. Try install GMCS])
fi

MCS=$GMCS

if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([No mono runtime found])
fi

dnl gtk-sharp
dnl GTKSHARP_REQUIRED_VERSION=1.0
dnl PKG_CHECK_MODULES(GTKSHARP, gtk-sharp >= $GTKSHARP_REQUIRED_VERSION)

AC_SUBST(MCS)
AC_SUBST(VERSION)

dnl find assembly paths for unstable installed assemblies that will be
dnl copied into monoskel installation directory for local usage with the app
dnl UNSTABLE_INSTALL_ASSEMBLIES="superstring-sharp"
INSTALLED_ASSEMBLIES="`$PKG_CONFIG --variable=Libraries $UNSTABLE_INSTALL_ASSEMBLIES`"
AC_SUBST(INSTALLED_ASSEMBLIES)

AC_CONFIG_FILES([
Makefile
src/Makefile
src/Framework/Makefile
src/Framework/AssemblyInfo.cs
src/Core/Makefile
src/Core/AssemblyInfo.cs
src/Console/Makefile
src/Console/AssemblyInfo.cs
])

AC_OUTPUT

dnl Configuration summary
echo ""
echo "Configuration summary"
echo ""
echo "   * Installation prefix = $prefix"
echo "   * $CS compiler: $MCS"
echo "   * if you want to install monobenchmark, use $make && make install"
echo "   * if you have any issue compiling, please contact me a thepumpkin1979@gmail.com"
echo ""
