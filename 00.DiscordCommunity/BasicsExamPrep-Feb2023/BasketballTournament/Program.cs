using System;

namespace BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            int wins = 0;
            int losses = 0;
            int totalGames = 0;

            while (inputLine != "End of tournaments")
            {
                string nameOfTournament = inputLine;

                int numberOfGamesPerTournament = int.Parse(Console.ReadLine());
                totalGames += numberOfGamesPerTournament;

                for (int i = 1; i <= numberOfGamesPerTournament; i++)
                {
                    int pointsTeamDesi = int.Parse(Console.ReadLine());
                    int pointsOpponents = int.Parse(Console.ReadLine());

                    if (pointsTeamDesi > pointsOpponents)
                    {
                        Console.WriteLine($"Game {i} of tournament {nameOfTournament}: win with {pointsTeamDesi - pointsOpponents} points.");
                        wins++;
                    }
                    else
                    {
                        Console.WriteLine($"Game {i} of tournament {nameOfTournament}: lost with {Math.Abs(pointsTeamDesi - pointsOpponents)} points.");
                        losses++;
                    }
                }

                inputLine = Console.ReadLine();
            }

            double percentageWins = (double)wins / totalGames * 100;
            double percentageLosses = (losses * 1.0) / totalGames * 100;

            Console.WriteLine($"{percentageWins:f2}% matches win");
            Console.WriteLine($"{percentageLosses:f2}% matches lost");
        }
    }
}
