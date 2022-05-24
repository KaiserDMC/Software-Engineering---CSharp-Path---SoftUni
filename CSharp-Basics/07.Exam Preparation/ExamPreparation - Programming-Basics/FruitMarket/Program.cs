using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine()); // lv./kg
            double bananasAmount = double.Parse(Console.ReadLine()); // kg
            double orangesAmount = double.Parse(Console.ReadLine()); // kg
            double raspberriesAmount = double.Parse(Console.ReadLine()); // kg
            double strawberriesAmount = double.Parse(Console.ReadLine()); // kg

            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrice = raspberriesPrice - (raspberriesPrice * 0.4);
            double bananasPrice = raspberriesPrice - (raspberriesPrice * 0.8);

            double totalPrice = strawberriesPrice * strawberriesAmount + raspberriesPrice * raspberriesAmount + orangesPrice * orangesAmount + bananasPrice * bananasAmount;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
