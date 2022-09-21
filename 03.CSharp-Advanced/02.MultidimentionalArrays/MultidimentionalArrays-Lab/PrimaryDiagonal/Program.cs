using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] theNextMatrix = new int[squareSize, squareSize];
            int sum = 0;

            for (int row = 0; row < squareSize; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < squareSize; col++)
                {
                    theNextMatrix[row, col] = currentRow[col];

                    if (row == col)
                    {
                        sum += theNextMatrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
