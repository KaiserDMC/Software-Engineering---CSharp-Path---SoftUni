using System;

namespace StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string secretMessage = string.Empty;
            string secretMessageTemp = string.Empty;
            bool presentN = false;
            bool presentC = false;
            bool presentO = false;

            do
            {
                char letter = char.Parse(input);

                if ((letter >= 'a' && letter <= 'z') || (letter >= 'A' && letter <= 'Z'))
                {

                    if (letter == 'n' && !presentN)
                    {
                        presentN = true;
                    }
                    else if (letter == 'c' && !presentC)
                    {
                        presentC = true;
                    }
                    else if (letter == 'o' && !presentO)
                    {
                        presentO = true;
                    }
                    else
                    {
                        secretMessageTemp += letter;
                    }
                }

                if (presentN && presentC && presentO)
                {
                    secretMessage += secretMessageTemp + " ";
                    secretMessageTemp = "";
                    presentN = false;
                    presentC = false;
                    presentO = false;
                }

                input = Console.ReadLine();

            } while (input != "End");

            Console.WriteLine(secretMessage);
        }
    }
}
