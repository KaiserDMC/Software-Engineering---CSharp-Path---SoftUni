using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double chinaMoney = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double bitcoinToLev = bitcoins * 1168;
            double chinaMoneyToUSD = chinaMoney * 0.15;

            double USDToLev = chinaMoneyToUSD * 1.76;
            double levToEuro = (bitcoinToLev + USDToLev) / 1.95;

            double result = levToEuro - (levToEuro * (percentage / 100));

            Console.WriteLine($"{result:f2}");
        }
    }
}
