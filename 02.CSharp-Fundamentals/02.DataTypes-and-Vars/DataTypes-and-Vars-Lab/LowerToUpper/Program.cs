using System;

namespace LowerToUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            if (char.IsLower(input))
            {
                Console.WriteLine($"lower-case");
            }
            else
            {
                Console.WriteLine($"upper-case");
            }
        }
    }
}
