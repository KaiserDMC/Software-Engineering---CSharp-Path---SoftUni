using System;
using System.Collections.Generic;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            char[] individuaChars = inputString.ToCharArray();
            List<char> encryptedChars = new List<char>();

            for (int i = 0; i < individuaChars.Length; i++)
            {
                int newChar = 0;
                newChar = (int)individuaChars[i] + 3;

                encryptedChars.Add((char)newChar);
            }

            Console.WriteLine(string.Join("", encryptedChars));
        }
    }
}
