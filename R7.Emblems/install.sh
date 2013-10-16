#!/bin/bash

# Usage:
# ./install.sh

PREFIX="/usr/local"
PROJECTNAME="r7-emblems"
# FILEMANAGER="file-manager" # Nautilus 3.6
FILEMANAGER="nemo" # Nemo

echo "About to install ${PROJECTNAME}..."

# cd to current dir
cd $(dirname ${0})

# make some dirs
sudo mkdir -p "${PREFIX}/lib/${PROJECTNAME}"
sudo mkdir -p "${PREFIX}/share/applications"

# install project to application directory
sudo cp -r -f "." "${PREFIX}/lib/${PROJECTNAME}"

# make symlink to start script in prefix/bin
# sudo ln -s "${PREFIX}/lib/${PROJECTNAME}/run.sh" "${PREFIX}/bin/${PROJECTNAME}"

# install desktop file
sudo cp -r -f "${PROJECTNAME}.desktop" "${PREFIX}/share/applications"

# install nautilus-actions desktop file for current user

# TODO: actions not depends to nautilus-actions! 
# TODO: Namo uses it's own action format.

if dpkg-query -W nautilus-actions; 
then
   cp -r -f "${PROJECTNAME}-action.desktop" "${HOME}/.local/share/$FILEMANAGER/actions"
fi

echo "Install complete."
