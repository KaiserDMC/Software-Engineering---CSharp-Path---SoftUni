using System;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberCharacters = int.Parse(Console.ReadLine());

            char[] decryptedChars = new char[numberCharacters];

            for (int i = 0; i < numberCharacters; i++)
            {
                char receivedChar = char.Parse(Console.ReadLine());


                decryptedChars[i] = receivedChar;
                decryptedChars[i] = (char)(receivedChar + key);
            }

            string decryptedMessage = String.Join("", decryptedChars);
            Console.WriteLine($"{decryptedMessage}");
        }
    }
}
