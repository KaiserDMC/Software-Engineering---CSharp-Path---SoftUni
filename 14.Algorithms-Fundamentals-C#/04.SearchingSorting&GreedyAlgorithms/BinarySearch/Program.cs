using System;
using System.Linq;

namespace BinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).OrderBy(x => x).ToArray();
            int x = int.Parse(Console.ReadLine());


            int resultIndex = BinarySearch(array, x, 0, array.Length - 1);
            Console.WriteLine(resultIndex);
        }
        
        private static int BinarySearch(int[] orderedArray, int findX, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middleIndex = (start + end) / 2;

            if (orderedArray[middleIndex] == findX)
            {
                return middleIndex;
            }

            if (orderedArray[middleIndex] > findX)
            {
                return BinarySearch(orderedArray, findX, start, middleIndex - 1);
            }

            return BinarySearch(orderedArray, findX, middleIndex + 1, end);
        }
    }
}