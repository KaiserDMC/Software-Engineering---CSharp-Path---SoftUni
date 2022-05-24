using System;

namespace ExcursionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int numberOfPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            //Calculations
            double costPerNight = 0;

            switch (season)
            {
                case "spring":
                    if (numberOfPeople <= 5)
                    {
                        costPerNight = 50;
                    }
                    else
                    {
                        costPerNight = 48;
                    }
                    break;
                case "summer":
                    if (numberOfPeople <= 5)
                    {
                        costPerNight = 48.50;
                    }
                    else
                    {
                        costPerNight = 45;
                    }
                    break;
                case "autumn":
                    if (numberOfPeople <= 5)
                    {
                        costPerNight = 60;
                    }
                    else
                    {
                        costPerNight = 49.50;
                    }
                    break;
                case "winter":
                    if (numberOfPeople <= 5)
                    {
                        costPerNight = 86;
                    }
                    else
                    {
                        costPerNight = 85;
                    }
                    break;
            }

            double totalCost = numberOfPeople * costPerNight;

            if (season == "summer")
            {
                totalCost -= totalCost * 0.15;
            }

            if (season == "winter")
            {
                totalCost += totalCost * 0.08;
            }

            //Output
            Console.WriteLine($"{totalCost:F2} leva.");
        }
    }
}
