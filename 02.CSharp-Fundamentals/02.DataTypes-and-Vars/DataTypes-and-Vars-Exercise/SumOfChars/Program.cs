using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < loops; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                sum += Convert.ToInt32(letter);
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
