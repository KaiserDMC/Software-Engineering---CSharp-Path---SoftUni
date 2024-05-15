using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            string[,] theMatrica = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    theMatrica[i, j] = currentRow[j];
                }
            }

            while (true)
            {
                string[] commandInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                bool changeDone = false;

                if (commandInput[0] == "END")
                {
                    break;
                }

                if (commandInput[0] != "swap" || commandInput.Length != 5)
                {
                    Console.WriteLine($"Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(commandInput[1]);
                    int col1 = int.Parse(commandInput[2]);
                    int row2 = int.Parse(commandInput[3]);
                    int col2 = int.Parse(commandInput[4]);

                    if (row1 < rows && row2 < rows && col1 < cols && col2 < cols)
                    {
                        if (row1 >= 0 && row2 >= 0 && col1 >= 0 && col2 >= 0)
                        {
                            (theMatrica[row1, col1], theMatrica[row2, col2]) = (theMatrica[row2, col2], theMatrica[row1, col1]);

                            changeDone = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }

                    if (changeDone)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                Console.Write($"{theMatrica[i, j]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
