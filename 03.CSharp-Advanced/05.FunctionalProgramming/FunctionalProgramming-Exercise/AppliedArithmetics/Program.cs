using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            Func<List<int>, List<int>> add = x => x.Select(n => n += 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(n => n *= 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(n => n -= 1).ToList();

            Action<List<int>> printAction = x => Console.WriteLine(string.Join(" ", x));

            List<int> inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        inputNumbers = add(inputNumbers);

                        break;
                    case "multiply":
                        inputNumbers = multiply(inputNumbers);

                        break;
                    case "subtract":
                        inputNumbers = subtract(inputNumbers);

                        break;
                    case "print":
                        printAction(inputNumbers);

                        break;
                }
            }
        }
    }
}
