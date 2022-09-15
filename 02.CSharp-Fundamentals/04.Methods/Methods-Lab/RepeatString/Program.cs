using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RepeatString(Console.ReadLine(), int.Parse(Console.ReadLine())));
        }

        static string RepeatString(string input, int count)
        {
            string repeatedString = string.Empty;

            for (int i = 0; i < count; i++)
            {
                repeatedString += input;
            }

            return repeatedString;
        }
    }
}
