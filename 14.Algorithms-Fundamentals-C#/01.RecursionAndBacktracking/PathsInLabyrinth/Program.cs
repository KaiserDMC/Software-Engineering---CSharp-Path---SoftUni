using System;
using System.Collections.Generic;

namespace PathsInLabyrinth
{
    public class Program
    {
        private static char[,] labyrinth;
        private static List<string> _directions = new List<string>();

        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());
            int matrixCol = int.Parse(Console.ReadLine());
            labyrinth = new char[matrixRow, matrixCol];

            for (int row = 0; row < matrixRow; row++)
            {
                var currRow = Console.ReadLine();

                for (int col = 0; col < currRow.Length; col++)
                {
                    labyrinth[row, col] = currRow[col];
                }
            }

            FindPaths(0, 0, "");
        }

        private static void FindPaths(int row, int col, string direction)
        {
            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return;
            }

            _directions.Add(direction);

            if (labyrinth[row, col] == 'e')
            {
                Print();
            }
            else if (labyrinth[row, col] == '-' && labyrinth[row, col] != 'x')
            {
                labyrinth[row, col] = 'x';

                FindPaths(row, col + 1, "R");
                FindPaths(row + 1, col, "D");
                FindPaths(row, col - 1, "L");
                FindPaths(row - 1, col, "U");

                labyrinth[row, col] = '-';
            }
            
            _directions.RemoveAt(_directions.Count - 1);
        }

        private static void Print()
        {
            Console.WriteLine(string.Join("", _directions));
        }
    }
}