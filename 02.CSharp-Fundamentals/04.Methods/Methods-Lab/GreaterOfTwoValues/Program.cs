using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeValue = Console.ReadLine();

            switch (typeValue)
            {
                case "int":
                    int numberOne = int.Parse(Console.ReadLine());
                    int numberTwo = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(numberOne, numberTwo));
                    break;
                case "char":
                    char charOne = char.Parse(Console.ReadLine());
                    char charTwo = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(charOne, charTwo));
                    break;
                case "string":
                    string stringOne = Console.ReadLine();
                    string stringTwo = Console.ReadLine();
                    Console.WriteLine(GetMax(stringOne, stringTwo));
                    break;
            }
        }

        static int GetMax(int numberOne, int numberTwo)
        {
            int result = Math.Max(numberOne, numberTwo);

            return result;
        }

        static char GetMax(char charOne, char charTwo)
        {
            if (charOne > charTwo)
            {
                return charOne;
            }

            return charTwo;
        }

        static string GetMax(string stringOne, string stringTwo)
        {
            int result = stringOne.CompareTo(stringTwo);

            if (result > 0)
            {
                return stringOne;
            }

            return stringTwo;
        }
    }
}
