using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "end")
            {
                string[] command = input;

                switch (command[0])
                {
                    case "Delete":
                        List<int> indexToDelete = new List<int>();

                        indexToDelete.AddRange(integerList.FindAll(item => item == int.Parse(command[1])));

                        for (int i = 0; i < indexToDelete.Count; i++)
                        {
                            integerList.Remove(indexToDelete[i]);
                        }
                        break;
                    case "Insert":
                        int positionIndex = int.Parse(command[2]);
                        integerList.Insert(positionIndex, int.Parse(command[1]));
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ", integerList));
        }
    }
}
