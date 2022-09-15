using System;
using System.Collections.Generic;

namespace ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Stack<char> stringElements = new Stack<char>();

            for (int i = 0; i < inputString.Length; i++)
            {
                stringElements.Push(inputString[i]);
            }

            while (stringElements.Count > 0)
            {
                Console.Write(stringElements.Pop());
            }
        }
    }
}
