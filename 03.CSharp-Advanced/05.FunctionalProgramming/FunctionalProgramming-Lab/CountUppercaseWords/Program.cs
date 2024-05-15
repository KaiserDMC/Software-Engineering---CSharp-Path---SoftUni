using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperWords = w => char.IsUpper(w, 0);

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperWords)
                .ToArray();

            Action<string[]> toPrintAction = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            toPrintAction(words);
        }
    }
}
