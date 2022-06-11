using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string endRange = Console.ReadLine();

            TopNumber(endRange);
        }

        static void TopNumber(string endRange)
        {
            int number = int.Parse(endRange);

            for (int i = 0; i < number; i++)
            {
                bool OddDigit = false;
                int currentNumber = i;
                int sum = 0;

                while (currentNumber != 0)
                {
                    int digit = currentNumber % 10;
                    sum += digit;

                    if (digit % 2 != 0)
                    {
                        OddDigit = true;
                    }

                    currentNumber /= 10;
                }

                if (OddDigit && (sum % 8 == 0))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}