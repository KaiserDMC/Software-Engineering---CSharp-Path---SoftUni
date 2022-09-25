using System;
using System.Collections.Generic;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] commandStrings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            char[,] theField = new char[fieldSize, fieldSize];

            int initialCoalCount = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] currentFieldRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    theField[row, col] = currentFieldRow[col];

                    if (currentFieldRow[col] == 'c')
                    {
                        initialCoalCount++;
                    }
                    else if (currentFieldRow[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Queue<string> commandQueue = new Queue<string>(commandStrings);

            int[] currentPosition = new int[] { startRow, startCol };
            int gatheredCoal = 0;

            for (int command = 0; command < commandStrings.Length; command++)
            {
                string currentCommand = commandQueue.Dequeue();

                switch (currentCommand)
                {
                    case "left":
                        currentPosition[0] = currentPosition[0];
                        currentPosition[1] -= 1;

                        if (ValidFieldIndex(fieldSize, currentPosition[0], currentPosition[1]))
                        {
                            string moved = ValidMove(theField, currentPosition[0], currentPosition[1]);

                            if (moved == "e")
                            {
                                Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");

                                return;
                            }
                            else if (moved == "c")
                            {
                                gatheredCoal++;
                            }
                        }
                        else
                        {
                            currentPosition[1] += 1;
                        }

                        break;
                    case "right":
                        currentPosition[0] = currentPosition[0];
                        currentPosition[1] += 1;

                        if (ValidFieldIndex(fieldSize, currentPosition[0], currentPosition[1]))
                        {
                            string moved = ValidMove(theField, currentPosition[0], currentPosition[1]);

                            if (moved == "e")
                            {
                                Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");

                                return;
                            }
                            else if (moved == "c")
                            {
                                gatheredCoal++;
                            }
                        }
                        else
                        {
                            currentPosition[1] -= 1;
                        }

                        break;
                    case "up":
                        currentPosition[0] -= 1;
                        currentPosition[1] = currentPosition[1];

                        if (ValidFieldIndex(fieldSize, currentPosition[0], currentPosition[1]))
                        {
                            string moved = ValidMove(theField, currentPosition[0], currentPosition[1]);

                            if (moved == "e")
                            {
                                Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");

                                return;
                            }
                            else if (moved == "c")
                            {
                                gatheredCoal++;
                            }
                        }
                        else
                        {
                            currentPosition[0] += 1;
                        }

                        break;
                    case "down":
                        currentPosition[0] += 1;
                        currentPosition[1] = currentPosition[1];

                        if (ValidFieldIndex(fieldSize, currentPosition[0], currentPosition[1]))
                        {
                            string moved = ValidMove(theField, currentPosition[0], currentPosition[1]);

                            if (moved == "e")
                            {
                                Console.WriteLine($"Game over! ({currentPosition[0]}, {currentPosition[1]})");

                                return;
                            }
                            else if (moved == "c")
                            {
                                gatheredCoal++;
                            }
                        }
                        else
                        {
                            currentPosition[0] -= 1;
                        }

                        break;
                }

                if (gatheredCoal == initialCoalCount)
                {
                    Console.WriteLine($"You collected all coals! ({currentPosition[0]}, {currentPosition[1]})");
                    break;
                }
            }

            if (initialCoalCount - gatheredCoal > 0)
            {
                Console.WriteLine($"{initialCoalCount - gatheredCoal} coals left. ({currentPosition[0]}, {currentPosition[1]})");
            }

        }

        private static bool ValidFieldIndex(int fieldSize, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < fieldSize)
            {
                if (col >= 0 && col < fieldSize)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private static string ValidMove(char[,] theField, int row, int col)
        {
            string resultString = String.Empty;

            if (theField[row, col] == '*')
            {
                resultString = "*";
            }
            else if (theField[row, col] == 'c')
            {
                resultString = "c";
                theField[row, col] = '*';
            }
            else if (theField[row, col] == 'e')
            {
                resultString = "e";
            }

            return resultString;
        }
    }
}
