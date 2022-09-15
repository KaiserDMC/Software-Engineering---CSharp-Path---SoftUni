using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ListManipulationAdvancedV2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split(" ").ToArray();

            bool isListChanged = false;

            while (input[0] != "end")
            {
                string[] command = input;
                string commandPrefix = command[0];
                string commandDetails = String.Empty;

                switch (commandPrefix)
                {
                    case "Add":
                        commandDetails = command[1];
                        numberList = Add(numberList, commandDetails);
                        isListChanged = true;
                        break;
                    case "Remove":
                        commandDetails = command[1];
                        numberList = Remove(numberList, commandDetails);
                        isListChanged = true;
                        break;
                    case "RemoveAt":
                        commandDetails = command[1];
                        numberList = RemoveAt(numberList, commandDetails);
                        isListChanged = true;
                        break;
                    case "Insert":
                        commandDetails = command[1];
                        string commandIndex = command[2];
                        numberList = Insert(numberList, commandDetails, commandIndex);
                        isListChanged = true;
                        break;
                    case "Contains":
                        commandDetails = command[1];
                        Contains(numberList, commandDetails);
                        break;
                    case "PrintEven":
                        PrintEven(numberList);
                        break;
                    case "PrintOdd":
                        PrintOdd(numberList);
                        break;
                    case "GetSum":
                        GetSum(numberList);
                        break;
                    case "Filter":
                        commandDetails = command[1];
                        commandIndex = command[2];
                        Filter(numberList, commandDetails, commandIndex);
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numberList));
            }
        }



        static List<int> Add(List<int> numberList, string commandDetails)
        {
            numberList.Add(int.Parse(commandDetails));
            return numberList;
        }
        static List<int> Remove(List<int> numberList, string commandDetails)
        {
            numberList.Remove(int.Parse(commandDetails));
            return numberList;
        }
        static List<int> RemoveAt(List<int> numberList, string commandDetails)
        {
            numberList.RemoveAt(int.Parse(commandDetails));
            return numberList;
        }
        static List<int> Insert(List<int> numberList, string commandDetails, string commandIndex)
        {
            numberList.Insert(int.Parse(commandIndex), int.Parse(commandDetails));
            return numberList;
        }

        static void Contains(List<int> numberList, string commandDetails)
        {
            bool numberIsPresent = numberIsPresent = numberList.Contains(int.Parse(commandDetails));

            if (numberIsPresent)
            {
                Console.WriteLine($"Yes");
            }
            else
            {
                Console.WriteLine($"No such number");
            }
        }

        static void PrintEven(List<int> numberList)
        {
            List<int> evenNumberList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 0)
                {
                    evenNumberList.Add(numberList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenNumberList));
        }

        static void PrintOdd(List<int> numberList)
        {
            List<int> oddNumberList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 != 0)
                {
                    oddNumberList.Add(numberList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oddNumberList));
        }

        static void GetSum(List<int> numberList)
        {
            int sum = numberList.Sum();

            Console.WriteLine(sum);
        }

        static void Filter(List<int> numberList, string commandDetails, string commandIndex)
        {
            List<int> filteredNumberList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (commandDetails == "<")
                {
                    if (numberList[i] < int.Parse(commandIndex))
                    {
                        filteredNumberList.Add(numberList[i]);
                    }
                }
                else if (commandDetails == ">")
                {
                    if (numberList[i] > int.Parse(commandIndex))
                    {
                        filteredNumberList.Add(numberList[i]);
                    }
                }
                else if (commandDetails == ">=")
                {
                    if (numberList[i] >= int.Parse(commandIndex))
                    {
                        filteredNumberList.Add(numberList[i]);
                    }
                }
                else if (commandDetails == "<=")
                {
                    if (numberList[i] <= int.Parse(commandIndex))
                    {
                        filteredNumberList.Add(numberList[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", filteredNumberList));
        }
    }
}
