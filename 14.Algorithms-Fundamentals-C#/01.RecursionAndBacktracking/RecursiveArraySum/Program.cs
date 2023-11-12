using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Console.WriteLine(SumArray(array, 0));
        }

        private static int SumArray(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            return array[index] + SumArray(array, index + 1);
        }
    }
}