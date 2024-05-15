Write-Host 'Hello and welcome! What might be your name stranger?'

[string] $Name = Read-Host 'Enter your name here'

Write-Host "It is so nice to meet you $Name."
Write-Host ''
Write-Host 'My name is Kai and I have saved your name in a log file.'

$Name | Out-File -FilePath 'C:\Code\Name.txt' -Append