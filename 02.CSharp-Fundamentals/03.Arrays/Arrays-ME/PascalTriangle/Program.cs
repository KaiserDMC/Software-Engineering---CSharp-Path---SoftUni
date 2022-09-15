using System;
using System.Linq;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int[][] triangleRows = new int[inputNumber][];

            for (int i = 0; i < inputNumber; i++)
            {
                triangleRows[i] = new int[i + 1];
            }

            triangleRows[0][0] = 1;

            for (int j = 0; j < inputNumber - 1; j++)
            {

                for (int k = 0; k <= j; k++)
                {
                    triangleRows[j + 1][k] += triangleRows[j][k];
                    triangleRows[j + 1][k + 1] += triangleRows[j][k];
                }
            }

            for (int row = 0; row < inputNumber; row++)
            {
                for (int column = 0; column <= row; column++)
                {
                    Console.Write($"{triangleRows[row][column]} ");

                }

                Console.WriteLine();

            }
        }
    }
}
