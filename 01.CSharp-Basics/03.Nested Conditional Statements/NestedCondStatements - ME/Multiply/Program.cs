using System;

namespace Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = 0;

            while (true)
            {
                input = double.Parse(Console.ReadLine());

                if (input >= 0)
                {
                    double result = input * 2;
                    Console.WriteLine($"Result: {result:f2}");
                }
                else
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
            }
        }
    }
}
