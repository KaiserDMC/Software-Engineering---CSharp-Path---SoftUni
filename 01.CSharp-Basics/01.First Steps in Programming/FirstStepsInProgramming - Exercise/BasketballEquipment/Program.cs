using System;

namespace BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double basketballRate = double.Parse(Console.ReadLine());

            double basketballShoes = basketballRate - (basketballRate * 40 / 100);
            double basketballOutfit = basketballShoes - (basketballShoes * 20 / 100);
            double basketballBall = basketballOutfit * 0.25;
            double basketballAccessories = basketballBall * 0.2;

            double totalBasketballCost = basketballRate + basketballShoes + basketballOutfit + basketballBall + basketballAccessories;
            Console.WriteLine(totalBasketballCost);
        }
    }
}
