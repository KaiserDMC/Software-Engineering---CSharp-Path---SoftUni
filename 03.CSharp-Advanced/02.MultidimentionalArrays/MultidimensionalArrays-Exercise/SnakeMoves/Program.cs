using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            char[,] theSnakeMatrix = new char[rows, cols];

            string snake = Console.ReadLine();

            Queue<char> snakeQueue = new Queue<char>(snake.ToCharArray());

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {

                        theSnakeMatrix[row, col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        theSnakeMatrix[row, col] = snakeQueue.Peek();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{theSnakeMatrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
