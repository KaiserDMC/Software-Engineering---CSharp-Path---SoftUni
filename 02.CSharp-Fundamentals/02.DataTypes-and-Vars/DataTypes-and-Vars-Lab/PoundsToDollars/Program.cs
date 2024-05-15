using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pound = double.Parse(Console.ReadLine());
            double rate = 1.31;

            double dollar = pound * rate;
            Console.WriteLine($"{dollar:f3}");
        }
    }
}
