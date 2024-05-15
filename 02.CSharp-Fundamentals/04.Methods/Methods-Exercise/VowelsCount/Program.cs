using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            int result = CountVowels(inputString);
            Console.WriteLine(result);
        }

        static int CountVowels(string inputString)
        {
            char[] separateLetters = new char[inputString.Length];

            for (int i = 0; i < separateLetters.Length; i++)
            {
                separateLetters[i] = inputString[i];
            }

            int vowelCount = 0;

            for (int i = 0; i < separateLetters.Length; i++)
            {
                if (separateLetters[i] == (char)65 || separateLetters[i] == (char)97)
                {
                    vowelCount++;
                }
                else if (separateLetters[i] == (char)69 || separateLetters[i] == (char)101)
                {
                    vowelCount++;
                }
                else if (separateLetters[i] == (char)73 || separateLetters[i] == (char)105)
                {
                    vowelCount++;
                }
                else if (separateLetters[i] == (char)79 || separateLetters[i] == (char)111)
                {
                    vowelCount++;
                }
                else if (separateLetters[i] == (char)85 || separateLetters[i] == (char)117)
                {
                    vowelCount++;
                }
                else if (separateLetters[i] == (char)89 || separateLetters[i] == (char)121)
                {
                    vowelCount++;
                }
            }

            return vowelCount;
        }
    }
}
