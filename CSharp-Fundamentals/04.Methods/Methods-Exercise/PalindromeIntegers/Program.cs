using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            while (inputString != "END")
            {
                bool palindrome = PalindromeCheck(inputString);

                if (palindrome)
                {
                    Console.WriteLine($"true");
                }
                else
                {
                    Console.WriteLine($"false");
                }

                inputString = Console.ReadLine();
            }
        }

        static bool PalindromeCheck(string inputString)
        {
            bool palindrome = false;
            char[] separateIntegers = inputString.ToCharArray();
            Array.Reverse(separateIntegers);
            string reverseString = new String(separateIntegers);

            int firstNumber = int.Parse(inputString);
            int secondNumber = int.Parse(reverseString);

            if (firstNumber == secondNumber)
            {
                palindrome = true;
            }

            return palindrome;
        }
    }
}
