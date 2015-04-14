dnl Warning: This is an automatically generated file, do not edit!
dnl Process this file with autoconf to produce a configure script.
AC_PREREQ([2.54])
AC_INIT([R7.Emblems], [0.1])
AM_INIT_AUTOMAKE([foreign])
AM_MAINTAINER_MODE

dnl pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
        AC_MSG_ERROR([You need to install pkg-config])
fi

SHAMROCK_EXPAND_LIBDIR
SHAMROCK_EXPAND_BINDIR
SHAMROCK_EXPAND_DATADIR

AC_PROG_INSTALL

AC_PATH_PROG(XBUILD, xbuild, no)
if test "x$XBUILD" = "xno"; then
        AC_MSG_ERROR([xbuild Not found])
fi

AC_PATH_PROG(MSGFMT, msgfmt, no)
if test "x$MSGFMT" = "xno"; then
        AC_MSG_ERROR([msgfmt Not found])
fi

AC_ARG_ENABLE(debug_x86,
	AC_HELP_STRING([--enable-debug_x86],
		[Use 'DEBUG_X86' Configuration [default=NO]]),
		enable_debug_x86=yes, enable_debug_x86=no)
AM_CONDITIONAL(ENABLE_DEBUG_X86, test x$enable_debug_x86 = xyes)
if test "x$enable_debug_x86" = "xyes" ; then
	CONFIG_REQUESTED="yes"
fi
AC_ARG_ENABLE(release_x86,
	AC_HELP_STRING([--enable-release_x86],
		[Use 'RELEASE_X86' Configuration [default=YES]]),
		enable_release_x86=yes, enable_release_x86=no)
AM_CONDITIONAL(ENABLE_RELEASE_X86, test x$enable_release_x86 = xyes)
if test "x$enable_release_x86" = "xyes" ; then
	CONFIG_REQUESTED="yes"
fi
AC_ARG_ENABLE(default,
	AC_HELP_STRING([--enable-default],
		[Use 'DEFAULT' Configuration [default=NO]]),
		enable_default=yes, enable_default=no)
AM_CONDITIONAL(ENABLE_DEFAULT, test x$enable_default = xyes)
if test "x$enable_default" = "xyes" ; then
	CONFIG_REQUESTED="yes"
fi
if test -z "$CONFIG_REQUESTED" ; then
	AM_CONDITIONAL(ENABLE_RELEASE_X86, true)
	enable_release_x86=yes
fi


dnl package checks, common for all configs
PKG_CHECK_MODULES([GTK_SHARP_20], [gtk-sharp-2.0])

dnl package checks, per config


AC_CONFIG_FILES([
R7.Emblems/Makefile
Makefile

])

AC_OUTPUT
