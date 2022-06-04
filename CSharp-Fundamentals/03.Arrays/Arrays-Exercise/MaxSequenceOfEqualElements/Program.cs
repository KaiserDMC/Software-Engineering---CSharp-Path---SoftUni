using System;
using System.Linq;
using System.Collections.Generic;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isSequence = false;
            int sequenceCount = 1;
            int saveCount = 0;
            int maxValue = 0;
            int countStart = 0;

            for (int j = 1; j < numbers.Length; j++)
            {
                int previousNumber = numbers[j - 1];
                int currNumber = numbers[j];

                if (currNumber == previousNumber)
                {
                    isSequence = true;
                    sequenceCount++;
                }
                else
                {
                    isSequence = false;
                }

                if (isSequence)
                {
                    if (sequenceCount > maxValue)
                    {
                        maxValue = sequenceCount;
                        saveCount = countStart;
                    }
                }

                if (!isSequence)
                {
                    sequenceCount = 1;
                    countStart = j;
                }
            }

            for (int k = saveCount; k < maxValue + saveCount; k++)
            {
                Console.Write($"{numbers[k]} ");
            }
        }
    }
}
