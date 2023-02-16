using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double shoes = tax - tax * 0.4; // 1 * tax - 0.4 * tax => tax * ( 1- 0.4)= > 0.6*tax
            // double shoes = tax * 0.6;

            double clothes = shoes - shoes * 0.2;

            double ball = clothes - clothes * 0.75;

            double accessories = ball - ball * 0.8;

            double total = tax + shoes + clothes + ball + accessories;

            Console.WriteLine($"{total:f2}");

           // Console.WriteLine("{0:0.00}", total);
        }
    }
}
