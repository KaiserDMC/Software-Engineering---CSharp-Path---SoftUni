using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> printAction = x =>
            {
                foreach (var name in x)
                {
                    Console.Write($"Sir ");
                    Console.WriteLine(name);
                }
            };

            printAction(stringCollection);
        }
    }
}
