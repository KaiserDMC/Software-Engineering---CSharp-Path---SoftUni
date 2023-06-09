using System;

namespace TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            double totalAmount = 0;
            int winsTotal = 0;
            int lossesTotal = 0;

            for (int i = 1; i <= days; i++)
            {
                string input = Console.ReadLine();

                double amountWonPerDay = 0;
                int winsDaily = 0;
                int lossesDaily = 0;

                while (input != "Finish")
                {
                    string sport = input;
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        amountWonPerDay += 20;
                        winsDaily++;
                    }
                    else
                    {
                        lossesDaily++;
                    }

                    input = Console.ReadLine();
                }

                if (winsDaily > lossesDaily)
                {
                    amountWonPerDay *= 1.1;
                }

                totalAmount += amountWonPerDay;
                winsTotal += winsDaily;
                lossesTotal += lossesDaily;
            }

            if (winsTotal > lossesTotal)
            {
                totalAmount *= 1.20;
                Console.WriteLine($"You won the tournament! Total raised money: {totalAmount:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalAmount:f2}");
            }
        }
    }
}