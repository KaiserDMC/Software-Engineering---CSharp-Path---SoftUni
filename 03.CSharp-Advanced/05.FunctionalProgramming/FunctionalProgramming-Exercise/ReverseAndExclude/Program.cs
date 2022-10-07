using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            List<int> inputNumbers = Console.ReadLine()
                .Split(" ")
                .Select(parser)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % divisor == 0;

            Func<List<int>, List<int>> filter = x => x.Where(n => isDivisible(n) == false).ToList();

            inputNumbers.Reverse();

            Console.WriteLine(string.Join(" ", filter(inputNumbers)));
        }
    }
}
