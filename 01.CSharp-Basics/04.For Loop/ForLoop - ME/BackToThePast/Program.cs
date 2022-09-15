using System;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritance = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            int n = year - 1800;
            int age = 18;
            double moneySpent = 0;

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    moneySpent += 12000;
                    age++;
                }
                else
                {
                    moneySpent += 12000 + 50 * (age);
                    age++;
                }
            }

            double moneyLeft = inheritance - moneySpent;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(moneyLeft):f2} dollars to survive.");
            }
        }
    }
}
