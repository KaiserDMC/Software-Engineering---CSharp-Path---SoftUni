using System;

namespace MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double costPerDay = 0;
            double totalCostMovie = 0;

            switch (destination)
            {
                case "Dubai":
                    if (season == "Winter")
                    {
                        costPerDay = 45000;
                    }
                    else if (season == "Summer")
                    {
                        costPerDay = 40000;
                    }
                    break;
                case "Sofia":
                    if (season == "Winter")
                    {
                        costPerDay = 17000;
                    }
                    else if (season == "Summer")
                    {
                        costPerDay = 12500;
                    }
                    break;
                case "London":
                    if (season == "Winter")
                    {
                        costPerDay = 24000;
                    }
                    else if (season == "Summer")
                    {
                        costPerDay = 20250;
                    }
                    break;
            }

            totalCostMovie = days * costPerDay;

            if (destination == "Dubai")
            {
                totalCostMovie -= totalCostMovie * 0.3;
            }

            if (destination == "Sofia")
            {
                totalCostMovie += totalCostMovie * 0.25;
            }

            double difference = movieBudget - totalCostMovie;

            if (difference >= 0)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {difference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {Math.Abs(difference):f2} leva more!");
            }
        }
    }
}
