using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string inputString = Console.ReadLine();
            int[] indices = new int[numberList.Count];
            List<char> outputString = new List<char>();

            for (int i = 0; i < numberList.Count; i++)
            {
                int digit = numberList[i];
                int loopStop = digit.ToString().Length;

                for (int j = 0; j < loopStop; j++)
                {
                    indices[i] += digit % 10;
                    digit /= 10;
                }
            }

            for (int k = 0; k < indices.Length; k++)
            {
                int elementIndex = indices[k];

                if (elementIndex >= 0 && elementIndex <= inputString.Length)
                {
                    outputString.Add(inputString[elementIndex]);
                    inputString = inputString.Remove(elementIndex, 1);
                }
                else
                {
                    elementIndex -= inputString.Length;
                    outputString.Add(inputString[elementIndex]);
                    inputString = inputString.Remove(elementIndex, 1);
                }

            }

            Console.WriteLine(string.Join("", outputString));
        }
    }
}
