using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> initialArray = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            int exceptionCounter = 0;

            while (exceptionCounter < 3)
            {
                string[] inputs = Console.ReadLine().Split(" ").ToArray();

                try
                {
                    switch (inputs[0])
                    {
                        case "Replace":
                            int index = int.Parse(inputs[1]);
                            ReplaceIndex(initialArray, index, int.Parse(inputs[2]));

                            break;
                        case "Show":
                            index = int.Parse(inputs[1]);
                            Show(initialArray, index);

                            break;
                        case "Print":
                            int start = int.Parse(inputs[1]);
                            int end = int.Parse(inputs[2]);
                            PrintAll(initialArray, start, end);

                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"The index does not exist!");
                    exceptionCounter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The variable is not in the correct format!");
                    exceptionCounter++;
                }
            }

            Console.WriteLine(string.Join(", ", initialArray));
        }

        public static void ReplaceIndex(List<int> listInitial, int index, int valueToReplace)
        {
            listInitial[index] = valueToReplace;
        }

        public static void PrintAll(List<int> listInitial, int start, int end)
        {
            List<int> toPrint = new List<int>();

            for (int i = start; i <= end; i++)
            {
                toPrint.Add(listInitial[i]);
            }

            Console.WriteLine(string.Join(", ", toPrint));
        }

        public static void Show(List<int> listInitial, int index)
        {
            Console.WriteLine(listInitial[index]);
        }
    }
}
