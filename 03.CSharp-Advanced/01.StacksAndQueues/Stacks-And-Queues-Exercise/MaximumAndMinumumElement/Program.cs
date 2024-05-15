using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinumumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Stack<int> numberStack = new Stack<int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] commandInput = Console.ReadLine().Split(" ").ToArray();

                switch (commandInput[0])
                {
                    case "1":
                        numberStack.Push(int.Parse(commandInput[1]));
                        break;
                    case "2":
                        if (numberStack.Count > 0)
                        {
                            numberStack.Pop();
                        }
                        break;
                    case "3":
                        if (numberStack.Count > 0)
                        {
                            Console.WriteLine(numberStack.Max());
                        }
                        break;
                    case "4":
                        if (numberStack.Count > 0)
                        {
                            Console.WriteLine(numberStack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numberStack));
        }
    }
}
