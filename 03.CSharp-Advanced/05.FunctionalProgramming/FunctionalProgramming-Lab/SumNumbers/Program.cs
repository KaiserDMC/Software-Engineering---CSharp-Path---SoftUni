using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            Func<List<int>, int> counter = x => x.Count;
            Func<List<int>, int> sum = x => x.Sum();

            List<int> numbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToList();

            Print(numbers, counter);
            Print(numbers, sum);
        }

        public static void Print(List<int> nums, Func<List<int>, int> action)
        {
            int result = action(nums);

            Console.WriteLine(result);
        }
    }
}
