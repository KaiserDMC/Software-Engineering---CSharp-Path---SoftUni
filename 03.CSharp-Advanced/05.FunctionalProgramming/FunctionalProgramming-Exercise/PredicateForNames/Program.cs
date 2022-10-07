using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> isValid = n => n.Length <= maxLength;

            Func<List<string>, List<string>> validNames = x => x.Where(n => isValid(n)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, validNames(names)));
        }
    }
}
