using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] theMatrica = new int[sizeMatrix, sizeMatrix];

            for (int row = 0; row < sizeMatrix; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < sizeMatrix; col++)
                {
                    theMatrica[row, col] = currentRow[col];
                }
            }

            string coordinates = Console.ReadLine();

            Queue<int> coordQueue = new Queue<int>(coordinates.Split(new char[] { ',', ' ' }).Select(int.Parse).ToArray());

            int bombLoop = coordQueue.Count / 2;

            for (int bombIndex = 0; bombIndex < bombLoop; bombIndex++)
            {
                int rowBomb = coordQueue.Dequeue();
                int colBomb = coordQueue.Dequeue();

                int bombValue = theMatrica[rowBomb, colBomb];

                for (int rowMatrix = 0; rowMatrix < sizeMatrix; rowMatrix++)
                {
                    for (int colMatrix = 0; colMatrix < sizeMatrix; colMatrix++)
                    {
                        if (rowMatrix == rowBomb && colMatrix == colBomb)
                        {
                            if (bombValue > 0)
                            {
                                theMatrica[rowMatrix, colMatrix] = 0;

                                if (ValidIndex(sizeMatrix, rowMatrix - 1, colMatrix - 1))
                                {
                                    int currentValue = theMatrica[rowMatrix - 1, colMatrix - 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix - 1, colMatrix - 1] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix - 1, colMatrix))
                                {
                                    int currentValue = theMatrica[rowMatrix - 1, colMatrix];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix - 1, colMatrix] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix - 1, colMatrix + 1))
                                {
                                    int currentValue = theMatrica[rowMatrix - 1, colMatrix + 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix - 1, colMatrix + 1] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix, colMatrix - 1))
                                {
                                    int currentValue = theMatrica[rowMatrix, colMatrix - 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix, colMatrix - 1] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix, colMatrix + 1))
                                {
                                    int currentValue = theMatrica[rowMatrix, colMatrix + 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix, colMatrix + 1] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix + 1, colMatrix - 1))
                                {
                                    int currentValue = theMatrica[rowMatrix + 1, colMatrix - 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix + 1, colMatrix - 1] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix + 1, colMatrix))
                                {
                                    int currentValue = theMatrica[rowMatrix + 1, colMatrix];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix + 1, colMatrix] -= bombValue;
                                    }
                                }

                                if (ValidIndex(sizeMatrix, rowMatrix + 1, colMatrix + 1))
                                {
                                    int currentValue = theMatrica[rowMatrix + 1, colMatrix + 1];

                                    if (currentValue > 0)
                                    {
                                        theMatrica[rowMatrix + 1, colMatrix + 1] -= bombValue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            int sum = 0;
            int counterAlive = 0;

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    if (theMatrica[row, col] > 0)
                    {
                        sum += theMatrica[row, col];
                        counterAlive++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counterAlive}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < sizeMatrix; row++)
            {
                for (int col = 0; col < sizeMatrix; col++)
                {
                    Console.Write($"{theMatrica[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool ValidIndex(int matrixSize, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < matrixSize)
            {
                if (col >= 0 && col < matrixSize)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
