using System;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinsOneLev = int.Parse(Console.ReadLine());
            int coinsTwoLev = int.Parse(Console.ReadLine());
            int notesFiveLev = int.Parse(Console.ReadLine());
            int profit = int.Parse(Console.ReadLine());

            int counterOneLev = 0;
            int counterTwoLev = 0;
            int counterFiveLev = 0;
            int sum = 0;

            for (int i = 0; i <= coinsOneLev; i++)
            {
                for (int j = 0; j <= coinsTwoLev; j++)
                {
                    for (int k = 0; k <= notesFiveLev; k++)
                    {
                        sum = i * 1 + j * 2 + k * 5;

                        if (sum == profit)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }

                        counterFiveLev++;
                    }
                    counterTwoLev++;
                }

                counterOneLev++;
            }
        }
    }
}
