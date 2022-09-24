using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixInput[0];
            int cols = matrixInput[1];

            int[,] theMatrica = new int[rows, cols];

            int squareDimensions = 3;

            for (int row = 0; row < rows; row++)
            {
                int[] currentRowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    theMatrica[row, col] = currentRowElements[col];
                }
            }

            int biggestDimension = Math.Max(rows, cols);
            int maxSum = Int32.MinValue;
            int maxRow = Int32.MinValue;
            int maxCol = Int32.MinValue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + squareDimensions - 1 < rows && col + squareDimensions - 1 < cols)
                    {
                        int sum = 0;

                        for (int currentRow = row; currentRow < row + squareDimensions; currentRow++)
                        {
                            for (int currentCol = col; currentCol < col + squareDimensions; currentCol++)
                            {
                                sum += theMatrica[currentRow, currentCol];
                            }
                        }

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < squareDimensions; i++)
            {
                for (int j = 0; j < squareDimensions; j++)
                {
                    Console.Write($"{theMatrica[maxRow + i, maxCol + j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}

