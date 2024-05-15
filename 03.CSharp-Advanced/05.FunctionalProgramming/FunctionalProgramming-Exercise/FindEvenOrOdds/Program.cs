using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);

            int[] startAndEnd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = startAndEnd[0]; i <= startAndEnd[1]; i++)
            {
                numbers.Add(i);
            }

            string condition = Console.ReadLine();

            switch (condition)
            {
                case "odd":

                    Predicate<int> isOdd = x => x % 2 != 0;

                    Func<List<int>, List<int>> filter = x => x.FindAll(isOdd);

                    Action<List<int>> printOdd = x => Console.WriteLine(string.Join(" ", x));

                    printOdd(filter(numbers));

                    break;
                case "even":
                    Predicate<int> isEven = x => x % 2 == 0;

                    Func<List<int>, List<int>> filterEven = x => x.FindAll(isEven);

                    Action<List<int>> printEven = x => Console.WriteLine(string.Join(" ", x));

                    printEven(filterEven(numbers));

                    break;
            }
        }
    }
}
