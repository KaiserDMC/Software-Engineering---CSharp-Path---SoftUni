using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                Console.WriteLine(input);

            } while (true);
        }
    }
}