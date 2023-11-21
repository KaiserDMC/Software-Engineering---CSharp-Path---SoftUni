using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInMatrix
{
    public class Program
    {
        private static char[,] matrix;
        private static int size;

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var areas = new List<Area>();
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    size = 0;
                    ExploreMatrix(row, col);

                    if (size != 0)
                    {
                        areas.Add(new Area
                        {
                            Row = row,
                            Col = col,
                            Size = size
                        });
                    }
                }
            }
            
            Console.WriteLine($"Total areas found: {areas.Count}");

            var sortedAreas = areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col).ToList();
            
            for (int i = 0; i < sortedAreas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({sortedAreas[i].Row}, {sortedAreas[i].Col}), size: {sortedAreas[i].Size}");
            }
        }

        private static void ExploreMatrix(int row, int col)
        {
            if (IsOutOfBounds(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = 'v';

            ExploreMatrix(row - 1, col); // up
            ExploreMatrix(row + 1, col); // down
            ExploreMatrix(row, col - 1); // left
            ExploreMatrix(row, col + 1); // right
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutOfBounds(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) ||
                   col < 0 || col >= matrix.GetLength(1);
        }
    }

    public class Area
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }
    }
}