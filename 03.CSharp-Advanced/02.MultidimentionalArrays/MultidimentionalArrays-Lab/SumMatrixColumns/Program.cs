using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = inputMatrix[0];
            int cols = inputMatrix[1];

            int[,] theMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRowElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    theMatrix[row, col] = currentRowElements[col];
                }
            }

            int[,] sumColumn = new int[cols, 1];


            for (int column = 0; column < cols; column++)
            {
                int sum = 0;

                for (int roww = 0; roww < rows; roww++)
                {
                    sum += theMatrix[roww, column];
                }

                sumColumn[column, 0] = sum;
            }

            foreach (var VARIABLE in sumColumn)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
