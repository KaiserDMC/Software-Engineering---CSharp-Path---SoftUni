using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersByCount = new Dictionary<int, int>();

            int countInputs = int.Parse(Console.ReadLine());
            int lastEven = 0;

            for (int i = 0; i < countInputs; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbersByCount.ContainsKey(currentNumber))
                {
                    numbersByCount.Add(currentNumber, 0);
                }

                numbersByCount[currentNumber]++;

                if (numbersByCount[currentNumber] % 2 == 0)
                {
                    lastEven = currentNumber;
                }
            }

            Console.WriteLine(lastEven);
        }
    }
}
