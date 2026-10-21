#!/bin/bash

set -euo pipefail

if [[ "$#" -ne 1 ]]; then
    echo "Usage: $0 <NewVersionPrefix>"
    exit 1
fi

newVersionPrefix=$1

# The version of all library projects is set in Directory.Build.props, next to this script
propsFile="$(dirname "$0")/Directory.Build.props"

if [[ ! -f "$propsFile" ]]; then
    echo "Directory.Build.props not found next to $0"
    exit 1
fi

sed "s|\(<VersionPrefix>\)[^<]*\(<\/VersionPrefix>\)|\1$newVersionPrefix\2|g" "$propsFile" > "$propsFile.tmp"
mv "$propsFile.tmp" "$propsFile"

echo "VersionPrefix updated to $newVersionPrefix in Directory.Build.props."
