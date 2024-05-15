using System;
using CommonClasses;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string s = Console.ReadLine();

                box.Items.Add(s);
            }

            string compareToString = Console.ReadLine();

            int counter = box.Count(compareToString);

            Console.WriteLine(counter);
        }
    }
}