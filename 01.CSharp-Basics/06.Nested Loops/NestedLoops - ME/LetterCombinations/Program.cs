using System;

namespace LetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char lastLetter = char.Parse(Console.ReadLine());
            char skipLetter = char.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = firstLetter; i <= lastLetter; i++)
            {
                if (i != skipLetter)
                {
                    for (int j = firstLetter; j <= lastLetter; j++)
                    {
                        if (j != skipLetter)
                        {
                            for (int k = firstLetter; k <= lastLetter; k++)
                            {
                                if (k != skipLetter)
                                {
                                    counter++;
                                    Console.Write($"{(char)i}{(char)j}{(char)k} ");
                                }
                            }
                        }
                    }
                }
            }

            Console.Write($"{counter}");
        }
    }
}
