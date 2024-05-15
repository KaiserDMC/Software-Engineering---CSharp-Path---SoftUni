using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            while (true)
            {
                string[] commandInputStrings = Console.ReadLine().Split(":|:").ToArray();

                if (commandInputStrings[0] == "Reveal")
                {
                    break;
                }

                string commandName = commandInputStrings[0];

                switch (commandName)
                {
                    case "InsertSpace":
                        int index = int.Parse(commandInputStrings[1]);

                        concealedMessage = concealedMessage.Insert(index, " ");

                        Console.WriteLine(concealedMessage);

                        break;
                    case "Reverse":
                        string substringToCheck = commandInputStrings[1];
                        bool isPresent = IsSubstringPresent(concealedMessage, substringToCheck);

                        if (isPresent)
                        {
                            concealedMessage = ReverseString(concealedMessage, substringToCheck);
                            Console.WriteLine(concealedMessage);
                        }
                        else
                        {
                            Console.WriteLine($"error");
                        }

                        break;
                    case "ChangeAll":
                        substringToCheck = commandInputStrings[1];
                        string replacement = commandInputStrings[2];

                        isPresent = IsSubstringPresent(concealedMessage, substringToCheck);

                        if (isPresent)
                        {
                            concealedMessage = ReplacementString(concealedMessage, substringToCheck, replacement);
                        }

                        Console.WriteLine(concealedMessage);

                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }

        static bool IsSubstringPresent(string concealedMessage, string substring)
        {
            bool isPresent = false;

            if (concealedMessage.Contains(substring))
            {
                isPresent = true;
            }

            return isPresent;
        }

        static string ReverseString(string concealedMessage, string substring)
        {
            string reversedSubstring = string.Empty;

            int startIndex = concealedMessage.IndexOf(substring);
            int endIndex = substring.Length;

            reversedSubstring = concealedMessage.Substring(startIndex, endIndex);
            concealedMessage = concealedMessage.Remove(startIndex, endIndex);

            char[] charArray = reversedSubstring.ToCharArray();

            Array.Reverse(charArray);

            reversedSubstring = string.Join("", charArray);

            concealedMessage = concealedMessage + reversedSubstring;

            return concealedMessage;
        }

        static string ReplacementString(string concealedMessage, string substring, string replacement)
        {
            concealedMessage = concealedMessage.Replace(substring, replacement);

            return concealedMessage;
        }
    }
}
