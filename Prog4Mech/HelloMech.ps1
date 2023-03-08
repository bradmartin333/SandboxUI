# Functions are at the top as they need to be instatiated before calling
function ArrayToCSV {

    param (
        $Array
    )

    $outputStr = "x,y,z`n"
    for ($i = 0; $i -lt $Array.Length; $i++)
    {
        $outputStr += ("{0:n3},{1:n3},{2:n3}`n" -f $Array[$i].X,$Array[$i].Y,$Array[$i].Z)
    }

    $currentDT = Get-Date -Format "MM-dd-yyyy_HH-mm-ss"
    [IO.File]::WriteAllLines("$currentDT.csv", $outputStr) # Special way for excel that Ensures UTF-8 encoding
}

Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser # Now you are in control!

# Write-Host is a Cmdlet - A lightweight command used in the PowerShell environment
Write-Host 'Welcome to PowerShell for Mechanical Engineers!' -ForegroundColor Cyan # Formatted verbatim string
Write-Host "If you use computers at work and are not comfortable writing code, you have come to the right place.`n" # Expandable string

$likeSW = (Read-Host 'First things first - do you like SolidWorks? (y/N)').ToLower()
if ($likeSW -eq 'y') {
    Write-Host "Great! Lets start out by making a point cloud!`n"
} else {
    Write-Host 'Sorry to hear that... I like OnShape myself. Anyway, have a good day!'
    Start-Sleep 3
    exit
}

while ($true) { # A forever loop
    $numPoints = (Read-Host 'How many 3D points would you like to generate?') -as [int] # Casting
    if ($numPoints -is [int]) {
        Write-Host ($numPoints.toString() + ', great!')

        $points = @() # Initialize array for the data

        # Loop and add random points to the array
        for ($i = 0; $i -lt $numPoints; $i++)
        {
            $points += [PSCustomObject]@{
                X = Get-Random -Maximum 100.0 -Minimum -100.0
                Y = Get-Random -Maximum 100.0 -Minimum -100.0
                Z = Get-Random -Maximum 100.0 -Minimum -100.0
            }
        }

        ArrayToCSV -Array $points # Create .csv

        break # Exit forever loop
    } else {
        Write-Host 'That is not a number... try again.'
    }
}
