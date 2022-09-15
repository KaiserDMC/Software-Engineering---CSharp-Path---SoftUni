using System;

namespace ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            const int endLoop = 3;
            string[] input = new string[endLoop];

            for (int i = 0; i < endLoop; i++)
            {
                input[i] = Console.ReadLine();
            }

            string output = string.Concat(input[0], input[2], input[1]);
            Console.WriteLine(output);
        }
    }
}
