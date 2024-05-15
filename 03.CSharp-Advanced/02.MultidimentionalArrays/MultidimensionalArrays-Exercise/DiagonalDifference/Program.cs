using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] theMatrix = new int[matrixSize, matrixSize];

            int sumPrimary = 0;
            int sumSecondary = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    theMatrix[i, j] = currentRow[j];

                    if (i == j)
                    {
                        sumPrimary += currentRow[j];
                    }

                    if (j == matrixSize - 1 - i)
                    {
                        sumSecondary += currentRow[j];
                    }
                }
            }

            int diff = Math.Abs(sumPrimary - sumSecondary);

            Console.WriteLine(diff);
        }
    }
}
