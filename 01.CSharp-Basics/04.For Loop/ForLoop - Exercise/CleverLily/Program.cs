using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            int priceSingleToy = int.Parse(Console.ReadLine());

            double receivedMoney = 0;
            int numberOfToys = 0;
            double sum = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    receivedMoney += 10;
                    sum += receivedMoney;
                    sum -= 1;
                }
                else
                {
                    numberOfToys++;
                }
            }

            double moneyFromToys = priceSingleToy * numberOfToys;
            double totalMoney = sum + moneyFromToys;

            double difference = totalMoney - priceWashingMachine;
            if (difference >= 0)
            {
                Console.WriteLine($"Yes! {difference:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(difference):f2}");
            }
        }
    }
}
