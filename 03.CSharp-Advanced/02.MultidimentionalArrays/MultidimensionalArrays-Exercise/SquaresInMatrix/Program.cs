using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            char[,] theMatrix = new char[rows, cols];

            int square = 2;

            for (int i = 0; i < rows; i++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    theMatrix[i, j] = currentRow[j];
                }
            }

            int counterEqual = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + square - 1 < rows && col + square - 1 < cols)
                    {
                        bool isEqual = false;

                        for (int currRow = row; currRow < row + square - 1; currRow++)
                        {
                            for (int currCol = col; currCol < col + square - 1; currCol++)
                            {
                                if ((theMatrix[currRow, currCol] == theMatrix[currRow, currCol + 1]) && (theMatrix[currRow, currCol] == theMatrix[currRow + 1, currCol]) && (theMatrix[currRow, currCol] == theMatrix[currRow + 1, currCol + 1]))
                                {
                                    isEqual = true;
                                }
                                else
                                {
                                    isEqual = false;
                                    break;
                                }
                            }

                            if (!isEqual)
                            {
                                break;
                            }
                        }

                        if (isEqual)
                        {
                            counterEqual++;
                        }
                    }
                }
            }

            Console.WriteLine(counterEqual);
        }
    }
}
