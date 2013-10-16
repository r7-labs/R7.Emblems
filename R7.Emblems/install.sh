#!/bin/bash

# Usage:
# ./install.sh

PREFIX="/usr/local"
PROJECTNAME="r7-emblems"

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

echo "Done."
echo

# hint about installing actions
echo "If you like to install action for filemanager menu now,"
echo "please run ./install-action-nemo.sh or ./install-action-nautilus.sh
echo "according to filemanager you use."
