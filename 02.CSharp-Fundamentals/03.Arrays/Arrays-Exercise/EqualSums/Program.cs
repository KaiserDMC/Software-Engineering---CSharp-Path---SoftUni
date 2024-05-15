using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumLeft = 0;
            int sumRight = 0;
            bool isSinlgeNumber = false;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray.Length == 1)
                {
                    Console.WriteLine(0);
                    isSinlgeNumber = true;
                    break;
                }

                sumLeft = 0;
                for (int leftSum = i; leftSum > 0; leftSum--)
                {
                    int leftElementsPosition = leftSum - 1;
                    if (leftSum > 0)
                    {
                        sumLeft += inputArray[leftElementsPosition];
                    }
                }

                sumRight = 0;
                for (int j = i; j < inputArray.Length; j++)
                {
                    int nextElementPosition = j + 1;
                    if (j < inputArray.Length - 1)
                    {
                        sumRight += inputArray[nextElementPosition];
                    }
                }

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            if (!isSinlgeNumber)
            {
                Console.WriteLine($"no");
            }
        }
    }
}
