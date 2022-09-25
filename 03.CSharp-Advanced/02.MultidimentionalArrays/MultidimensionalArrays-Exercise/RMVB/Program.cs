using System;
using System.Collections.Generic;
using System.Linq;

namespace RMVB
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] lairMatrix = new char[rows, cols];

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currentLairRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    lairMatrix[row, col] = currentLairRow[col];

                    if (currentLairRow[col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            char[] commandChars = Console.ReadLine().ToCharArray();

            Queue<char> movesQueue = new Queue<char>(commandChars);

            int[] currentPosition = new int[] { startRow, startCol };

            bool playerIsAlive = true;
            bool playerEscaped = false;

            for (int moveIndex = 0; moveIndex < commandChars.Length; moveIndex++)
            {
                char move = movesQueue.Dequeue();

                switch (move)
                {
                    case 'L':
                        lairMatrix[currentPosition[0], currentPosition[1]] = '.';

                        currentPosition[0] = currentPosition[0];
                        currentPosition[1] -= 1;

                        if (PlayerMove(rows, cols, currentPosition[0], currentPosition[1]))
                        {
                            if (lairMatrix[currentPosition[0], currentPosition[1]] != 'B')
                            {
                                lairMatrix[currentPosition[0], currentPosition[1]] = 'P';
                            }
                            else
                            {
                                playerIsAlive = false;
                                break;
                            }
                        }
                        else
                        {
                            playerEscaped = true;
                            currentPosition[1] += 1;
                        }

                        break;
                    case 'R':
                        lairMatrix[currentPosition[0], currentPosition[1]] = '.';

                        currentPosition[0] = currentPosition[0];
                        currentPosition[1] += 1;

                        if (PlayerMove(rows, cols, currentPosition[0], currentPosition[1]))
                        {
                            if (lairMatrix[currentPosition[0], currentPosition[1]] != 'B')
                            {
                                lairMatrix[currentPosition[0], currentPosition[1]] = 'P';
                            }
                            else
                            {
                                playerIsAlive = false;
                                break;
                            }
                        }
                        else
                        {
                            playerEscaped = true;
                            currentPosition[1] -= 1;
                        }

                        break;
                    case 'U':
                        lairMatrix[currentPosition[0], currentPosition[1]] = '.';

                        currentPosition[0] -= 1;
                        currentPosition[1] = currentPosition[1];

                        if (PlayerMove(rows, cols, currentPosition[0], currentPosition[1]))
                        {
                            if (lairMatrix[currentPosition[0], currentPosition[1]] != 'B')
                            {
                                lairMatrix[currentPosition[0], currentPosition[1]] = 'P';
                            }
                            else
                            {
                                playerIsAlive = false;
                                break;
                            }
                        }
                        else
                        {
                            playerEscaped = true;
                            currentPosition[0] += 1;
                        }

                        break;
                    case 'D':
                        lairMatrix[currentPosition[0], currentPosition[1]] = '.';

                        currentPosition[0] += 1;
                        currentPosition[1] = currentPosition[1];

                        if (PlayerMove(rows, cols, currentPosition[0], currentPosition[1]))
                        {
                            if (lairMatrix[currentPosition[0], currentPosition[1]] != 'B')
                            {
                                lairMatrix[currentPosition[0], currentPosition[1]] = 'P';
                            }
                            else
                            {
                                playerIsAlive = false;
                                break;
                            }
                        }
                        else
                        {
                            playerEscaped = true;
                            currentPosition[0] -= 1;
                        }

                        break;
                }

                Queue<int> bunnyPositions = new Queue<int>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (lairMatrix[row, col] == 'B')
                        {
                            if (BunnySpread(rows, cols, row - 1, col))
                            {
                                bunnyPositions.Enqueue(row - 1);
                                bunnyPositions.Enqueue(col);
                            }

                            if (BunnySpread(rows, cols, row, col + 1))
                            {
                                bunnyPositions.Enqueue(row);
                                bunnyPositions.Enqueue(col + 1);
                            }

                            if (BunnySpread(rows, cols, row, col - 1))
                            {

                                bunnyPositions.Enqueue(row);
                                bunnyPositions.Enqueue(col - 1);
                            }

                            if (BunnySpread(rows, cols, row + 1, col))
                            {
                                bunnyPositions.Enqueue(row + 1);
                                bunnyPositions.Enqueue(col);
                            }
                        }
                    }
                }

                while (bunnyPositions.Count > 0)
                {
                    int row = bunnyPositions.Dequeue();
                    int col = bunnyPositions.Dequeue();

                    if (lairMatrix[row, col] == 'P')
                    {
                        playerIsAlive = false;
                    }

                    lairMatrix[row, col] = 'B';
                }

                if (!playerIsAlive)
                {
                    break;
                }

                if (playerEscaped)
                {
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{lairMatrix[row, col]}");
                }

                Console.WriteLine();
            }

            if (playerEscaped)
            {
                Console.WriteLine($"won: {currentPosition[0]} {currentPosition[1]}");
            }

            if (!playerIsAlive)
            {
                Console.WriteLine($"dead: {currentPosition[0]} {currentPosition[1]}");
            }
        }

        private static bool PlayerMove(int rows, int cols, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < rows)
            {
                if (col >= 0 && col < cols)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static bool BunnySpread(int rows, int cols, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < rows)
            {
                if (col >= 0 && col < cols)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}
