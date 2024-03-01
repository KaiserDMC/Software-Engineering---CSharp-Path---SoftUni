Write-Host 'Hello and welcome! What might be your name stranger?'

[string] $Name = Read-Host 'Enter your name here'

Write-Host "It is so nice to meet you $Name."
Write-Host ''

[int] $Age = Read-Host "And what is your age $Name?"

Write-Host 'Oh, my... This is such a wonderful time of your life!'

Write-Host 'My name is Krisztian and I have saved your details in a log file.'

$LogOutput = "{0}, {1}" -f $Name, $Age

$LogOutput | Out-File -FilePath 'C:\Temp\InfoData.log' -Append