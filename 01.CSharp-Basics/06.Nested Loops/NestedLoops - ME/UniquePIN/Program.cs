using System;

namespace UniquePIN
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= firstNumber; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j <= secondNumber; j++)
                    {
                        if (j >= 2 && j <= 7)
                        {
                            for (int m = 1; m <= j; m++)
                            {
                                if (j % m == 0)
                                {
                                    counter++;
                                }
                            }

                            if (counter == 2)
                            {
                                for (int k = 1; k <= thirdNumber; k++)
                                {
                                    if (k % 2 == 0)
                                    {
                                        Console.WriteLine($"{i} {j} {k}");
                                    }
                                }
                            }
                        }

                        counter = 0;
                    }
                }
            }
        }
    }
}
