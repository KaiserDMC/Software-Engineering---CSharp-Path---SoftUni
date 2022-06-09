using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Power(double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }

        static double Power(double baseNumber, int power)
        {
            return Math.Pow(baseNumber, power);
        }
    }
}
