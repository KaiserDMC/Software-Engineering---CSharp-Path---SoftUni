using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberLine = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            for (int i = 0; i < numberLine.Count - 1; i++)
            {
                numberLine[i] += numberLine[numberLine.Count - 1];
                numberLine.RemoveAt(numberLine.Count - 1);
            }

            Console.WriteLine(string.Join(" ", numberLine));
        }
    }
}
