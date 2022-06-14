using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int foldArrayK = inputArray.Length / 4;
            int[] topArray = new int[inputArray.Length / 2];
            int[] bottomArray = new int[inputArray.Length / 2];


            for (int i = 0; i < foldArrayK; i++)
            {

                topArray[i] = inputArray[foldArrayK - 1 - i];
            }

            int counter2 = 0;
            for (int j = (inputArray.Length - 1) - foldArrayK; j >= foldArrayK; j--)
            {
                bottomArray[counter2] = inputArray[j];
                counter2++;
            }
            Array.Reverse((bottomArray));



            for (int k = foldArrayK; k < topArray.Length; k++)
            {
                topArray[k] = inputArray[topArray.Length + k];
            }

            int temp = 0;
            for (int m = 0; m < topArray.Length; m++)
            {
                if (m == foldArrayK)
                {
                    temp = topArray[foldArrayK];
                    topArray[foldArrayK] = topArray[foldArrayK + 1];
                    topArray[foldArrayK + 1] = temp;
                }

            }
            //for (int m = topArray.Length - 1; m >= foldArrayK; m--)
            //{
            //    temp = topArray[m];
            //    topArray[m-1] = temp;
            //}

            int[] sum = new int[topArray.Length];

            for (int index = 0; index < topArray.Length; index++)
            {
                sum[index] = topArray[index] + bottomArray[index];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
