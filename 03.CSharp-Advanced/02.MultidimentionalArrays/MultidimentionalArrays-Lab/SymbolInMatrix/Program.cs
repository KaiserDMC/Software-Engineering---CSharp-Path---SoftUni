using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());

            int[,] theFinalMatrix = new int[squareSize, squareSize];

            for (int row = 0; row < squareSize; row++)
            {
                string currentRowChars = Console.ReadLine();

                for (int col = 0; col < squareSize; col++)
                {
                    theFinalMatrix[row, col] = currentRowChars[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());
            bool isPresent = false;

            for (int row = 0; row < squareSize; row++)
            {
                for (int col = 0; col < squareSize; col++)
                {
                    if (theFinalMatrix[row, col] == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isPresent = true;
                        break;
                    }
                }

                if (isPresent)
                {
                    break;
                }
            }

            if (!isPresent)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
