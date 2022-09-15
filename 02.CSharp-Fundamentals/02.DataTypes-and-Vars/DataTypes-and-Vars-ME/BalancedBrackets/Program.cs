using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            bool balanced = true;
            bool openBracket = false;
            char brackets;

            for (int i = 0; i < input; i++)
            {
                string receivedString = Console.ReadLine();
                _ = char.TryParse(receivedString, out brackets);

                if (brackets == (char)40)
                {
                    if (!openBracket)
                    {
                        openBracket = true;
                    }
                    else
                    {
                        balanced = false;
                    }
                }
                else if (brackets == (char)41)
                {
                    if (openBracket)
                    {
                        openBracket = false;
                    }
                    else
                    {
                        balanced = false;
                    }

                }
            }

            if (openBracket)
            {
                balanced = false;
            }

            if (!balanced)
            {
                Console.WriteLine($"UNBALANCED");
            }
            else
            {
                Console.WriteLine($"BALANCED");
            }
        }
    }
}
