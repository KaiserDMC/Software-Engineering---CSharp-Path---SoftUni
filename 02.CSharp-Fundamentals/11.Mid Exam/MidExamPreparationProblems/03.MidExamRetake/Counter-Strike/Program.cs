using System;

namespace Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();
            int battleWonCounter = 0;

            while (inputString != "End of battle")
            {
                int distance = int.Parse(inputString);

                if (initialEnergy >= distance)
                {
                    initialEnergy -= distance;
                    battleWonCounter++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battleWonCounter} won battles and {initialEnergy} energy");
                    break;
                }

                if (battleWonCounter % 3 == 0)
                {
                    initialEnergy += battleWonCounter;
                }

                inputString = Console.ReadLine();
            }

            if (inputString == "End of battle")
            {
                Console.WriteLine($"Won battles: {battleWonCounter}. Energy left: {initialEnergy}");
            }
        }
    }
}