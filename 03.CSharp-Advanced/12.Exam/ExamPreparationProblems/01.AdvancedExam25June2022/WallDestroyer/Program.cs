using System;
using System.Threading.Channels;

namespace WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] theMatrix = new char[matrixSize, matrixSize];

            int startRow = 0;
            int startCol = 0;

            int counterInitialHoles = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] currentLine = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    theMatrix[row, col] = currentLine[col];

                    if (currentLine[col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (currentLine[col] == '-')
                    {
                        counterInitialHoles++;
                    }
                }
            }

            int currentRow = startRow;
            int currentCol = startCol;

            int holeCounter = 1;
            int rodCounter = 0;
            bool electrocuted = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "left":
                        currentCol -= 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            char move = ValidMove(theMatrix, currentRow, currentCol);

                            if (move == '*')
                            {
                                holeCounter++;
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow, currentCol + 1] = move;
                            }
                            else if (move == 'R')
                            {
                                Console.WriteLine($"Vanko hit a rod!");
                                currentCol += 1;
                                rodCounter++;
                            }
                            else if (move == 'E')
                            {
                                holeCounter++;
                                electrocuted = true;
                                theMatrix[currentRow, currentCol] = 'E';
                                theMatrix[currentRow, currentCol + 1] = '*';
                            }
                            else
                            {
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow, currentCol + 1] = '*';
                                Console.WriteLine(
                                    $"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                        }
                        else
                        {
                            currentCol += 1;
                        }

                        break;

                    case "right":
                        currentCol += 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            char move = ValidMove(theMatrix, currentRow, currentCol);

                            if (move == '*')
                            {
                                holeCounter++;
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow, currentCol - 1] = move;
                            }
                            else if (move == 'R')
                            {
                                Console.WriteLine($"Vanko hit a rod!");
                                currentCol -= 1;
                                rodCounter++;
                            }
                            else if (move == 'E')
                            {
                                holeCounter++;
                                electrocuted = true;
                                theMatrix[currentRow, currentCol] = 'E';
                                theMatrix[currentRow, currentCol - 1] = '*';
                            }
                            else
                            {
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow, currentCol - 1] = '*';
                                Console.WriteLine(
                                    $"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                        }
                        else
                        {
                            currentCol -= 1;
                        }

                        break;

                    case "up":
                        currentRow -= 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            char move = ValidMove(theMatrix, currentRow, currentCol);

                            if (move == '*')
                            {
                                holeCounter++;
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow + 1, currentCol] = move;
                            }
                            else if (move == 'R')
                            {
                                Console.WriteLine($"Vanko hit a rod!");
                                currentRow += 1;
                                rodCounter++;
                            }
                            else if (move == 'E')
                            {
                                holeCounter++;
                                electrocuted = true;
                                theMatrix[currentRow, currentCol] = 'E';
                                theMatrix[currentRow + 1, currentCol] = '*';
                            }
                            else
                            {
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow + 1, currentCol] = '*';
                                Console.WriteLine(
                                    $"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                        }
                        else
                        {
                            currentRow += 1;
                        }

                        break;

                    case "down":
                        currentRow += 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            char move = ValidMove(theMatrix, currentRow, currentCol);

                            if (move == '*')
                            {
                                holeCounter++;

                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow - 1, currentCol] = move;
                            }
                            else if (move == 'R')
                            {
                                Console.WriteLine($"Vanko hit a rod!");
                                currentRow -= 1;
                                rodCounter++;
                            }
                            else if (move == 'E')
                            {
                                holeCounter++;
                                electrocuted = true;
                                theMatrix[currentRow, currentCol] = 'E';
                                theMatrix[currentRow - 1, currentCol] = '*';
                            }
                            else
                            {
                                theMatrix[currentRow, currentCol] = 'V';
                                theMatrix[currentRow - 1, currentCol] = '*';
                                Console.WriteLine(
                                    $"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                            }
                        }
                        else
                        {
                            currentRow -= 1;
                        }

                        break;
                }

                if (electrocuted)
                {
                    break;
                }
            }

            if (electrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodCounter} rod(s).");
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"{theMatrix[i, j]}");
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

        private static char ValidMove(char[,] currentMatrix, int row, int col)
        {
            if (currentMatrix[row, col] == '-')
            {
                return '*';
            }
            else if (currentMatrix[row, col] == 'R')
            {
                return 'R';
            }
            else if (currentMatrix[row, col] == 'C')
            {
                return 'E';
            }
            else
            {
                return 'A';
            }
        }
    }
}