using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorBikers = int.Parse(Console.ReadLine());
            int seniorBikers = int.Parse(Console.ReadLine());
            string raceType = Console.ReadLine();

            double taxJunior = 0;
            double taxSenior = 0;
            int totalBikers = juniorBikers + seniorBikers;

            switch (raceType)
            {
                case "trail":
                    taxJunior = 5.50;
                    taxSenior = 7;
                    break;
                case "cross-country":
                    if (totalBikers >= 1 && totalBikers < 50)
                    {
                        taxJunior = 8;
                        taxSenior = 9.5;
                    }
                    else if (totalBikers >= 50)
                    {
                        taxJunior = 8 * 0.75;
                        taxSenior = 9.5 * 0.75;
                    }
                    break;
                case "downhill":
                    taxJunior = 12.25;
                    taxSenior = 13.75;
                    break;
                case "road":
                    taxJunior = 20;
                    taxSenior = 21.5;
                    break;
            }

            double totalIncomeJunior = taxJunior * juniorBikers;
            double totalIncomeSenior = taxSenior * seniorBikers;
            double totalIncome = (totalIncomeJunior + totalIncomeSenior) * 0.95;

            Console.WriteLine($"{totalIncome:f2}");

        }
    }
}
