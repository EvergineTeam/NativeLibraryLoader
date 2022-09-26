<#
.SYNOPSIS
	Evergine Library Loader NuGet Packages generator script, (c) 2022 Evergine Team
.DESCRIPTION
	This script generates NuGet packages for the Library Loader used in Evergine
	It's meant to have the same behavior when executed locally as when it's executed in a CI/CD pipeline.
.EXAMPLE
	<script> -version 0.0.1-local
.LINK
	https://evergine.com/
#>

param (
    [Parameter(Mandatory = $true)][string]$version = "",
    [string]$outputfolder = "nupkgs",
    [string]$buildVerbosity = "normal",
    [string]$buildConfiguration = "Release"
)

$ErrorActionPreference = "Stop"
. "$PSScriptRoot\ps_support.ps1"

# Set working directory
Push-Location (Get-Location).Path
Set-Location $PSScriptRoot\..

$csprojPath = "Evergine.LibraryLoader\Evergine.LibraryLoader.csproj"

# Utility functions
function LogDebug($line) {
    Write-Host "##[debug] $line" -Foreground Blue -Background Black
}

# calculate version
# #$version = "$(Get-Date -Format "yyyy.M.d").$([string]([int]$(Get-Date -Format "HH")*60+[int]$(Get-Date -Format "mm")))"

# # if ($versionSuffix -ne "") {
# #     $version = "$version-$versionSuffix"
# # }

# Show variables
LogDebug "############## VARIABLES ##############"
LogDebug "Version.............: $version"
LogDebug "Build configuration.: $buildConfiguration"
LogDebug "Build verbosity.....: $buildVerbosity"
LogDebug "Output folder.......: $outputfolder"
LogDebug "#######################################"

# Create output folder
$outputFolder = Join-Path $outputfolder $version
New-Item -ItemType Directory -Force -Path $outputFolder
$absoluteOutputFolder = Resolve-Path $outputFolder

$symbols = "false"
if ($buildConfiguration -eq "Debug") {
    $symbols = "true"
}

Set-Location .\Evergine.LibraryLoader

# Generate packages
LogDebug "START packaging process"
dotnet build "$csprojPath" -v:$buildVerbosity -p:Configuration=$buildConfiguration -p:PackageOutputPath="$absoluteOutputFolder" -p:IncludeSymbols=$symbols -p:Version=$version
dotnet pack "$csprojPath" -v:$buildVerbosity -p:Configuration=$buildConfiguration -p:PackageOutputPath="$absoluteOutputFolder" -p:IncludeSymbols=$symbols -p:Version=$version
if ($?) {
    LogDebug "END packaging process"
}
else {
    LogDebug "ERROR; packaging failed"
    exit -1
}

Pop-Location
