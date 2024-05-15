using System;

namespace ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            const int endLoop = 3;
            char[] letters = new char[endLoop];

            for (int i = 0; i < endLoop; i++)
            {
                letters[i] = char.Parse(Console.ReadLine());
            }

            for (int j = endLoop - 1; j >= 0; j--)
            {
                Console.Write($"{letters[j]} ");
            }
        }
    }
}
