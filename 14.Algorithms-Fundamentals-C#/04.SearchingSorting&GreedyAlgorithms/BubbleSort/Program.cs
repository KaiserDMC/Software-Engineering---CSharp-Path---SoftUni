using System;
using System.Linq;

namespace BubbleSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            BubbleSort(array);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void BubbleSort(int[] array)
        {
            bool isSorted = false;
            int sortedCount = 0;
            
            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < array.Length - sortedCount; j++)
                {
                    int i = j - 1;
                    
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }
        }

        private static void Swap(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}