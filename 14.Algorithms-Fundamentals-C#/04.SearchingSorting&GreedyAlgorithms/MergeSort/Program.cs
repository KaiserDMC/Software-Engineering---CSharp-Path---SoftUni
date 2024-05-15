using System;
using System.Linq;

namespace MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            Console.WriteLine(string.Join(" ", MergeSort(array)));
        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            var left = array.Take(array.Length / 2).ToArray();
            var right = array.Skip(array.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIndex = 0;
            var leftIndex = 0;
            var rightdIndex = 0;

            while (leftIndex < left.Length && rightdIndex < right.Length)
            {
                if (left[leftIndex] < right[rightdIndex])
                {
                    merged[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergedIndex++] = right[rightdIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergedIndex++] = left[i];
            }

            for (int i = rightdIndex; i < right.Length; i++)
            {
                merged[mergedIndex++] = right[i];
            }

            return merged;
        }
    }
}