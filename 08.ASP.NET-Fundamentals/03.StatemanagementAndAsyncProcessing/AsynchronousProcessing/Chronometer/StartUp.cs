namespace Chronometer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            string command = Console.ReadLine();

            while (command != "exit")
            {
                switch (command)
                {
                    case "start":
                        Task.Run(() =>
                        {
                            chronometer.Start();
                        });
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps" when chronometer.Laps.Count > 0:
                    {
                        Console.WriteLine($"Laps: ");
                        for (int i = 0; i < chronometer.Laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                        }

                        break;
                    }
                    case "laps":
                        Console.WriteLine($"Laps: no laps");
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                }

                command = Console.ReadLine();
            }

            chronometer.Stop();
        }
    }
}