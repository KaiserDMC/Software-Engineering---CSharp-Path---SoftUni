using System;

namespace TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTournament = int.Parse(Console.ReadLine());

            double awardMoneyDay = 0;
            double totalAwardMoney = 0;
            int winCounter = 0;
            int loseCounter = 0;
            int dailyWins = 0;
            int dailyLoses = 0;

            for (int i = 0; i < daysOfTournament; i++)
            {
                string inputString = Console.ReadLine();

                while (inputString != "Finish")
                {
                    string sport = inputString;
                    string resultText = Console.ReadLine();

                    if (resultText == "win")
                    {
                        awardMoneyDay += 20;
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
                    awardMoneyDay *= 1.1;
                }

                totalAwardMoney += awardMoneyDay;
                dailyWins += winCounter;
                dailyLoses += loseCounter;

                winCounter = 0;
                loseCounter = 0;
                awardMoneyDay = 0;
            }

            if (dailyWins > dailyLoses)
            {
                totalAwardMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalAwardMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalAwardMoney:f2}");
            }
        }
    }
}
