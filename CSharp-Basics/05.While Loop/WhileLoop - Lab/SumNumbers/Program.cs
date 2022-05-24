using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            do
            {
                int numberToSum = int.Parse(Console.ReadLine());
                sum += numberToSum;

            } while (sum < startNumber);

            Console.WriteLine(sum);
        }
    }
}
