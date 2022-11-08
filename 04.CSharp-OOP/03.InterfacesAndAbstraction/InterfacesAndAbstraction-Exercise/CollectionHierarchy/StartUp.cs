using System;
using System.Linq;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] inputs = Console.ReadLine().Split(" ").ToArray();
            int amountToRemove = int.Parse(Console.ReadLine());

            foreach (var input in inputs)
            {
                Console.Write($"{addCollection.Add(input)} ");   
            }

            Console.WriteLine();

            foreach (var input in inputs)
            {
                Console.Write($"{addRemoveCollection.Add(input)} ");
            }

            Console.WriteLine();

            foreach (var input in inputs)
            {
                Console.Write($"{myList.Add(input)} ");
            }

            Console.WriteLine();

            for (int i = 0; i < amountToRemove; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }

            Console.WriteLine();

            for (int i = 0; i < amountToRemove; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
        }
    }
}
