using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournamets = int.Parse(Console.ReadLine());
            int initialRankingPoints = int.Parse(Console.ReadLine());

            int totalPoints = 0;
            int counterWins = 0;

            for (int i = 0; i < numberOfTournamets; i++)
            {
                string tournamentStage = Console.ReadLine();

                switch (tournamentStage)
                {
                    case "W":
                        totalPoints += 2000;
                        counterWins++;
                        break;
                    case "F":
                        totalPoints += 1200;
                        break;
                    case "SF":
                        totalPoints += 720;
                        break;
                }
            }

            double averagePoints = (totalPoints * 1.0) / numberOfTournamets;
            double percentageWon = (double)counterWins/ numberOfTournamets * 100;
            
            totalPoints += initialRankingPoints;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentageWon:f2}%");
        }
    }
}
