using System;
using System.Linq;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(" ").ToArray();

            //foreach (string inputString in inputStrings)
            //{
            //    for (int i = 0; i < inputString.Length; i++)
            //    {
            //        Console.Write(inputString);
            //    }
            //}

            StringBuilder outputString = new StringBuilder();
            foreach (string inputString in inputStrings)
            {
                for (int i = 0; i < inputString.Length; i++)
                {
                    outputString.Append(inputString);
                    Console.Write(inputString);
                }
            }
        }
    }
}
