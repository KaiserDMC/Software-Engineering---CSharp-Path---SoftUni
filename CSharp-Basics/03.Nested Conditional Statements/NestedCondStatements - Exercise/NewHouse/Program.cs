using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = 0;

            switch (flowerType)
            {
                case "Roses":
                    flowerPrice = 5;
                    if (numberFlowers > 80)
                    {
                        flowerPrice = flowerPrice - (flowerPrice * 0.1);
                    }
                    break;
                case "Dahlias":
                    flowerPrice = 3.8;
                    if (numberFlowers > 90)
                    {
                        flowerPrice = flowerPrice - (flowerPrice * 0.15);
                    }
                    break;
                case "Tulips":
                    flowerPrice = 2.8;
                    if (numberFlowers > 80)
                    {
                        flowerPrice = flowerPrice - (flowerPrice * 0.15);
                    }
                    break;
                case "Narcissus":
                    flowerPrice = 3;
                    if (numberFlowers < 120)
                    {
                        flowerPrice = flowerPrice * 1.15;
                    }
                    break;
                case "Gladiolus":
                    flowerPrice = 2.5;
                    if (numberFlowers < 80)
                    {
                        flowerPrice = flowerPrice * 1.2;
                    }
                    break;
            }

            double totalCost = flowerPrice * numberFlowers;
            double difference = totalCost - budget;

            if (difference <= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {flowerType} and {Math.Abs(difference):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {difference:f2} leva more.");
            }

        }
    }
}
