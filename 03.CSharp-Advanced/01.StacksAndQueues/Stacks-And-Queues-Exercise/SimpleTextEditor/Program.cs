using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();

            Stack<string> undoStack = new Stack<string>();

            undoStack.Push(text.ToString());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commandStrings = Console.ReadLine().Split(" ").ToArray();

                switch (commandStrings[0])
                {
                    case "1":
                        text = text.Append(commandStrings[1]);

                        undoStack.Push(text.ToString());

                        break;
                    case "2":
                        int count = int.Parse(commandStrings[1]);
                        text = text.Remove(text.Length - count, count);

                        undoStack.Push(text.ToString());

                        break;
                    case "3":
                        int index = int.Parse(commandStrings[1]);

                        Console.WriteLine(text[index - 1]);

                        break;
                    case "4":
                        undoStack.Pop();

                        text = text.Remove(0, text.Length);

                        text = text.Append(undoStack.Peek());

                        break;
                }
            }
        }
    }
}
