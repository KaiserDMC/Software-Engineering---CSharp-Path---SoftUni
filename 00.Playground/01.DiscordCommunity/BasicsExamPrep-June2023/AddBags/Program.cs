using System;

namespace AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceAbove20 = double.Parse(Console.ReadLine());
            double kilogramsLuggage = double.Parse(Console.ReadLine());
            int daysToTrip = int.Parse(Console.ReadLine());
            int countLuggage = int.Parse(Console.ReadLine());

            double priceBelow10 = 0.2 * priceAbove20;
            double priceBetween = 0.5 * priceAbove20;

            double totalPrice = 0;

            if (kilogramsLuggage < 10)
            {
                totalPrice = priceBelow10 * countLuggage;
            }
            else if (kilogramsLuggage >= 10 && kilogramsLuggage <= 20)
            {
                totalPrice = priceBetween * countLuggage;
            }
            else
            {
                totalPrice = priceAbove20 * countLuggage;
            }

            if (daysToTrip > 30)
            {
                totalPrice *= 1.1;
            }
            else if (daysToTrip < 7)
            {
                totalPrice *= 1.4;
                //totalPrice = totalPrice * 0.4 + totalPrice
            }
            else
            {
                totalPrice *= 1.15;
            }

            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv.");
        }
    }
}