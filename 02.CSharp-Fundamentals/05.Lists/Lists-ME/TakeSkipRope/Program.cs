using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            List<int> numbersList = new List<int>();
            List<string> stringList = new List<string>();

            for (int i = 0; i < inputString.Length; i++)
            {
                char individualChar = inputString[i];

                if (char.IsDigit(individualChar))
                {
                    numbersList.Add(int.Parse(individualChar.ToString()));
                }
                else
                {
                    stringList.Add(individualChar.ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int j = 0; j < numbersList.Count; j++)
            {
                if (j % 2 == 0)
                {
                    takeList.Add(numbersList[j]);
                }
                else
                {
                    skipList.Add(numbersList[j]);
                }
            }

            int indexToSkip = 0;
            StringBuilder decryptedString = new StringBuilder();

            for (int k = 0; k < takeList.Count; k++)
            {
                List<string> tempList = new List<string>(stringList);

                tempList = tempList.Skip(indexToSkip).Take(takeList[k]).ToList();
                decryptedString.Append(string.Join("", tempList));
                indexToSkip += takeList[k] + skipList[k];
            }

            Console.WriteLine(decryptedString.ToString());
        }
    }
}
