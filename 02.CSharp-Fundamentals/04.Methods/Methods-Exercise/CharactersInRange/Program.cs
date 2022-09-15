using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            string result = PrintCharacters(firstChar, secondChar);

            Console.WriteLine(result);
        }

        static string PrintCharacters(char firstChar, char secondChar)
        {
            int rangeStart = (int)firstChar;
            int rangeEnd = (int)secondChar;
            string charString = string.Empty;

            if (rangeStart > rangeEnd)
            {
                rangeStart = (int)secondChar;
                rangeEnd = (int)firstChar;
            }

            for (int i = rangeStart + 1; i < rangeEnd; i++)
            {
                charString += (char)i + " ";
            }

            return charString;
        }
    }
}
