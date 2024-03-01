Function Create-BatchDirectories {   

<#
.SYNOPSIS
Non-interactive PowerShell script that creates a specific Directory Structure based on line argument
inputs provided by the user

© krifod – Created as part of Windows System Administration course @ SoftUni, April-May 2023

Follow: 
https://github.com/KaiserDMC
                                                                                          
                                                                            Page 1 of 1
.DESCRIPTION
This function accepts four parameters $ProjectStart, $ProjectEnd, $PhaseStart and $PhaseEnd

.EXAMPLE
Create-BatchDirectories -projectStart 1 -projectEnd 3 -phaseStart 1 -phaseEnd 2

Using this input the created directory structure will be:

C:\Projects\Project1\Phase1
C:\Projects\Project1\Phase2 
C:\Projects\Project2\Phase1 
C:\Projects\Project2\Phase2 
C:\Projects\Project3\Phase1
C:\Projects\Project3\Phase2

.NOTES
First source the Batch-Directories.ps1 file. Keep in mind that if the function is executed without 
parameters there are certain default values (1, 1, 1, 1).
If some of the folders already exist, their creation will be skipped.

.LINK

https://github.com/KaiserDMC/Software-Engineering---CSharp-Path---SoftUni/tree/main/12.Windows-Server-Administration

#>

[cmdletbinding()]
    Param (
        [int]$ProjectStart = 1,
        [int]$ProjectEnd = 1,
        [int]$PhaseStart = 1,
        [int]$PhaseEnd = 1
    )

    # Set Main/Parent Directory
    $projectDirectory = "$env:SystemDrive\Projects"

    # If Main Directory is present skip creation, else create it
    If (Test-Path -Path $projectDirectory -PathType Container) {
        Write-Host "Parent directory already exists... Moving to subfolder creation..."
    }
    Else {
        New-Item -Path $projectDirectory -ItemType Directory
    }

    # For create sub-folder structure from ProjectStart to ProjectEnd, if any of the folders exist skip creation
    For($ProjectCounter = $ProjectStart; $ProjectCounter -LE $ProjectEnd; $ProjectCounter++) {
        # Current Project Directory
        $subProjectDir = "$projectDirectory\Project$ProjectCounter"
        
        If (Test-Path -Path $subProjectDir -PathType Container) {
            Write-Host "Parent directory already exists... Moving to subfolder creation..."
        }
        Else {
            New-Item -Path $subProjectDir -ItemType Directory
        }
            # For create sub-folder structure from PhaseStart to PhaseEnd, if any of the folders exist skip creation
            For($PhaseCounter = $PhaseStart; $PhaseCounter -LE $PhaseEnd; $PhaseCounter++) {
                # Current Phase Directory
                $subPhaseDir = "$subProjectDir\Phase$PhaseCounter"
        
                If (Test-Path -Path $subPhaseDir -PathType Container) {
                    Write-Host "Phase directory already exists... Skipping creation..."
                }
                Else {
                    New-Item -Path $subPhaseDir -ItemType Directory
                }   
            }
    }
}