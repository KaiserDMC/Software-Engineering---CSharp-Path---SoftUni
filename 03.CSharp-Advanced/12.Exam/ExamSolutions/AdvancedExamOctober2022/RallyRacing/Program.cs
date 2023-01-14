using System;
using System.Collections.Generic;
using System.Linq;

namespace RallyRacing
{
    class Program
    {
        public static int currentCarRow = -1;
        public static int currentCarCol = -1;
        public static string[,] rallyField;
        public static int travelledDistance = 0;
        public static int firstTunnelRow = -1;
        public static int firstTunnelCol = -1;
        public static int secondTunnelRow = -1;
        public static int secondTunnelCol = -1;
        public static bool reachedEnd = false;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string trackedCar = Console.ReadLine();

            rallyField = new string[matrixSize, matrixSize];
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string[] currRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    rallyField[row, col] = currRow[col];

                    if (currRow[col] == "T")
                    {
                        if (firstTunnelRow < 0 && firstTunnelCol < 0)
                        {
                            firstTunnelRow = row;
                            firstTunnelCol = col;
                        }
                        else if (secondTunnelRow < 0 && secondTunnelCol < 0)
                        {
                            secondTunnelRow = row;
                            secondTunnelCol = col;
                        }
                    }
                }
            }

            currentCarRow = startRow;
            currentCarCol = startCol;

            while (true)
            {
                if (reachedEnd)
                {
                    break;
                }

                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "left":
                        CarMove(matrixSize, 0, -1);

                        break;

                    case "right":
                        CarMove(matrixSize, 0, +1);

                        break;

                    case "up":
                        CarMove(matrixSize, -1, 0);

                        break;

                    case "down":
                        CarMove(matrixSize, +1, 0);

                        break;
                }
            }

            if (!reachedEnd)
            {
                Console.WriteLine($"Racing car {trackedCar} DNF.");
            }
            else
            {
                Console.WriteLine($"Racing car {trackedCar} finished the stage!");
            }

            Console.WriteLine($"Distance covered {travelledDistance} km.");

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (i == currentCarRow && j == currentCarCol)
                    {
                        rallyField[i, j] = "C";
                    }

                    Console.Write($"{rallyField[i, j]}");
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

        private static void CarMove(int matrixSize, int row, int col)
        {
            if (ValidIndex(matrixSize, currentCarRow + row, currentCarCol + col))
            {
                if (rallyField[currentCarRow + row, currentCarCol + col] == ".")
                {
                    rallyField[currentCarRow, currentCarCol] = ".";
                    travelledDistance += 10;
                    currentCarRow += row;
                    currentCarCol += col;
                }
                else if (rallyField[currentCarRow + row, currentCarCol + col] == "T")
                {
                    rallyField[currentCarRow, currentCarCol] = ".";
                    currentCarRow += row;
                    currentCarCol += col;
                    travelledDistance += 30;

                    if (currentCarRow == firstTunnelRow && currentCarCol == firstTunnelCol)
                    {
                        currentCarRow = secondTunnelRow;
                        currentCarCol = secondTunnelCol;
                        rallyField[firstTunnelRow, firstTunnelCol] = ".";
                    }
                    else if (currentCarRow == secondTunnelRow && currentCarCol == secondTunnelCol)
                    {
                        currentCarRow = firstTunnelRow;
                        currentCarCol = firstTunnelCol;
                        rallyField[secondTunnelRow, secondTunnelCol] = ".";
                    }
                }
                else if (rallyField[currentCarRow + row, currentCarCol + col] == "F")
                {
                    rallyField[currentCarRow, currentCarCol] = ".";
                    travelledDistance += 10;
                    currentCarRow += row;
                    currentCarCol += col;
                    reachedEnd = true;
                }

                //rallyField[currentCarRow, currentCarCol] = "C";
            }
        }
    }
}
