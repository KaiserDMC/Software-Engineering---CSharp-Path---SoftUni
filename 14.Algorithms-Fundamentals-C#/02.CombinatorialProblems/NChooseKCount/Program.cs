using System;

namespace NChooseKCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(BinomialCoefficients(n, k));
        }

        private static int BinomialCoefficients(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return BinomialCoefficients(row - 1, col - 1) + BinomialCoefficients(row - 1, col);
        }
    }
}