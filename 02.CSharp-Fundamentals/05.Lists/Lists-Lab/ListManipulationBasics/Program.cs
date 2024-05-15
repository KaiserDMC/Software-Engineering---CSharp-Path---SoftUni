using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "end")
            {
                string[] command = input;

                switch (command[0])
                {
                    case "Add":
                        inputList.Add(int.Parse(command[1]));
                        break;
                    case "Remove":
                        inputList.Remove(int.Parse(command[1]));
                        break;
                    case "RemoveAt":
                        inputList.RemoveAt(int.Parse(command[1]));
                        break;
                    case "Insert":
                        inputList.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
