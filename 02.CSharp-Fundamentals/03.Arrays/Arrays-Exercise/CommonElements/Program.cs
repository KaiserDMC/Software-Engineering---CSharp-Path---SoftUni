using System;
using System.Linq;
using System.Collections.Generic;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');

            string[] arrayCommon = new string[arrayOne.Length];
            bool exists = false;

            for (int i = 0; i < arrayTwo.Length; i++)
            {
                exists = arrayOne.Contains(arrayTwo[i]);

                if (exists)
                {
                    arrayCommon[i] = arrayTwo[i];
                }
            }

            var temp = new List<string>();
            foreach (string element in arrayCommon)
            {
                if (!string.IsNullOrEmpty(element))
                {
                    temp.Add(element);
                }
            }

            arrayCommon = temp.ToArray();

            for (int j = 0; j < arrayCommon.Length; j++)
            {
                Console.Write($"{arrayCommon[j]} ");
            }
        }
    }
}
