using System;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool special = false;

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    int sum1 = i + j;

                    for (int k = 1; k <= 9; k++)
                    {
                        for (int m = 1; m <= 9; m++)
                        {
                            int sum2 = k + m;

                            if (sum1 == sum2)
                            {
                                special = true;
                            }
                            else
                            {
                                special = false;
                            }

                            if (special && (number % sum1 == 0))
                            {
                                special = true;
                            }
                            else
                            {
                                special = false;
                            }

                            if (special)
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
