#!/bin/bash

# Usage:
# ./install-action-nemo.sh

PREFIX="/usr/local"
PROJECTNAME="r7-emblems"
FILEMANAGER="nemo" 

echo "Installing Nemo action file for $USER..."

cp -r -f "${PROJECTNAME}-nemo_action" "${HOME}/.local/share/$FILEMANAGER/actions"

echo "Done."
