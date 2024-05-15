using System;

namespace InchToCm
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            double resultInInches = number * 2.54;

            Console.WriteLine(resultInInches);
        }
    }
}