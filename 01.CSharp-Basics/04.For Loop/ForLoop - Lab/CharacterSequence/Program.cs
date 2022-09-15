using System;

namespace CharacterSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char singleLetter = text[i];
                Console.WriteLine(singleLetter);
            }
        }
    }
}
