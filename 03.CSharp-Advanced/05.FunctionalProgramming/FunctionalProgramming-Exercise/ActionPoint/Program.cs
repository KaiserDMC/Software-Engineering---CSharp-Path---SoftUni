using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> printAction = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            printAction(stringCollection);
        }
    }
}
