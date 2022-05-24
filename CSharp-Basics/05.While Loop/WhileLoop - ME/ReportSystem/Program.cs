using System;

namespace ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int profitRequired = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double totalMoneyCash = 0;
            double totalMoneyCard = 0;
            double totalCollected = 0;
            bool complete = false;
            int i = 0;
            int cash = 0;
            int card = 0;

            do
            {
                int transactionMoney = int.Parse(input);
                i++;

                if (i % 2 == 0)
                {
                    if (transactionMoney < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        totalMoneyCard += transactionMoney;
                        Console.WriteLine("Product sold!");
                        card++;
                    }
                }
                else
                {
                    if (transactionMoney > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        totalMoneyCash += transactionMoney;
                        Console.WriteLine("Product sold!");
                        cash++;
                    }
                }

                totalCollected = totalMoneyCash + totalMoneyCard;

                if (totalCollected >= profitRequired)
                {
                    complete = true;
                    break;
                }

                input = Console.ReadLine();

            } while (input != "End");

            if (complete)
            {
                Console.WriteLine($"Average CS: {(totalMoneyCash / cash):f2}");
                Console.WriteLine($"Average CC: {(totalMoneyCard / card):f2}");
            }

            if (input == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }

        }
    }
}
