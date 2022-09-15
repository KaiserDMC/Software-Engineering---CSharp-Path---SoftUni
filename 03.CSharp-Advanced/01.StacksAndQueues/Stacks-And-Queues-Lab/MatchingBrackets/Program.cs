using System;
using System.Collections;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputEquation = Console.ReadLine();

            Stack<int> bracketIndices = new Stack<int>();

            for (int i = 0; i < inputEquation.Length; i++)
            {
                if (inputEquation[i] == 40)
                {
                    bracketIndices.Push(i);
                }

                if (inputEquation[i] == 41)
                {
                    int startIndex = bracketIndices.Pop();

                    string printEquation = inputEquation.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(printEquation);
                }
            }
        }
    }
}
