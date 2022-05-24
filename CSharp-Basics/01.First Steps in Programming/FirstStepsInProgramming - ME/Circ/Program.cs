using System;

namespace Circ
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double calculatedArea = 2* Math.PI * r;
            double calculatedParameter = Math.PI * Math.Pow(r, 2);

            Console.WriteLine($"{calculatedParameter:f2}");
            Console.WriteLine($"{calculatedArea:f2}");
        }
    }
}
