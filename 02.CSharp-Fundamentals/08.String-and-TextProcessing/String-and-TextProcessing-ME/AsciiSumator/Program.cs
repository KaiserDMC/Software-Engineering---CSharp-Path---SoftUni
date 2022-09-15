using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string randomString = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < randomString.Length; i++)
            {
                if (randomString[i] > firstChar && randomString[i] < secondChar)
                {
                    sum += randomString[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
