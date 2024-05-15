using System;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string password = inputString;

            while (true)
            {
                string[] stringManipulation = Console.ReadLine().Split(" ").ToArray();

                if (stringManipulation[0] == "Done")
                {
                    break;
                }

                string commandName = stringManipulation[0];

                switch (commandName)
                {
                    case "TakeOdd":
                        password = OddPlaces(password);

                        break;
                    case "Cut":
                        int startIndex = int.Parse(stringManipulation[1]);
                        int length = int.Parse(stringManipulation[2]);

                        password = CutSubstring(password, startIndex, length);

                        break;
                    case "Substitute":
                        string subString = stringManipulation[1];
                        string substituteString = stringManipulation[2];

                        password = Substitute(password, subString, substituteString);

                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        static string OddPlaces(string inputString)
        {
            string outputString = String.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (i % 2 != 0)
                {
                    outputString += inputString[i];
                }
            }

            Console.WriteLine(outputString);

            return outputString;
        }

        static string CutSubstring(string inputString, int startIndex, int length)
        {
            inputString = inputString.Remove(startIndex, length);

            Console.WriteLine(inputString);

            return inputString;
        }

        static string Substitute(string inputString, string subString, string substituteString)
        {
            if (inputString.Contains(subString))
            {
                inputString = inputString.Replace(subString, substituteString);

                Console.WriteLine(inputString);
            }
            else
            {
                Console.WriteLine($"Nothing to replace!");
            }

            return inputString;
        }
    }
}
