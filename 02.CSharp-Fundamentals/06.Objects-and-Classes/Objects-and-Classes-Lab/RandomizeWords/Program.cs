using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputString = Console.ReadLine().Split(" ").ToList();

            Random random = new Random();

            for (int i = 0; i < inputString.Count; i++)
            {
                int randomIndex = random.Next(0, inputString.Count);

                string tempString = inputString[i];
                inputString[i] = inputString[randomIndex];
                inputString[randomIndex] = tempString;
            }

            foreach (string word in inputString)
            {
                Console.WriteLine(word);
            }
        }
    }
}
