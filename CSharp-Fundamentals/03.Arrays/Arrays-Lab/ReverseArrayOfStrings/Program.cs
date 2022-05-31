using System;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] separatedInput = input.Split(' ');

            for (int i = separatedInput.Length - 1; i >= 0; i--)
            {
                Console.Write($"{separatedInput[i]} ");
            }
        }
    }
}
