Param(
    [Parameter(Mandatory=$true)]
    [string]$nugetClientFilePath,
    [Parameter(Mandatory=$true)]
    [string]$sourceRootDirectory,
    [Parameter(Mandatory=$true)]
    [string]$resultsDirectoryPath,
    [Parameter(Mandatory=$true)]
    [string]$logsPath
)

    . "$PSScriptRoot\..\PerformanceTestUtilities.ps1"

    RunPerformanceTestsOnGitRepository $nugetClientFilePath $sourceRootDirectory "https://github.com/NuGet/NuGet.Client.git" "203c517a85791243f53ea08d404ee5b8fae36e35" $resultsDirectoryPath $logsPath