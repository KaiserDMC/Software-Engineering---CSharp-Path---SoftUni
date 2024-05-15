using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            char[] output = new char[counter];

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                int digits = int.Parse(input);

                int length = digits.ToString().Length;
                int mainNumber = digits % 10;

                int offset = (mainNumber - 2) * 3;

                if (mainNumber == 8 || mainNumber == 9)
                {
                    offset += 1;
                }

                int letterIndex = offset + length - 1;

                int letter = letterIndex + 97;

                //Addition of 'Space'
                if (digits == 0)
                {
                    letter = 32;
                }

                char letterToChar = (char)letter;

                output[i] = letterToChar;

            }

            Console.Write(output);
        }
    }
}
