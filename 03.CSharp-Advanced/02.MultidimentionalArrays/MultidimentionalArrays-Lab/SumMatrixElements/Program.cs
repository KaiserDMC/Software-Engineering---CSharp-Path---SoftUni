using System;
using System.Dynamic;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = inputMatrix[0];
            int cols = inputMatrix[1];
            int sum = 0;

            int[,] matrixOfInts = new int[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrixOfInts[row, col] = currentRow[col];

                    sum += currentRow[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
