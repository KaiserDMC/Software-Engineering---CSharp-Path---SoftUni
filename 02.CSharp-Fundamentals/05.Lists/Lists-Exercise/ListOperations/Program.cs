using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "End")
            {
                string[] command = input;
                string commandName = command[0];

                switch (commandName)
                {
                    case "Add":
                        integerList.Add(int.Parse(command[1]));
                        break;
                    case "Insert":
                        int indexToInsert = int.Parse(command[2]);

                        if (indexToInsert >= integerList.Count || indexToInsert < 0)
                        {
                            Console.WriteLine($"Invalid index");
                        }
                        else
                        {
                            integerList.Insert(indexToInsert, int.Parse(command[1]));
                        }

                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(command[1]);

                        if (indexToRemove >= integerList.Count || indexToRemove < 0)
                        {
                            Console.WriteLine($"Invalid index");
                        }
                        else
                        {
                            integerList.RemoveAt(indexToRemove);
                        }
                        break;
                    case "Shift":
                        string direction = command[1];
                        int commandCount = int.Parse(command[2]);

                        if (direction == "left")
                        {
                            for (int i = 0; i < commandCount; i++)
                            {
                                int tempNumber = integerList[0];
                                integerList.Add(tempNumber);
                                integerList.RemoveAt(0);
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i < commandCount; i++)
                            {
                                int tempNumber = integerList[integerList.Count - 1];
                                integerList.Insert(0, tempNumber);
                                integerList.RemoveAt(integerList.Count - 1);
                            }
                        }
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ", integerList));
        }
    }
}
