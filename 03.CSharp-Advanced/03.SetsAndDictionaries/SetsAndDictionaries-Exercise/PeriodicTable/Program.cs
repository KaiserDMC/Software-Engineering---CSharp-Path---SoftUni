using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicTable = new SortedSet<string>();

            int countInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countInputs; i++)
            {
                string[] currentLine = Console.ReadLine().Split(" ").ToArray();

                for (int j = 0; j < currentLine.Length; j++)
                {
                    periodicTable.Add(currentLine[j]);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
