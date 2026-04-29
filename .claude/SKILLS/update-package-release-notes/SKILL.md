---
name: update-package-release-notes
description: Updates the PackageReleaseNotes Xml Element in csproj files of all projects in the solution except the test projects. Use when user changes PackageReference, or when VersionPrefix Xml Element changes in a non-test-project csproj file in the solution , or when user ask for update-package-releasenotes, or update-releasenotes.  
---

# Update Package Release Notes

## Instructions

### Step 1:
Add, or replace <PackageReleaseNotes> in all non-test-project csproj files in the solution for all latest changed versions of all PackageReferences since the last commit on the development branch that has a tag that does not contain the -rc* suffix. 
Use syntax 
'''
[Update] PackageName to version PackageVersion. 
'''
Remove all existing <PackageReleaseNotes> lines in all csproj files in the solution for PackageReferences upgrades that haven't changed since the last commit on the development branch that has a tag that does not contain the -rc* suffix.

### Step 2:
Add, or replace <PackageReleaseNotes> in all non-test-project csproj files in the solution containing all latest changed versions of all referenced projects since the last commit on the development branch that has a tag that does not contain the -rc* suffix. 
Use syntax 
'''
[Update] ProjectName to version ProjectVersionPrefix. 
'''
Remove all existing <PackageReleaseNotes> lines in all csproj files in the solution for referenced project upgrades that haven't changed since the last commit on the development branch that has a tag that does not contain the -rc* suffix.
