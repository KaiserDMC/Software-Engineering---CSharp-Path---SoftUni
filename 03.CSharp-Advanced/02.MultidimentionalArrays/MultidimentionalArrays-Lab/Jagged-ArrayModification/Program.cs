using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRowElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                jaggedMatrix[i] = new int[currentRowElements.Length];

                for (int j = 0; j < currentRowElements.Length; j++)
                {
                    jaggedMatrix[i][j] = currentRowElements[j];
                }
            }

            while (true)
            {
                string commandInput = Console.ReadLine();

                if (commandInput == "END")
                {
                    break;
                }

                string[] command = commandInput.Split(" ").ToArray();

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || col < 0)
                {
                    Console.WriteLine($"Invalid coordinates");
                    continue;
                }

                switch (command[0])
                {
                    case "Add":

                        if (row > rows - 1 || jaggedMatrix[row].Length - 1 < col)
                        {
                            Console.WriteLine($"Invalid coordinates");
                        }
                        else
                        {
                            jaggedMatrix[row][col] = jaggedMatrix[row][col] + value;
                        }

                        break;
                    case "Subtract":

                        if (row > rows - 1 || jaggedMatrix[row].Length - 1 < col)
                        {
                            Console.WriteLine($"Invalid coordinates");
                        }
                        else
                        {
                            jaggedMatrix[row][col] = jaggedMatrix[row][col] - value;
                        }

                        break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    Console.Write($"{jaggedMatrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
