using System;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            while (true)
            {
                string[] operationStrings = Console.ReadLine().Split("|").ToArray();

                if (operationStrings[0] == "Decode")
                {
                    break;
                }

                string operationName = operationStrings[0];

                switch (operationName)
                {
                    case "Move":
                        int numberOfChars = int.Parse(operationStrings[1]);

                        encryptedMessage = MoveChars(encryptedMessage, numberOfChars);
                        break;
                    case "ChangeAll":
                        char substringToReplace = char.Parse(operationStrings[1]);
                        char replacementString = char.Parse(operationStrings[2]);

                        encryptedMessage = ReplaceChars(encryptedMessage, substringToReplace, replacementString);
                        break;
                    case "Insert":
                        int indexNewChar = int.Parse(operationStrings[1]);
                        string stringToInsert = operationStrings[2];

                        encryptedMessage = InsertChar(encryptedMessage, indexNewChar, stringToInsert);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        static string MoveChars(string encrypted, int numberOfChars)
        {
            string afterMove = String.Empty;

            for (int i = 0; i < numberOfChars; i++)
            {
                afterMove += encrypted[i];
            }

            encrypted = encrypted.Remove(0, numberOfChars);

            encrypted += afterMove;

            return encrypted;
        }

        static string InsertChar(string encrypted, int indexNewChar, string stringToInsert)
        {
            encrypted = encrypted.Insert(indexNewChar, stringToInsert);

            return encrypted;
        }

        static string ReplaceChars(string encrypted, char substringToReplace, char replacementString)
        {
            encrypted = encrypted.Replace(substringToReplace, replacementString);

            return encrypted;
        }
    }
}
