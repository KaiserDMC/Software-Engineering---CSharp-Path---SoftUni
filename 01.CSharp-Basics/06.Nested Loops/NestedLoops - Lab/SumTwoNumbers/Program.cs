using System;

namespace SumTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int positionCounter = 0;
            int sum = 0;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    sum = i + j;
                    positionCounter++;

                    if (sum == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{positionCounter} ({i} + {j} = {sum})");
                        return;
                    }
                }

            }

            if (sum != magicNumber)
            {
                Console.WriteLine($"{positionCounter} combinations - neither equals {magicNumber}");
            }

        }
    }
}
