using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputEquation = Console.ReadLine().Split(" ").ToArray();

            Stack<string> equationStack = new Stack<string>();

            for (int i = 0; i < inputEquation.Length; i++)
            {
                equationStack.Push(inputEquation[i]);

                if (equationStack.Count == 3)
                {
                    int firstNumber = int.Parse(equationStack.Pop());
                    char equationSign = char.Parse(equationStack.Pop());
                    int secondNumber = int.Parse(equationStack.Pop());

                    int result = 0;

                    if (equationSign == 43)
                    {
                        result = firstNumber + secondNumber;
                    }
                    else if (equationSign == 45)
                    {
                        result = secondNumber - firstNumber;
                    }

                    equationStack.Push(result.ToString());
                }
            }

            Console.WriteLine(equationStack.Pop());
        }
    }
}
