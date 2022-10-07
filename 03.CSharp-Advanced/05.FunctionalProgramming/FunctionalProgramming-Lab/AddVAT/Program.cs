using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> toDouble = n => double.Parse(n);
            Func<double, string> addVAT = vat => $"{(vat * 1.2):f2}";

            string[] originalPrices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(toDouble)
                .Select(addVAT)
                .ToArray();

            Action<string[]> toPrintAction = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            toPrintAction(originalPrices);
        }
    }
}
