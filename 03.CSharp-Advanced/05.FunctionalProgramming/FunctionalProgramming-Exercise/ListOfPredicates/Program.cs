using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);

            int maxRange = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine()
                .Split(" ")
                .Select(parser)
                .ToList();

            List<int> actualNumbers = new List<int>();

            int divisor = 0;

            Predicate<int> isDivisible = x => x % divisor == 0;

            for (int i = 1; i <= maxRange; i++)
            {
                bool isValid = true;
                for (int j = 0; j < divisors.Count; j++)
                {
                    divisor = divisors[j];

                    if (!isDivisible(i))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    actualNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", actualNumbers));
        }
    }
}
