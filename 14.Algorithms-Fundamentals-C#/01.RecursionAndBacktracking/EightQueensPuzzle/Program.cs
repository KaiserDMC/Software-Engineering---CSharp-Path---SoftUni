using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace EightQueensPuzzle
{
    public class Program
    {
        private static bool[,] chessboard;
        private static HashSet<int> attackedRow = new HashSet<int>();
        private static HashSet<int> attackedCol = new HashSet<int>();
        private static HashSet<int> attackedLeftDiag = new HashSet<int>();
        private static HashSet<int> attackedRightDiag = new HashSet<int>();

        static void Main(string[] args)
        {
            chessboard = new bool[8, 8];

            PlaceQueen(chessboard, 0);
        }

        private static void PlaceQueen(bool[,] board, int row)
        {
            if (row >= chessboard.GetLength(0))
            {
                PrintBoard();
                return;
            }

            // Only columns since its square matrix
            for (int col = 0; col < chessboard.GetLength(1); col++)
            {
                // There is no Queen present
                if (IsFreePosition(row, col))
                {
                    // Mark Positions
                    attackedRow.Add(row);
                    attackedCol.Add(col);
                    attackedLeftDiag.Add(col - row);
                    attackedRightDiag.Add(col + row);
                    // Mark Placement
                    chessboard[row, col] = true;

                    // Recursive Call
                    PlaceQueen(chessboard, row + 1);

                    // Unmark Position
                    attackedRow.Remove(row);
                    attackedCol.Remove(col);
                    attackedLeftDiag.Remove(col - row);
                    attackedRightDiag.Remove(col + row);
                    // Unmark Placement
                    chessboard[row, col] = false;
                }
            }
        }

        private static void PrintBoard()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if (chessboard[i, j])
                    {
                        Console.Write($"* ");
                    }
                    else
                    {
                        Console.Write($"- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool IsFreePosition(int row, int col)
        {
            return !attackedRow.Contains(row) &&
                   !attackedCol.Contains(col) &&
                   !attackedLeftDiag.Contains(col - row) &&
                   !attackedRightDiag.Contains(col + row);
        }
    }
}