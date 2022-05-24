using System;

namespace SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            string output = string.Empty;

            if (speed <= 10)
            {
                output = "slow";
            }
            else if (speed > 10 && speed <= 50)
            {
                output = "average";
            }
            else if (speed > 50 && speed <= 150)
            {
                output = "fast";
            }
            else if (speed > 150 && speed <= 1000)
            {
                output = "ultra fast";
            }
            else
            {
                output = "extremely fast";
            }

            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine(output);
            }
        }
    }
}
