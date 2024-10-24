#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <NewVersionPrefix>"
    exit 1
fi

rootFolder=$(pwd)

newVersionPrefix=$1

# Get all .csproj files recursively within the root folder and discard tests project
projectFiles=$(find "$rootFolder" -type f -name '*.csproj' | grep -v 'Tests.csproj')

for file in $projectFiles; do
    sed "s|\(<VersionPrefix>\)[^<]*\(<\/VersionPrefix>\)|\1$newVersionPrefix\2|g" "$file" > "$file.tmp"
    mv "$file.tmp" "$file"
done

echo "VersionPrefix updated to $newVersionPrefix in all .csproj files."
