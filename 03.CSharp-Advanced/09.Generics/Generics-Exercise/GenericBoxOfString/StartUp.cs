using System;
using CommonClasses;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> boxOfStrings = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();

                boxOfStrings.Items.Add(s);
            }

            Console.WriteLine(boxOfStrings.ToString());
        }
    }
}