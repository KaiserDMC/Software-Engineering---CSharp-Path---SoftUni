using System;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            if (n == 1)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());

                if (number1 == number2)
                {
                    sum1 = number1 + number2;
                    sum2 = sum1;
                }
                else
                {
                    sum1 = number1;
                    sum2 = number2;
                }
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());

                    if (i % 2 == 0)
                    {
                        sum2 = number1 + number2;
                    }
                    else
                    {
                        sum1 = number1 + number2;
                    }
                }
            }

            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, value={sum1}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={ Math.Abs(sum1 - sum2)}");
            }
        }
    }
}
