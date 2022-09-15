using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;

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
                    if (number > maxNumber)
                    {
                        maxNumber = number;
                    }
                }

            } while (true);

            Console.WriteLine(maxNumber);
        }
    }
}
