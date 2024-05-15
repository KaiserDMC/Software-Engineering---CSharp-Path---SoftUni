using System;
using System.Collections.Generic;

namespace RecursiveFibonacci
{
    public class Program
    {
        public static Dictionary<int, int> LookupTable = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(x));
        }

        private static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            
            if (LookupTable.ContainsKey(n))
            {
                return LookupTable[n];
            }

            int currentCalculation = Fibonacci(n - 1) + Fibonacci(n - 2);
            LookupTable.Add(n, currentCalculation);

            return currentCalculation;
        }
    }
}