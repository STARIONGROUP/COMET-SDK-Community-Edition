@echo off

IF %1.==. GOTO KeyError
set apikey=%1

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

IF EXIST "%~dp0\ReleaseBuilds" (
    rmdir "%~dp0\ReleaseBuilds" /s /q
)

mkdir "%~dp0\ReleaseBuilds"

rem Cleaning Builds...
dotnet clean -c Release CDP4-SDK.sln

ECHO.
ECHO Packing nugets...
ECHO.

rem Packing New Versions...
dotnet pack -c Release -o ReleaseBuilds CDP4-SDK.sln

ECHO.
ECHO Pushing to nuget.org ...
ECHO.

for %%f in (%~dp0ReleaseBuilds\*.nupkg) do (
    (Echo "%%f" | FIND /I "symbols" 1>NUL) || (
        echo Pushing %%f
        dotnet nuget push "%%f" -s api.nuget.org -k %apikey%
    )
)

:End

ECHO.
ECHO Release Completed
ECHO.