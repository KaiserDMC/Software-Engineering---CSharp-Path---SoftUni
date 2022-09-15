using System;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            //Read sequence of strings from console. Amount of sequence will be given.
            int numberOfStrings = int.Parse(Console.ReadLine());
            string[] arrayStrings = new string[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                string stringToEncrypt = Console.ReadLine();
                arrayStrings[i] = stringToEncrypt;
            }

            //Each vowel to be multiplied by the string length
            //each consonant to be divided by the string length
            int[] numberSequence = new int[arrayStrings.Length];

            for (int j = 0; j < arrayStrings.Length; j++)
            {
                char[] separateLetters = arrayStrings[j].ToCharArray();

                for (int k = 0; k < separateLetters.Length; k++)
                {
                    if (separateLetters[k] == (char)65 || separateLetters[k] == (char)97 || separateLetters[k] == (char)69 || separateLetters[k] == (char)101 || separateLetters[k] == (char)73 || separateLetters[k] == (char)105 || separateLetters[k] == (char)79 || separateLetters[k] == (char)111 || separateLetters[k] == (char)85 || separateLetters[k] == (char)117)
                    {
                        numberSequence[j] += (int)(separateLetters[k] * separateLetters.Length);
                    }
                    else
                    {
                        numberSequence[j] += (int)(separateLetters[k] / separateLetters.Length);
                    }
                }
            }

            Array.Sort(numberSequence);

            foreach (int number in numberSequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
