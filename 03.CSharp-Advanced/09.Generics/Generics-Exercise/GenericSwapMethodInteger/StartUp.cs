using System;
using System.Linq;
using CommonClasses;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                box.Items.Add(currNumber);
            }

            int[] indicesToSwap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            box.Swap(indicesToSwap[0], indicesToSwap[1]);

            Console.WriteLine(box.ToString());
        }
    }
}