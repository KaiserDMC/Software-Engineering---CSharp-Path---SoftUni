using System;
using System.Collections;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string paranthesis = Console.ReadLine();

            Stack<char> paranthesisStack = new Stack<char>();
            bool balanced = false;

            if (paranthesis.Length % 2 != 0)
            {
                balanced = false;
            }
            else
            {
                for (int i = 0; i < paranthesis.Length; i++)
                {
                    if (paranthesis[i] == 40 || paranthesis[i] == 91 || paranthesis[i] == 123)
                    {
                        paranthesisStack.Push(paranthesis[i]);
                    }

                    if (paranthesis[i] == 41 || paranthesis[i] == 93 || paranthesis[i] == 125)
                    {
                        char currentOpenBracket = paranthesisStack.Pop();
                        int temp = paranthesis[i] == 41 ? 1 : 2;

                        if (currentOpenBracket == (char)paranthesis[i] - temp)
                        {
                            balanced = true;
                        }
                        else
                        {
                            balanced = false;
                            break;
                        }
                    }
                }
            }


            if (balanced)
            {
                Console.WriteLine($"YES");
            }
            else
            {
                Console.WriteLine($"NO");
            }
        }
    }
}
