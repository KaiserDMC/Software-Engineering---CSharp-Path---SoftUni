using System.Diagnostics;

namespace Chronometer;

public class Chronometer : IChronometer
{
    private Stopwatch _stopwatch;
    private List<string> _laps;

    public Chronometer()
    {
        _stopwatch = new Stopwatch();
        _laps = new List<string>();
    }

    public string GetTime => _stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

    public List<string> Laps => _laps;

    public void Start()
    {
        _stopwatch.Start();
    }

    public void Stop()
    {
        _stopwatch.Stop();
    }

    public string Lap()
    {
        string result = GetTime;
        _laps.Add(result);
        return result;
    }

    public void Reset()
    {
        _stopwatch.Reset();
        _laps.Clear();
    }
}