using System;

namespace EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountEggsPlayerOne = int.Parse(Console.ReadLine());
            int amountEggsPlayerTwo = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                string eggResult = input;

                if (eggResult == "one")
                {
                    amountEggsPlayerTwo -= 1;
                }
                else if (eggResult == "two")
                {
                    amountEggsPlayerOne -= 1;
                }

                if (amountEggsPlayerOne == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {amountEggsPlayerTwo} eggs left.");
                    break;
                }
                
                if (amountEggsPlayerTwo == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {amountEggsPlayerOne} eggs left.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {amountEggsPlayerOne} eggs left.");
                Console.WriteLine($"Player two has {amountEggsPlayerTwo} eggs left.");
            }
        }
    }
}
