using System;
using System.Runtime.Intrinsics.X86;

namespace ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            decimal sum = 0m;

            while (true)
            {
                if (inputString == "special" || inputString == "regular")
                {
                    break;
                }

                decimal componentPrice = decimal.Parse(inputString);

                if (componentPrice <= 0)
                {
                    Console.WriteLine($"Invalid price!");
                }
                else
                {
                    sum += componentPrice;
                }

                inputString = Console.ReadLine();
            }

            decimal sumWithTaxes = sum * 1.2m;
            decimal finalPrice = 0m;
            bool anyPrice = true;

            if (inputString == "special")
            {
                finalPrice = sumWithTaxes * 0.9m;
            }
            else if (inputString == "regular")
            {
                finalPrice = sumWithTaxes;
            }

            if (finalPrice == 0)
            {
                Console.WriteLine($"Invalid order!");
                anyPrice = false;
            }

            if (anyPrice)
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {(sumWithTaxes - sum):f2}$");
                Console.WriteLine($"-----------");
                Console.WriteLine($"Total price: {finalPrice:f2}$");
            }
        }
    }
}
