using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] topIntegers = new int[inputArray.Length];
            int currentMax = int.MinValue;
            int max = 0;

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                if (inputArray[i] > currentMax)
                {
                    currentMax = inputArray[i];
                    max = currentMax;

                }

                topIntegers[i] = max;
            }

            int[] topIntegersUnique = topIntegers.Distinct().ToArray();

            foreach (int element in topIntegersUnique)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
