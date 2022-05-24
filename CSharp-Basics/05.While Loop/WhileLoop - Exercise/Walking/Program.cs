using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int steps = 0;

            while (input != "Going home")
            {

                steps += int.Parse(input);

                if (steps >= 10000)
                {
                    break;
                }

                input = Console.ReadLine();

            }

            if (input == "Going home")
            {
                input = Console.ReadLine();
                steps += int.Parse(input);
            }

            int difference = 10000 - steps;

            if (difference <= 0)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{Math.Abs(difference)} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{difference} more steps to reach goal.");
            }
        }
    }
}
