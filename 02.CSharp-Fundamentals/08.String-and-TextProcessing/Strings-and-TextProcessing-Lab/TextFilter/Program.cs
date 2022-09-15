using System;
using System.Linq;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ").ToArray();

            string text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                if (text.Contains(bannedWord))
                {
                    string asterix = new string('*', bannedWord.Length);
                    text = text.Replace(bannedWord, asterix);
                }
            }

            Console.WriteLine(text);
        }
    }
}
