using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArraysV2
{
    class Program
    {
        static void Main(string[] args)
        {
           List<string> numbersAsStrings = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<int> numbers = new List<int>();

            foreach (var number in numbersAsStrings)
            {
                numbers.AddRange(number.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList()
                );
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
