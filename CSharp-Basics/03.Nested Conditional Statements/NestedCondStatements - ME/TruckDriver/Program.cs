using System;

namespace TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometres = double.Parse(Console.ReadLine());

            double payPerKilometre = 0;
            double payment = 0;

            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kilometres <= 5000)
                    {
                        payPerKilometre = 0.75;
                    }
                    else if (kilometres > 5000 && kilometres <= 10000)
                    {
                        payPerKilometre = 0.95;
                    }
                    else if (kilometres > 10000 && kilometres <= 20000)
                    {
                        payPerKilometre = 1.45;
                    }
                    break;
                case "Summer":
                    if (kilometres <= 5000)
                    {
                        payPerKilometre = 0.9;
                    }
                    else if (kilometres > 5000 && kilometres <= 10000)
                    {
                        payPerKilometre = 1.1;
                    }
                    else if (kilometres > 10000 && kilometres <= 20000)
                    {
                        payPerKilometre = 1.45;
                    }
                    break;
                case "Winter":
                    if (kilometres <= 5000)
                    {
                        payPerKilometre = 1.05;
                    }
                    else if (kilometres > 5000 && kilometres <= 10000)
                    {
                        payPerKilometre = 1.25;
                    }
                    else if (kilometres > 10000 && kilometres <= 20000)
                    {
                        payPerKilometre = 1.45;
                    }
                    break;
            }

            payment = payPerKilometre * kilometres * 4;
            payment -= payment * 0.1;

            Console.WriteLine($"{payment:f2}");
        }
    }
}
