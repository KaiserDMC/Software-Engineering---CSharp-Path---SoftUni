using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int[] rounded = new int[numbers.Length];
                rounded[i] = (int)Math.Round(numbers[i], 0, MidpointRounding.AwayFromZero);

                Console.WriteLine($"{numbers[i]} => {rounded[i]}");
            }
        }
    }
}
