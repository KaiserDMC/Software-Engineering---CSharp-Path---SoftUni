using System;
using System.Collections.Generic;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            List<char> result = PrintChars(inputString);

            Console.WriteLine(result.ToArray());
        }

        static List<char> PrintChars(string inputString)
        {
            List<char> separateChars = new List<char>();
            bool isEven = false;

            if (inputString.Length % 2 == 0)
            {
                isEven = true;
            }

            int middle = inputString.Length / 2;

            if (!isEven)
            {
                separateChars.Add(inputString[middle]);
            }
            else
            {
                separateChars.Add(inputString[middle - 1]);
                separateChars.Add(inputString[middle]);
            }

            return separateChars;
        }
    }
}
