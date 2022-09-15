using System;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int awardedPoints = 0;
            int totalPoints = 0;
            int winCounter = 0;

            for (int i = 1; i <= numberOfTournaments; i++)
            {
                string position = Console.ReadLine();

                switch (position)
                {
                    case "W":
                        awardedPoints = 2000;
                        winCounter++;
                        break;
                    case "F":
                        awardedPoints = 1200;
                        break;
                    case "SF":
                        awardedPoints = 720;
                        break;
                }

                totalPoints += awardedPoints;
            }

            totalPoints = startingPoints + totalPoints;
            double avgPoints = ((double)totalPoints - startingPoints) / numberOfTournaments;
            double percentageWins = (double)winCounter / numberOfTournaments * 100.0;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(avgPoints)}");
            Console.WriteLine($"{percentageWins:f2}%");
        }
    }
}
