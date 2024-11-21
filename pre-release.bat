@echo off

IF %1.==. GOTO KeyError
set versionSuffix=%1

IF %2.==. GOTO KeyError
set apikey=%2

GOTO Begin

:KeyError
ECHO.
ECHO ERROR: No apikey was specified
ECHO.

GOTO End

:Begin

ECHO.
ECHO Cleaning up...
ECHO.

IF EXIST "%~dp0\PreReleaseBuilds" (
    rmdir "%~dp0\PreReleaseBuilds" /s /q
)

mkdir "%~dp0\PreReleaseBuilds"

rem Cleaning Builds...
dotnet clean -c Debug CDP4-SDK.sln /p:Platform="Any CPU" 

ECHO.
ECHO Packing nugets...
ECHO.

rem Packing New Versions...
dotnet pack -c Debug --version-suffix "%versionSuffix%" -o PreReleaseBuilds CDP4-SDK.sln /p:Platform="Any CPU"

ECHO.
ECHO Pushing to github ...
ECHO.

for %%f in (%~dp0PreReleaseBuilds\*.nupkg) do (
    (Echo "%%f" | FIND /I "symbols" 1>NUL) || (
        echo Pushing %%f
        dotnet nuget push "%%f" --source https://nuget.pkg.github.com/STARIONGROUP/index.json -k %apikey%
    )
)

:End

ECHO.
ECHO Release Completed
ECHO.