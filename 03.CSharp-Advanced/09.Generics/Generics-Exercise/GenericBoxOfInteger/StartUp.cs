using System;
using CommonClasses;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> boxOfIntegers = new Box<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                boxOfIntegers.Items.Add(number);
            }

            Console.WriteLine(boxOfIntegers.ToString());
        }
    }
}