using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int totalCakePieces = cakeWidth * cakeLength;
            string input = Console.ReadLine();

            do
            {
                int takenPieces = int.Parse(input);
                totalCakePieces -= takenPieces;

                if (totalCakePieces <= 0)
                {
                    break;
                }

                input = Console.ReadLine();

            } while (input != "STOP");

            if (input == "STOP")
            {
                Console.WriteLine($"{totalCakePieces} pieces are left.");
            }

            if (totalCakePieces <= 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalCakePieces)} pieces more.");
            }
        }
    }
}
