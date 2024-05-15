using System;
using System.ComponentModel.Design;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[][] jaggMatrix = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                int[] rowSequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                jaggMatrix[i] = new int[rowSequence.Length];

                for (int j = 0; j < rowSequence.Length; j++)
                {
                    jaggMatrix[i][j] = rowSequence[j];
                }
            }

            for (int row = 0; row < numberOfRows - 1; row++)
            {
                if (jaggMatrix[row].Length == jaggMatrix[row + 1].Length)
                {
                    for (int j = 0; j <= jaggMatrix[row].Length - 1; j++)
                    {
                        jaggMatrix[row][j] *= 2;
                        jaggMatrix[row + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j <= jaggMatrix[row].Length - 1; j++)
                    {
                        jaggMatrix[row][j] /= 2;
                    }

                    for (int k = 0; k < jaggMatrix[row + 1].Length; k++)
                    {
                        jaggMatrix[row + 1][k] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] commandInput = Console.ReadLine().Split(" ").ToArray();

                if (commandInput[0] == "End")
                {
                    break;
                }

                string command = commandInput[0];
                int row = int.Parse(commandInput[1]);
                int col = int.Parse(commandInput[2]);
                int value = int.Parse(commandInput[3]);

                if (row >= 0 && col >= 0 && row < numberOfRows && col < jaggMatrix[row].Length)
                {
                    switch (command)
                    {
                        case "Add":

                            jaggMatrix[row][col] += value;

                            break;
                        case "Subtract":

                            jaggMatrix[row][col] -= value;

                            break;
                    }
                }
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < jaggMatrix[row].Length; col++)
                {
                    Console.Write($"{jaggMatrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
