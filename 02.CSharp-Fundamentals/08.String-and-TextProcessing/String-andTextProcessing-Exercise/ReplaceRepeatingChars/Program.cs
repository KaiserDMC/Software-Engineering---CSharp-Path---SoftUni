using System;
using System.Linq;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            char[] individualChars = inputString.ToCharArray();
            char prevCharacter = '@';
            string outputString = String.Empty;

            foreach (char indChar in individualChars)
            {
                if (indChar != prevCharacter)
                {
                    outputString += indChar;
                }

                prevCharacter = indChar;
            }

            Console.WriteLine(outputString);
        }
    }
}
