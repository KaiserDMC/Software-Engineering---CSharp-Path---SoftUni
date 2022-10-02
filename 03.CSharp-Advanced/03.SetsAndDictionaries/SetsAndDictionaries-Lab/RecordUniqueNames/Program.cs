using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string name = Console.ReadLine();

                uniqueNames.Add(name);
            }

            //Test comment for colour check

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }

    class MyClass
    {
        
    }
}
