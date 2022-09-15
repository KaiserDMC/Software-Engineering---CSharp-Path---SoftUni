using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNumber = int.MaxValue;

            do
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }
                else
                {
                    int number = int.Parse(input);
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

            } while (true);

            Console.WriteLine(minNumber);
        }
    }
}
