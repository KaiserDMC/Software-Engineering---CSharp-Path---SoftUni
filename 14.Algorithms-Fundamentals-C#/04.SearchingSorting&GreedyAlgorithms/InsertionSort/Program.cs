using System;
using System.Linq;

namespace InsertionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            InsertionSort(array);
            Console.WriteLine(string.Join(" ", array));
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                
                while (j > 0 && array[j - 1] > array[j])
                {
                    Swap(array, j - 1, j);
                    j--;
                }
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