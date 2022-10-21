using System;
using System.Collections.Generic;

namespace Help_A_Mole
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] moleMatrix = new char[matrixSize, matrixSize];

            int startRow = 0;
            int startCol = 0;
            int molePoints = 0;
            int[] specialPositions = new int[4];
            int index = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                char[] charInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    moleMatrix[row, col] = charInput[col];

                    if (charInput[col] == 'M')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (charInput[col] == 'S')
                    {
                        specialPositions[index] = row;
                        index++;
                        specialPositions[index] = col;
                        index++;
                    }
                }
            }

            int currentRow = startRow;
            int currentCol = startCol;

            int oldRow = 0;
            int oldCol = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End" || molePoints >= 25)
                {
                    break;
                }

                switch (command)
                {
                    case "left":
                        currentCol -= 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            if (char.IsDigit(moleMatrix[currentRow, currentCol]))
                            {
                                molePoints += int.Parse(moleMatrix[currentRow, currentCol].ToString());
                                moleMatrix[currentRow, currentCol + 1] = '-';
                            }
                            else
                            {
                                if (moleMatrix[currentRow, currentCol] == 'S')
                                {
                                    moleMatrix[currentRow, currentCol + 1] = '-';
                                    if (currentRow == specialPositions[0])
                                    {
                                        oldRow = specialPositions[0];
                                        oldCol = specialPositions[1];
                                        currentRow = specialPositions[2];
                                        currentCol = specialPositions[3];
                                    }
                                    else
                                    {
                                        currentRow = specialPositions[0];
                                        currentCol = specialPositions[1];
                                        oldRow = specialPositions[2];
                                        oldCol = specialPositions[3];
                                    }

                                    molePoints -= 3;
                                    moleMatrix[oldRow, oldCol] = '-';
                                }
                                else
                                {
                                    moleMatrix[currentRow, currentCol + 1] = '-';
                                }
                            }

                            moleMatrix[currentRow, currentCol] = 'M';
                        }
                        else
                        {
                            Console.WriteLine($"Don't try to escape the playing field!");
                            currentCol += 1;
                        }

                        break;
                    case "right":

                        currentCol += 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            if (char.IsDigit(moleMatrix[currentRow, currentCol]))
                            {
                                molePoints += int.Parse(moleMatrix[currentRow, currentCol].ToString());
                                moleMatrix[currentRow, currentCol - 1] = '-';
                            }
                            else
                            {
                                if (moleMatrix[currentRow, currentCol] == 'S')
                                {
                                    moleMatrix[currentRow, currentCol - 1] = '-';
                                    if (currentRow == specialPositions[0])
                                    {
                                        oldRow = specialPositions[0];
                                        oldCol = specialPositions[1];
                                        currentRow = specialPositions[2];
                                        currentCol = specialPositions[3];
                                    }
                                    else
                                    {
                                        currentRow = specialPositions[0];
                                        currentCol = specialPositions[1];
                                        oldRow = specialPositions[2];
                                        oldCol = specialPositions[3];
                                    }

                                    molePoints -= 3;
                                    moleMatrix[oldRow, oldCol] = '-';
                                }
                                else
                                {
                                    moleMatrix[currentRow, currentCol - 1] = '-';
                                }
                            }

                            moleMatrix[currentRow, currentCol] = 'M';
                        }
                        else
                        {
                            Console.WriteLine($"Don't try to escape the playing field!");
                            currentCol -= 1;
                        }

                        break;
                    case "up":

                        currentRow -= 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            if (char.IsDigit(moleMatrix[currentRow, currentCol]))
                            {
                                molePoints += int.Parse(moleMatrix[currentRow, currentCol].ToString());
                                moleMatrix[currentRow + 1, currentCol] = '-';
                            }
                            else
                            {
                                if (moleMatrix[currentRow, currentCol] == 'S')
                                {
                                    moleMatrix[currentRow + 1, currentCol] = '-';
                                    if (currentRow == specialPositions[0])
                                    {
                                        oldRow = specialPositions[0];
                                        oldCol = specialPositions[1];
                                        currentRow = specialPositions[2];
                                        currentCol = specialPositions[3];
                                    }
                                    else
                                    {
                                        currentRow = specialPositions[0];
                                        currentCol = specialPositions[1];
                                        oldRow = specialPositions[2];
                                        oldCol = specialPositions[3];
                                    }

                                    molePoints -= 3;
                                    moleMatrix[oldRow, oldCol] = '-';
                                }
                                else
                                {
                                    moleMatrix[currentRow + 1, currentCol] = '-';
                                }
                            }

                            moleMatrix[currentRow, currentCol] = 'M';
                        }
                        else
                        {
                            Console.WriteLine($"Don't try to escape the playing field!");
                            currentRow += 1;
                        }

                        break;
                    case "down":
                        currentRow += 1;

                        if (ValidIndex(matrixSize, currentRow, currentCol))
                        {
                            if (char.IsDigit(moleMatrix[currentRow, currentCol]))
                            {
                                molePoints += int.Parse(moleMatrix[currentRow, currentCol].ToString());
                                moleMatrix[currentRow - 1, currentCol] = '-';
                            }
                            else
                            {
                                if (moleMatrix[currentRow, currentCol] == 'S')
                                {
                                    moleMatrix[currentRow - 1, currentCol] = '-';
                                    if (currentRow == specialPositions[0])
                                    {
                                        oldRow = specialPositions[0];
                                        oldCol = specialPositions[1];
                                        currentRow = specialPositions[2];
                                        currentCol = specialPositions[3];
                                    }
                                    else
                                    {
                                        currentRow = specialPositions[0];
                                        currentCol = specialPositions[1];
                                        oldRow = specialPositions[2];
                                        oldCol = specialPositions[3];
                                    }

                                    molePoints -= 3;
                                    moleMatrix[oldRow, oldCol] = '-';
                                }
                                else
                                {
                                    moleMatrix[currentRow - 1, currentCol] = '-';
                                }
                            }

                            moleMatrix[currentRow, currentCol] = 'M';
                        }
                        else
                        {
                            Console.WriteLine($"Don't try to escape the playing field!");
                            currentRow -= 1;
                        }

                        break;
                }
            }

            if (molePoints >= 25)
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"{moleMatrix[i, j]}");
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