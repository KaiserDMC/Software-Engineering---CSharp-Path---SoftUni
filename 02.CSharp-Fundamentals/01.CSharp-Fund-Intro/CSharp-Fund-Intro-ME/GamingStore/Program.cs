using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialBalance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            double totalSpend = 0;
            bool zeroBalance = false;
            bool isAvailable = true;
            double balance = initialBalance;

            while (input != "Game Time")
            {
                string game = input;
                double gameCost = 0;


                switch (game)
                {
                    case "OutFall 4":
                        gameCost = 39.99;
                        break;
                    case "CS: OG":
                        gameCost = 15.99;
                        break;
                    case "Zplinter Zell":
                        gameCost = 19.99;
                        break;
                    case "Honored 2":
                        gameCost = 59.99;
                        break;
                    case "RoverWatch":
                        gameCost = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gameCost = 39.99;
                        break;
                    default:
                        Console.WriteLine($"Not Found");
                        isAvailable = false;
                        break;
                }

                if (isAvailable)
                {
                    if (balance >= gameCost)
                    {
                        balance -= gameCost;
                        totalSpend += gameCost;
                        Console.WriteLine($"Bought {game}");
                    }
                    else
                    {
                        Console.WriteLine($"Too Expensive");
                    }
                }

                input = Console.ReadLine();
                isAvailable = true;

                if (balance == 0)
                {
                    Console.WriteLine($"Out of money!");
                    zeroBalance = true;
                    break;
                }                              
            }

            if (!zeroBalance)
            {
                Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${(initialBalance - totalSpend):f2}");
            }
        }
    }
}
