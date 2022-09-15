using System;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] allNumbers = new int[input];

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());

                allNumbers[i] = number;
            }

            for (int j = input - 1; j >= 0; j--)
            {
                Console.Write($"{allNumbers[j]} ");
            }
        }
    }
}
