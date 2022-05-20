using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numbers = new string(input.ToCharArray());
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = (numbers[i]) - 48;

                int result = 1;
                for (int j = number; j > 0; j--)
                {
                    result *= j;
                }

                sum += result;
            }

            if (sum == int.Parse(input))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
