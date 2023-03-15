$count = [Enum]::GetValues([System.ConsoleColor]).Count
$WShell = New-Object -Com "Wscript.Shell"
$idx = 1
while (1)
{
    $WShell.SendKeys("a")
    Write-Host ([string]::Format(“No sleeping! {0}”,$idx)) -f ([System.ConsoleColor](Get-Random -Minimum 1 -Maximum $count)).value__
    $idx++
    sleep 60
}