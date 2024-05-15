using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardDimensions = int.Parse(Console.ReadLine());

            char[,] chessMatrix = new char[boardDimensions, boardDimensions];

            for (int row = 0; row < boardDimensions; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < boardDimensions; col++)
                {
                    chessMatrix[row, col] = currentRow[col];
                }
            }

            if (boardDimensions <= 2)
            {
                return;
            }

            int knightCounter = 0;

            while (true)
            {
                int counterMost = 0;
                int mostRow = 0;
                int mostCol = 0;

                for (int row = 0; row < boardDimensions; row++)
                {
                    for (int col = 0; col < boardDimensions; col++)
                    {
                        if (chessMatrix[row, col] == 'K')
                        {
                            int removeCounter = 0;

                            if (row - 2 < boardDimensions && col + 1 < boardDimensions)
                            {
                                if (row - 2 >= 0 && chessMatrix[row - 2, col + 1] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row - 2 < boardDimensions && col - 1 < boardDimensions)
                            {
                                if (row - 2 >= 0 && col - 1 >= 0 && chessMatrix[row - 2, col - 1] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row - 1 < boardDimensions && col - 2 < boardDimensions)
                            {
                                if (row - 1 >= 0 && col - 2 >= 0 && chessMatrix[row - 1, col - 2] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row - 1 < boardDimensions && col + 2 < boardDimensions)
                            {
                                if (row - 1 >= 0 && chessMatrix[row - 1, col + 2] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row + 1 < boardDimensions && col - 2 < boardDimensions)
                            {
                                if (col - 2 >= 0 && chessMatrix[row + 1, col - 2] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row + 2 < boardDimensions && col - 1 < boardDimensions)
                            {
                                if (col - 1 >= 0 && chessMatrix[row + 2, col - 1] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row + 2 < boardDimensions && col + 1 < boardDimensions)
                            {
                                if (chessMatrix[row + 2, col + 1] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (row + 1 < boardDimensions && col + 2 < boardDimensions)
                            {
                                if (chessMatrix[row + 1, col + 2] == 'K')
                                {
                                    removeCounter++;
                                }
                            }

                            if (counterMost < removeCounter)
                            {
                                counterMost = removeCounter;
                                mostRow = row;
                                mostCol = col;
                            }
                        }
                    }
                }

                if (counterMost == 0)
                {
                    break;
                }
                else
                {
                    chessMatrix[mostRow, mostCol] = '0';
                    knightCounter++;
                }
            }

            Console.WriteLine(knightCounter);
        }
    }
}
