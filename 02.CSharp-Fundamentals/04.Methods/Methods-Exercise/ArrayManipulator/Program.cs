using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split(' ');

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);
                    initialArray = ExchangeOperation(initialArray, index);
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    MinMax(initialArray, command[0], command[1]);
                }
                else
                {
                    FindNumber(initialArray, command[0], int.Parse(command[1]), command[2]);
                }

                command = Console.ReadLine().Split(' ');
            }

            Console.WriteLine($"[{string.Join(", ", initialArray)}]");
        }

        private static void FindNumber(int[] initialArray, string position, int numCount, string OddEven)
        {
            if (numCount > initialArray.Length)
            {
                Console.WriteLine($"Invalid count");
                return;
            }

            if (numCount == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            int resultOddEven = 1;

            if (OddEven == "even")
            {
                resultOddEven = 0;
            }

            int count = 0;
            List<int> numbers = new List<int>();

            if (position == "first")
            {
                foreach (int element in initialArray)
                {
                    if (element % 2 == resultOddEven)
                    {
                        count++;
                        numbers.Add(element);
                    }

                    if (count == numCount)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = initialArray.Length - 1; i >= 0; i--)
                {
                    if (initialArray[i] % 2 == resultOddEven)
                    {
                        count++;
                        numbers.Add(initialArray[i]);
                    }

                    if (count == numCount)
                    {
                        break;
                    }
                }

                numbers.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void MinMax(int[] initialArray, string MinMax, string OddEven)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOddEven = 1;

            if (OddEven == "even")
            {
                resultOddEven = 0;
            }

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] % 2 == resultOddEven)
                {
                    if (MinMax == "min" && min >= initialArray[i])
                    {
                        min = initialArray[i];
                        index = i;
                    }
                    else if (MinMax == "max" && max <= initialArray[i])
                    {
                        max = initialArray[i];
                        index = i;
                    }
                }
            }

            if (index > -1)
            {
                Console.WriteLine(index.ToString());
            }
            else
            {
                Console.WriteLine($"No matches");
            }
        }

        static int[] ExchangeOperation(int[] initialArray, int index)
        {
            if (index >= initialArray.Length || index < 0)
            {
                Console.WriteLine($"Invalid index");
                return initialArray;
            }

            int[] newArray = new int[initialArray.Length];
            int currIndex = 0;

            for (int i = index + 1; i < initialArray.Length; i++)
            {
                newArray[currIndex] = initialArray[i];
                currIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                newArray[currIndex] = initialArray[i];
                currIndex++;
            }

            return newArray;
        }
    }
}
