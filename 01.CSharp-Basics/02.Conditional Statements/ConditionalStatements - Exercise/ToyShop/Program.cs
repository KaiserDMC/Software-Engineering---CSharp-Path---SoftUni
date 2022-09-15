using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollsCount = int.Parse(Console.ReadLine());
            int teddiesCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            int totalToysCount = puzzleCount + dollsCount + teddiesCount + minionsCount + trucksCount;

            double puzzlePrice = 2.60;
            double dollsPrice = 3;
            double teddiesPrice = 4.1;
            double minionsPrice = 8.20;
            double trucksPrice = 2;

            double totalPuzzlePrice = puzzleCount * puzzlePrice;
            double totalDollsPrice = dollsCount * dollsPrice;
            double totalTeddiesPrice = teddiesCount * teddiesPrice;
            double totalMinionsPrice = minionsCount * minionsPrice;
            double totalTrucksPrice = trucksCount * trucksPrice;

            double totalToysPrice = (totalPuzzlePrice + totalDollsPrice + totalTeddiesPrice + totalMinionsPrice + totalTrucksPrice);

            if (totalToysCount >= 50)
            {
                totalToysPrice = totalToysPrice * 0.75;
            }

            double availableMoney = totalToysPrice * 0.9;

            if (tripPrice <= availableMoney)
            {
                Console.WriteLine($"Yes! {availableMoney - tripPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice - availableMoney:f2} lv needed.");
            }
        }
    }
}
