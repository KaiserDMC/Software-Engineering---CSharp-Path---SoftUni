using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededVacationMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int counterSpend = 0;
            int counterDays = 0;

            do
            {
                string option = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                counterDays++;

                if (option == "spend")
                {
                    counterSpend++;
                    availableMoney -= money;

                    if (availableMoney < 0)
                    {
                        availableMoney = 0;
                    }
                }
                else if (option == "save")
                {
                    availableMoney += money;
                    counterSpend = 0;
                }

            } while (availableMoney < neededVacationMoney && counterSpend < 5);

            if (counterSpend == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{counterDays}");
            }

            if (availableMoney >= neededVacationMoney)
            {
                Console.WriteLine($"You saved the money for {counterDays} days.");
            }
        }
    }
}
