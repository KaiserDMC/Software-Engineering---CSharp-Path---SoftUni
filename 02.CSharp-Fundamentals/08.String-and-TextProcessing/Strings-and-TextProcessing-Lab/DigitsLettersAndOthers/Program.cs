using System;
using System.Text;

namespace DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder specials = new StringBuilder();

            for (int i = 0; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];

                if (char.IsDigit(currentChar))
                {
                    digits.Append(currentChar);
                }
                else if (char.IsLetter(currentChar))
                {
                    letters.Append(currentChar);
                }
                else
                {
                    specials.Append(currentChar);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(specials);
        }
    }
}
