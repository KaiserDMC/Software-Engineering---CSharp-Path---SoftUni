using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            Func<int, bool> filter = x => x % 2 == 0;

            List<int> numberList = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .Where(filter)
                .OrderBy(n => n)
                .ToList();

            Action<List<int>> toPrintAction = ints => Console.WriteLine(string.Join(", ", ints));

            toPrintAction(numberList);
        }
    }
}
