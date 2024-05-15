using System;
using System.Linq;
using CommonClasses;

namespace GenericSwapMethodStrings
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

            int[] indicesToSwap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            box.Swap(indicesToSwap[0], indicesToSwap[1]);

            Console.WriteLine(box.ToString());
        }
    }
}