using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int emptyWidth = int.Parse(Console.ReadLine());
            int emptyLength = int.Parse(Console.ReadLine());
            int emptyHeight = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int totalEmptySpace = emptyWidth * emptyLength * emptyHeight;

            do
            {
                int boxes = int.Parse(input);
                totalEmptySpace -= boxes;

                if (totalEmptySpace <= 0)
                {
                    break;
                }

                input = Console.ReadLine();

            } while (input != "Done");

            if (input == "Done")
            {
                Console.WriteLine($"{totalEmptySpace} Cubic meters left.");
            }

            if (totalEmptySpace <= 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(totalEmptySpace)} Cubic meters more.");
            }
        }
    }
}
