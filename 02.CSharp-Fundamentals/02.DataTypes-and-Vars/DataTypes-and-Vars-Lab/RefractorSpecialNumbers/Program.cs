using System;

namespace RefractorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int number = 1; number <= counter; number++)
            {
                int sum = 0;
                int currentNumber = number;

                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }

                bool isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine($"{number} -> {isSpecialNumber}");
            }
        }
    }
}
