using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputUsernames = Console.ReadLine().Split(", ").ToArray();

            List<string> validUsernameList = new List<string>();

            foreach (string username in inputUsernames)
            {
                bool validUsernameLength = false;
                bool validUsernameCharacter = false;

                if (username.Length >= 3 && username.Length <= 16)
                {
                    validUsernameLength = true;
                }

                for (int i = 0; i < username.Length; i++)
                {
                    char currentChar = username[i];

                    if (char.IsLetterOrDigit(currentChar) || currentChar == 45 || currentChar == 95)
                    {
                        validUsernameCharacter = true;
                    }
                    else
                    {
                        validUsernameCharacter = false;
                        break;
                    }
                }

                if (validUsernameLength && validUsernameCharacter)
                {
                    validUsernameList.Add(username);
                }
            }

            foreach (string username in validUsernameList)
            {
                Console.WriteLine($"{username}");
            }
        }
    }
}
