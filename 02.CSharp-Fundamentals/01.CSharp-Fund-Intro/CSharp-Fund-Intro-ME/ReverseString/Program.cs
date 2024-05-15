using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] inputToChar = input.ToCharArray();
            Array.Reverse(inputToChar);

            Console.WriteLine(inputToChar);
        }
    }
}
