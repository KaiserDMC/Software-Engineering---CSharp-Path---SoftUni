using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> numberList = new List<int>();

            int counter = 0;
            List<int> indices = new List<int>();
            for (int i = 0; i < input.Count; i++)
            {
                char toTrim = '|';
                if (input[i].Contains(toTrim))
                {
                    input[i].Trim(toTrim);
                    indices.Add(input.IndexOf(input[i]));
                }

                bool isNumber = int.TryParse(input[i].Trim(toTrim), out int result);

                if (isNumber)
                {
                    numberList.Add(result);
                    counter++;
                }
            }

            indices.Insert(0, 0);

            IEnumerable<int> fullEnumerable = new int[numberList.Count];
            fullEnumerable = numberList;


            List<IEnumerable<int>> listOfLists = new List<IEnumerable<int>>();
            int[] range = new int[indices.Count];

            for (int m = 0; m < indices.Count; m++)
            {
                range[m] = indices[m];
            }

            for (int j = indices.Count - 1; j >= 0; j--)
            {
                if (range[j] != 0)
                {
                    listOfLists.Add(fullEnumerable.Skip(range[j]));
                }
                else
                {
                    listOfLists.Add(fullEnumerable.SkipLast(range[range.Length - 1] - 1));
                }

            }
            
            List<int> finalList = new List<int>();
            for (int k = 0; k < listOfLists.Count; k++)
            {
                listOfLists[k].Take(indices[k]);
                foreach (var VARIABLE in listOfLists[k])
                {
                    finalList.Add(VARIABLE);
                }
            }

            Console.WriteLine(string.Join(" ", finalList));
        }

    }
}
