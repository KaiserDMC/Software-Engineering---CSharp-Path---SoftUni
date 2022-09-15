using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double chineseUan = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()); // 1-5..... 0.01-0.05

            double bitcoinToLev = bitcoin * 1168;
            double chineseUanToUSD = chineseUan * 0.15;

            double usdToLev = chineseUanToUSD * 1.76;

            double allLev = bitcoinToLev + usdToLev;
            double levToEuro = allLev / 1.95;

            //double result = levToEuro - (levToEuro * (percentage / 100));
            double result = levToEuro;
            result -= levToEuro * percentage / 100;

            Console.WriteLine($"{result:f2}");
        }
    }
}
