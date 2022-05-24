using System;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnolia = 3.25;
            double zyumbyul = 4;
            double rose = 3.50;
            double cactus = 8;

            int numberMangnolia = int.Parse(Console.ReadLine());
            int numberZyumbyul = int.Parse(Console.ReadLine());
            int numberRose = int.Parse(Console.ReadLine());
            int numberCactus = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double orderCost = magnolia * numberMangnolia + zyumbyul * numberZyumbyul + rose * numberRose + cactus * numberCactus;
            double afterTax = orderCost - (orderCost * 0.05);

            double difference = giftPrice - afterTax;

            if (difference > 0)
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(difference)} leva.");
            }
            else
            {
                Console.WriteLine($"She is left with {Math.Floor(Math.Abs(difference))} leva.");
            }
        }
    }
}
