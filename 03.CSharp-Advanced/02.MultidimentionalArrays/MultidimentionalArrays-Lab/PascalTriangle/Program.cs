using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());

            long[][] pascalMatrix = new long[rowCount][];

            pascalMatrix[0] = new long[] { 1 };

            for (int i = 1; i < rowCount; i++)
            {
                pascalMatrix[i] = new long[i + 1];

                for (int j = 0; j < i + 1; j++)
                {
                    long previous = 0;

                    if (j - 1 < 0)
                    {
                        previous = 0;
                    }
                    else
                    {
                        previous = pascalMatrix[i - 1][j - 1];
                    }

                    long next = 0;

                    if (j > pascalMatrix[i - 1].Length - 1)
                    {
                        next = 0;
                    }
                    else
                    {
                        next = pascalMatrix[i - 1][j];
                    }

                    pascalMatrix[i][j] = previous + next;

                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < pascalMatrix[i].Length; j++)
                {
                    Console.Write($"{pascalMatrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
