using System;

namespace PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCouple = int.Parse(Console.ReadLine());
            int secondCouple = int.Parse(Console.ReadLine());
            int firstDifference = int.Parse(Console.ReadLine());
            int secondDifference = int.Parse(Console.ReadLine());

            int firstMaxValue = firstCouple + firstDifference;
            int secondMaxValue = secondCouple + secondDifference;

            int firstPrimeCounter = 0;
            int secondPrimeCounter = 0;

            for (int i = firstCouple; i <= firstMaxValue; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    if (i % k == 0)
                    {
                        firstPrimeCounter++;
                    }
                }

                if (firstPrimeCounter == 2)
                {
                    for (int j = secondCouple; j <= secondMaxValue; j++)
                    {
                        for (int m = 1; m <= j; m++)
                        {
                            if (j % m == 0)
                            {
                                secondPrimeCounter++;
                            }
                        }

                        if (secondPrimeCounter == 2)
                        {
                            Console.WriteLine($"{i}{j}");
                        }

                        secondPrimeCounter = 0;
                    }
                }
                firstPrimeCounter = 0;
            }
        }
    }
}
