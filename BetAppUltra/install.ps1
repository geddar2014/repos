[cmdletbinding()]
param(
	[string]$LogFile="./log.txt",
	[string]$CmdFile="./deploy.cmd",
	[string]$InstallDir="./cli-tools",
	[string]$PackagesDir="./packages",
	[string]$TempDir = "./temp",
	[string]$DeployDir="./deploy",
	[string]$DotnetCli="",
	[string]$CliVersion = "2.0.3"
)

Set-StrictMode -Version Latest
$ErrorActionPreference="SilentlyContinue"
Stop-Transcript | out-null
$ErrorActionPreference = "Continue"

function Say($str) {
    Write-Host "fetch: $str"
}

Start-Transcript -path $LogFile | out-null

$LogFile =		Resolve-Path $LogFile
$LogFileName =  [System.IO.Path]::GetFileName($LogFile)

if (Test-Path $CmdFile)
{
	rm $CmdFile
}

if (-Not (Test-Path $InstallDir))
{
	New-Item -Type "directory" -Path $InstallDir  | out-null
	Invoke-WebRequest -Uri "https://dot.net/v1/dotnet-install.ps1" -OutFile "$InstallDir/dotnet-install.ps1"
	& $InstallDir/dotnet-install.ps1 -Version $CliVersion -InstallDir $InstallDir	
}
$InstallDir =	Resolve-Path $InstallDir
$DotnetCli =	Resolve-Path (Join-Path	$InstallDir -ChildPath "dotnet.exe")



if (-Not (Test-Path $PackagesDir))
{
	New-Item -Type "directory" -Path $PackagesDir  | out-null
}
$PackagesDir =  Resolve-Path $PackagesDir


if (Test-Path $TempDir)
{
	rm -Recurse $TempDir
}
New-Item -Type "directory" -Path $TempDir | out-null
$TempDir =	Resolve-Path $TempDir


if (Test-Path $DeployDir)
{
	rm -Recurse $DeployDir
}
New-Item -Type "directory" -Path $DeployDir | out-null
$DeployDir =	Resolve-Path $DeployDir


$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False

#$line = "`n"
#Say $line
#[IO.File]::AppendLineWriteAllLines($CmdFile,$line,$Utf8NoBomEncoding)

#$line = "`n";

$env:DOTNET_MULTILEVEL_LOOKUP = '0'
$env:DOTNET_HOST_PATH = $DotnetCli

Say $env:DOTNET_HOST_PATH
#Say $env:PATH

$line  = '"' + $DotnetCli +'" --info'
$line += "`n`n`n"
$line += 'SETX DOTNET_HOST_PATH "' + $hostPath +'" /M'
$line += "`n"
$line += "SETX DOTNET_MULTILEVEL_LOOKUP 0 /M`n`n`n"
$line += "echo %DOTNET_HOST_PATH%`n`n`n"
$line += "echo %DOTNET_MULTILEVEL_LOOKUP%`n`n`n"
$line += """$DotnetCli"" publish --framework netcoreapp2.0 --configuration Release --runtime win10-x86 --packages ""$PackagesDir"" -v n --output ""$DeployDir"" --self-contained"

[IO.File]::WriteAllLines($CmdFile,$line,$Utf8NoBomEncoding)
#& cmd /c $line

#& cmd /c $line
#Say $line

#$line = """$DotnetCli"" --info`n"

#& cmd /c $line

#$line += """$DotnetCli"" publish -c release -r win-x64 -o ""$DeployDir"""

#& cmd /c $line


	   #Say $line

	   #$line += """$DotnetCli"" build   -c release -r win-x64 -o ""$TempDir""`n"


#& cmd /c $line
#& cmd /c """$DotnetCli"" restore --packages ""$PackagesDir"" -v n"
#Say $line
#[IO.File]::WriteAllLines($CmdFile,$line,$Utf8NoBomEncoding)

#$line += """$DotnetCli"" build -r win-x64`n"
#& cmd /c """$DotnetCli"" build -r win-x64"
#Say $line
#[IO.File]::WriteAllLines($CmdFile,$line,$Utf8NoBomEncoding)

#$line += """$DotnetCli"" publish -c release -r win-x64 -o ""$DeployDir"""
#& cmd /c """$DotnetCli"" publish -c release -r win-x64 -o ""$DeployDir"""
#Say $line

#[IO.File]::WriteAllLines($CmdFile,$line,$Utf8NoBomEncoding)

#Say $line

#& cmd /c $CmdFile

#$line

Stop-Transcript  | out-null