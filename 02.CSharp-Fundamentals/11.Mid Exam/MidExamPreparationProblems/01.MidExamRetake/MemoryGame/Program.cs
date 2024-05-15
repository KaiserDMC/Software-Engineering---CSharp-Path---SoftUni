using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine().Split(" ").ToList();
            string inputString = Console.ReadLine();
            int moveCount = 0;

            while (inputString != "end")
            {
                int[] indices = inputString.Split(" ").Select(int.Parse).ToArray();
                moveCount++;

                if (indices[0] == indices[1] || (indices[0] < 0 || indices[0] >= sequenceOfElements.Count) || (indices[1] < 0 || indices[1] >= sequenceOfElements.Count))
                {
                    int indexToInsert = sequenceOfElements.Count / 2;
                    string[] toAdd = new[] { $"-{moveCount}a", $"-{moveCount}a" }.ToArray();
                    sequenceOfElements.InsertRange(indexToInsert, toAdd);
                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (sequenceOfElements[indices[0]] == sequenceOfElements[indices[1]])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {sequenceOfElements[indices[0]]}!");
                        string elementToRemove = sequenceOfElements[indices[0]];
                        sequenceOfElements.Remove(elementToRemove);
                        sequenceOfElements.Remove(elementToRemove);
                    }
                    else
                    {
                        Console.WriteLine($"Try again!");
                    }
                }

                if (sequenceOfElements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moveCount} turns!");
                    break;
                }

                inputString = Console.ReadLine();
            }

            if (sequenceOfElements.Count != 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequenceOfElements));
            }
        }
    }
}
