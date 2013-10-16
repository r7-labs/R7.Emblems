#!/bin/bash

# Usage:
# ./install-action-nautilus.sh

PROJECTNAME="r7-emblems"
FILEMANAGER="file-manager" 

echo "Installing Nautilus action file for $USER..."

cp -r -f "${PROJECTNAME}-action.desktop" "${HOME}/.local/share/$FILEMANAGER/actions"

echo "Done."
