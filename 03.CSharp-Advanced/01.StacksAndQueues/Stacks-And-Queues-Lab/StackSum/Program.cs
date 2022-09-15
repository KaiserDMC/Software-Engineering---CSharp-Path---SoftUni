using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> numberStack = new Stack<int>(inputNumbers);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] commandSplit = command.Split().ToArray();

                switch (commandSplit[0])
                {
                    case "add":
                        int numberOne = int.Parse(commandSplit[1]);
                        int numberTwo = int.Parse(commandSplit[2]);

                        numberStack.Push(numberOne);
                        numberStack.Push(numberTwo);

                        break;
                    case "remove":
                        int countToRemove = int.Parse(commandSplit[1]);

                        if (!(countToRemove > numberStack.Count))
                        {
                            for (int i = 0; i < countToRemove; i++)
                            {
                                numberStack.Pop();
                            }
                        }

                        break;
                }

                command = Console.ReadLine().ToLower();
            }

            int sum = numberStack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
