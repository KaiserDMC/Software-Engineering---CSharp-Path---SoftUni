using System;
using System.Linq;
using System.Collections.Generic;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthDNA = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] DNA = new int[lengthDNA];
            int bestSequenceIndex = 0;
            int bestSequenceSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;

            int sample = 0;
            while (input != "Clone them!")
            {
                sample++;
                int[] bestSequenceDNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDNASum = 0;
                bool isCurrDNABetter = false;

                int count = 0;
                for (int i = 0; i < bestSequenceDNA.Length; i++)
                {
                    if (bestSequenceDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }

                currStartIndex = currEndIndex - currCount + 1;
                currDNASum = bestSequenceDNA.Sum();

                if (currCount > dnaCount)
                {
                    isCurrDNABetter = true;
                }
                else if (currCount == dnaCount)
                {
                    if (currStartIndex < dnaStartIndex)
                    {
                        isCurrDNABetter = true;
                    }
                    else if (currStartIndex == dnaStartIndex)
                    {
                        if (currDNASum > bestSequenceSum)
                        {
                            isCurrDNABetter = true;
                        }
                    }
                }

                if (isCurrDNABetter)
                {
                    DNA = bestSequenceDNA;
                    dnaCount = currCount;
                    dnaStartIndex = currStartIndex;
                    bestSequenceSum = currDNASum;
                    bestSequenceIndex = sample;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
