﻿param(
[string]$folderPath = "C:\Temp",
[string]$teamCityTestFullPath = "C:\TeamCity\buildAgent\work\parent\Random.NET\Randomizer.OutputTests\bin\Debug\Randomizer.OutputTests.exe"
)

if(-Not(Test-Path $folderPath))
{
    New-Item $folderPath -ItemType directory
    Write-Host "New folder '$folderPath' created"
}

Write-Host "Tests starting ...."
if(-Not(Test-Path $teamCityTestFullPath))
{
    Write-Error "Team city path $teamCityTestFullPath doesnnot exists."
     [System.Environment]::Exit(-1)
}

Invoke-Expression $teamCityTestFullPath

Write-Host "Tests finished"

