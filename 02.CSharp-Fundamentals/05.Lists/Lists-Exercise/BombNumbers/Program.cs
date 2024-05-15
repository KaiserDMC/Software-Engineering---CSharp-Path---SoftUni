using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int[] bombNumberSequence = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int numberToNuke = bombNumberSequence[0];
            int nukingPower = bombNumberSequence[1];

            for (int i = 0; i < numberList.Count; i++)
            {
                List<int> numbersToDelete = new List<int>();

                numbersToDelete.AddRange(numberList.FindAll(item => item == numberToNuke));

                for (int j = 0; j < numbersToDelete.Count; j++)
                {
                    int bombIndex = numberList.IndexOf(numbersToDelete[j]);

                    if (bombIndex < 0)
                    {
                        break;
                    }

                    numberList.RemoveAt(bombIndex);

                    for (int k = 0; k < nukingPower; k++)
                    {
                        if (bombIndex < numberList.Count)
                        {
                            numberList.RemoveAt(bombIndex);
                        }
                    }

                    for (int m = 0; m < nukingPower; m++)
                    {
                        if (bombIndex - 1 - m >= 0 && bombIndex - 1 - m < numberList.Count)
                        {
                            numberList.RemoveAt(bombIndex - 1 - m);
                        }


                    }
                }
            }

            int finalSum = numberList.Sum();

            Console.WriteLine(finalSum);
        }
    }
}

