using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
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

                switch (command[0])
                {

                    case "Add":
                        numberList.Add(int.Parse(command[1]));
                        isListChanged = true;
                        break;
                    case "Remove":
                        numberList.Remove(int.Parse(command[1]));
                        isListChanged = true;
                        break;
                    case "RemoveAt":
                        numberList.RemoveAt(int.Parse(command[1]));
                        isListChanged = true;
                        break;
                    case "Insert":
                        numberList.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isListChanged = true;
                        break;
                    case "Contains":
                        bool numberIsPresent = numberList.Contains(int.Parse(command[1]));

                        if (numberIsPresent)
                        {
                            Console.WriteLine($"Yes");
                        }
                        else
                        {
                            Console.WriteLine($"No such number");
                        }

                        break;
                    case "PrintEven":
                        List<int> evenNumberList = new List<int>();
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            if (numberList[i] % 2 == 0)
                            {
                                evenNumberList.Add(numberList[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", evenNumberList));
                        break;
                    case "PrintOdd":
                        List<int> oddNumberList = new List<int>();
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            if (numberList[i] % 2 != 0)
                            {
                                oddNumberList.Add(numberList[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", oddNumberList));
                        break;
                    case "GetSum":
                        int sum = numberList.Sum();
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        List<int> filteredNumberList = new List<int>();
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            if (command[1] == "<")
                            {
                                if (numberList[i] < int.Parse(command[2]))
                                {
                                    filteredNumberList.Add(numberList[i]);
                                }
                            }
                            else if (command[1] == ">")
                            {
                                if (numberList[i] > int.Parse(command[2]))
                                {
                                    filteredNumberList.Add(numberList[i]);
                                }
                            }
                            else if (command[1] == ">=")
                            {
                                if (numberList[i] >= int.Parse(command[2]))
                                {
                                    filteredNumberList.Add(numberList[i]);
                                }
                            }
                            else if (command[1] == "<=")
                            {
                                if (numberList[i] <= int.Parse(command[2]))
                                {
                                    filteredNumberList.Add(numberList[i]);
                                }
                            }
                        }
                        Console.WriteLine(string.Join(" ", filteredNumberList));
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numberList));
            }
        }
    }
}
