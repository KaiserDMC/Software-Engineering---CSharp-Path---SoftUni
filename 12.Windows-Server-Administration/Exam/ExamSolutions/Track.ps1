$cpuCounter = Get-Counter '\Processor(_Total)\% Processor Time' -ErrorAction SilentlyContinue
    if ($cpuCounter) {
        $cpuUsage = $cpuCounter.CounterSamples.CookedValue
        $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
        $row = "{0} => {1} %" -f $timestamp, $cpuUsage

        $row | Out-File -FilePath "C:\Temp\TrackData.log" -Append
    }