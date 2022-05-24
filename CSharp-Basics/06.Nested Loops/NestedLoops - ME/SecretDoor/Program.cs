using System;

namespace SecretDoor
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimitHundreds = int.Parse(Console.ReadLine());
            int upperLimitTens = int.Parse(Console.ReadLine());
            int upperLimitOnes = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= upperLimitHundreds; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j <= upperLimitTens; j++)
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
                                for (int k = 1; k <= upperLimitOnes; k++)
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
