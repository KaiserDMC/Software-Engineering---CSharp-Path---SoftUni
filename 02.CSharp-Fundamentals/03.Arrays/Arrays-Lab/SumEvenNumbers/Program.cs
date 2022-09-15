using System;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] separatedNumbers = input.Split(' ');
            int sum = 0;

            for (int i = 0; i < separatedNumbers.Length; i++)
            {
                int[] numbers = new int[separatedNumbers.Length];
                numbers[i] = Convert.ToInt32(separatedNumbers[i]);

                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
