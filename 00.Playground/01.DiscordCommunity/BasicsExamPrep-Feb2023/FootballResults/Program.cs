using System;

namespace FootballResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int loses = 0;
            int draws = 0;

            for (int i = 1; i <= 3; i++)
            {
                string result = Console.ReadLine();

                char scoreOne = result[0];
                char scoreTwo = result[2];

                if (scoreOne > scoreTwo)
                {
                    wins++;
                    // wins += 1 ;
                }
                else if (scoreOne < scoreTwo)
                {
                    loses++;
                }
                else
                {
                    draws++;
                }
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
