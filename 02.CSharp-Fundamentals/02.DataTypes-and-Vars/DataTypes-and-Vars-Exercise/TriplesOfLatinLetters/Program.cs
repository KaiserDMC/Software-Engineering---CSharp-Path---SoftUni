using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());


            for (int i = 0; i < loop; i++)
            {
                for (int j = 0; j < loop; j++)
                {
                    for (int k = 0; k < loop; k++)
                    {
                        char firstChar = (char)('a' + i);
                        char secondChar = (char)('a' + j);
                        char thirdChar = (char)('a' + k);

                        Console.WriteLine($"{(char)(firstChar)}{(char)(secondChar)}{(char)(thirdChar)}");
                    }
                }
            }
        }
    }
}
