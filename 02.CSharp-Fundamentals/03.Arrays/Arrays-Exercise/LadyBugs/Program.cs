using System;
using System.Linq;
using System.Collections.Generic;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugField = new int[fieldSize];
            int[] initialIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                int currIndex = initialIndexes[i];

                if (currIndex >= 0 && currIndex < fieldSize)
                {
                    ladyBugField[currIndex] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] splitCommand = command.Split(' ').ToArray();

                bool isFirst = true;
                int currIndex = int.Parse(splitCommand[0]);

                while (currIndex >= 0 && currIndex < fieldSize && ladyBugField[currIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladyBugField[currIndex] = 0;
                        isFirst = false;
                    }

                    string direction = splitCommand[1];
                    int flightLength = int.Parse(splitCommand[2]);

                    if (direction == "left")
                    {
                        currIndex -= flightLength;
                        if (currIndex >= 0 && currIndex < fieldSize)
                        {
                            if (ladyBugField[currIndex] == 0)
                            {
                                ladyBugField[currIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currIndex += flightLength;
                        if (currIndex >= 0 && currIndex < fieldSize)
                        {
                            if (ladyBugField[currIndex] == 0)
                            {
                                ladyBugField[currIndex] = 1;
                                break;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", ladyBugField));
        }
    }
}
