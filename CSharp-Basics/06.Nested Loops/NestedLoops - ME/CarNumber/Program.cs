using System;

namespace CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());

            for (int i = firstNumber; i <= lastNumber; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = firstNumber; j <= lastNumber; j++)
                    {
                        for (int k = firstNumber; k <= lastNumber; k++)
                        {
                            int sum = j + k;

                            if (sum % 2 == 0)
                            {
                                for (int m = firstNumber; m <= lastNumber; m++)
                                {
                                    if ((i > m) && (m % 2 != 0))
                                    {
                                        Console.Write($"{i}{j}{k}{m} ");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = firstNumber; j <= lastNumber; j++)
                    {
                        for (int k = firstNumber; k <= lastNumber; k++)
                        {
                            int sum = j + k;

                            if (sum % 2 == 0)
                            {
                                for (int m = firstNumber; m <= lastNumber; m++)
                                {
                                    if ((i > m) && (m % 2 == 0))
                                    {
                                        Console.Write($"{i}{j}{k}{m} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
