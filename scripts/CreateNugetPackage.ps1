$ErrorActionPreference = "Stop"

$nugetPath = "..\src\.nuget\NuGet.exe"
$projectPath = "..\src\Roccat-Talk\Roccat-Talk.csproj"

Write-Host "Creating nuget packages..." -ForegroundColor Yellow

. $nugetPath pack $projectPath -IncludeReferencedProjects -Build -Properties Configuration=Release
. $nugetPath pack $projectPath -Symbols

$packagesToPublish = Get-ChildItem -Filter *.nupkg | Select -ExpandProperty Name

Write-Host "Publishing the following packages to nuget.org" -ForegroundColor Yellow

$packagesToPublish | Write-Host
Write-Host "Continue? (y/n)" -ForegroundColor Yellow
$shouldPublish = (Read-Host) -ieq "y"

if ($shouldPublish -eq $true)
{
    $packagesToPublish |% { . $nugetPath push $_ -Verbosity detailed } 

    Write-Host "Finished publishing packages, will proceed to remove them"

    $packagesToPublish | Remove-Item
}