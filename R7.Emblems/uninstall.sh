#!/bin/bash

# Usage:
# ./uninstall.sh

PREFIX="/usr/local"
PROJECTNAME="r7-emblems"

echo "About to uninstall ${PROJECTNAME}..."

# remove desktop file
sudo rm -f "${PREFIX}/share/applications/${PROJECTNAME}.desktop" 

# remove simlink to start script
# sudo rm -f "${PREFIX}/bin/${PROJECTNAME}"

# remove application directory and all files
sudo rm -f -r "${PREFIX}/lib/${PROJECTNAME}"

echo "Uninstall complete."
