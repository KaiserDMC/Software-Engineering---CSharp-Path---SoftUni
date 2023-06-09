using System;

namespace BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string currentPlayer = String.Empty;
            string bestPlayer = String.Empty;
            
            int highestGoals = 0;

            while (input != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                currentPlayer = input;

                if (goals > highestGoals)
                {
                    highestGoals = goals;
                    bestPlayer = currentPlayer;
                }

                if (goals >= 10)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (highestGoals >= 3)
            {
                Console.WriteLine($"He has scored {highestGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {highestGoals} goals.");
            }
        }
    }
}