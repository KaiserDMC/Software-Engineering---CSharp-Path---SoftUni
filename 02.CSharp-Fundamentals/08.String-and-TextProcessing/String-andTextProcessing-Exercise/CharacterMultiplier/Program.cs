using System;
using System.Linq;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine().Split(" ").ToArray();

            string firstString = inputString[0];
            string secondString = inputString[1];

            int sumOfChars = CharMultiplication(firstString, secondString);

            Console.WriteLine($"{sumOfChars}");
        }

        static int CharMultiplication(string firstString, string secondString)
        {
            int charSum = 0;

            int indexForLoop = Math.Min(firstString.Length, secondString.Length);
            bool firstStringBigger = (firstString.Length > secondString.Length) ? true : false;

            for (int i = 0; i < indexForLoop; i++)
            {
                charSum += firstString[i] * secondString[i];
            }

            if (firstStringBigger)
            {
                for (int i = indexForLoop; i < firstString.Length; i++)
                {
                    charSum += firstString[i];
                }
            }
            else
            {
                for (int i = indexForLoop; i < secondString.Length; i++)
                {
                    charSum += secondString[i];
                }
            }

            return charSum;
        }
    }
}
