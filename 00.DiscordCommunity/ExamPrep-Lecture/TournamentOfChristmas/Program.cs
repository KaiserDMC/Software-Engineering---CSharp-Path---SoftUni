using System;
using System.Linq.Expressions;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTournament = int.Parse(Console.ReadLine());

            double awardMoneyPerDay = 0;
            double totalWonAwardMoney = 0;
            int winCounter = 0;
            int loseCounter = 0;
            int totalWins = 0;
            int totalLoses = 0;

            for (int i = 0; i < daysOfTournament; i++)
            {
                string inputString = Console.ReadLine();

                while (inputString != "Finish")
                {
                    string sport = inputString;
                    string sportResult = Console.ReadLine();

                    if (sportResult == "win")
                    {
                        awardMoneyPerDay += 20;
                        winCounter++;
                    }
                    else
                    {
                        loseCounter++;
                    }

                    inputString = Console.ReadLine();
                }

                if (winCounter > loseCounter)
                {
                    awardMoneyPerDay *= 1.1;
                }

                totalWonAwardMoney += awardMoneyPerDay;
                totalWins += winCounter;
                totalLoses += loseCounter;

                awardMoneyPerDay = 0;
                winCounter = 0;
                loseCounter = 0;
            }

            if (totalWins > totalLoses)
            {
                totalWonAwardMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalWonAwardMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalWonAwardMoney:f2}");
            }
        }
    }
}
