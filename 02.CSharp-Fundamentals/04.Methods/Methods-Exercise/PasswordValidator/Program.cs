using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            int digitCheck = DigitCheck(inputString);
            bool lengthCheck = LengthCheck(inputString);
            string letterDigitCheck = LetterDigitCheck(inputString);

            switch (letterDigitCheck)
            {
                case "valid":
                    if (lengthCheck && digitCheck >= 2)
                    {
                        Console.WriteLine($"Password is valid");
                    }
                    else if (!lengthCheck && digitCheck >= 2)
                    {
                        Console.WriteLine($"Password must be between 6 and 10 characters");
                    }
                    else if (!lengthCheck && digitCheck < 2)
                    {
                        Console.WriteLine($"Password must be between 6 and 10 characters");
                        Console.WriteLine($"Password must have at least 2 digits");
                    }
                    else if (lengthCheck && digitCheck < 2)
                    {
                        Console.WriteLine($"Password must have at least 2 digits");
                    }
                    break;
                case "not valid":
                    if (lengthCheck && digitCheck >= 2)
                    {
                        Console.WriteLine($"Password must consist only of letters and digits");
                    }
                    else if (!lengthCheck && digitCheck >= 2)
                    {
                        Console.WriteLine($"Password must be between 6 and 10 characters");
                        Console.WriteLine($"Password must consist only of letters and digits");
                    }
                    else if (!lengthCheck && digitCheck < 2)
                    {
                        Console.WriteLine($"Password must be between 6 and 10 characters");
                        Console.WriteLine($"Password must consist only of letters and digits");
                        Console.WriteLine($"Password must have at least 2 digits");
                    }
                    else if (lengthCheck && digitCheck < 2)
                    {
                        Console.WriteLine($"Password must consist only of letters and digits");
                        Console.WriteLine($"Password must have at least 2 digits");
                    }
                    break;
            }
        }

        static int DigitCheck(string inputString)
        {
            int digits = 0;
            char[] separateLetters = new char[inputString.Length];

            for (int i = 0; i < separateLetters.Length; i++)
            {
                separateLetters[i] = inputString[i];

                if (char.IsDigit(separateLetters[i]))
                {
                    digits++;
                }
            }

            return digits;
        }


        static bool LengthCheck(string inputString)
        {
            bool properLength = false;

            if (inputString.Length >= 6 && inputString.Length <= 10)
            {
                properLength = true;
            }

            return properLength;
        }

        static string LetterDigitCheck(string inputString)
        {
            string letterDigitCheck = string.Empty;
            int count = 0;
            char[] separateLetters = new char[inputString.Length];

            for (int i = 0; i < separateLetters.Length; i++)
            {
                separateLetters[i] = inputString[i];

                if (char.IsDigit(separateLetters[i]) || char.IsLetter(separateLetters[i]))
                {
                    count++;
                }
            }

            if (count == inputString.Length)
            {
                letterDigitCheck = "valid";
            }
            else
            {
                letterDigitCheck = "not valid";
            }

            return letterDigitCheck;
        }
    }
}
