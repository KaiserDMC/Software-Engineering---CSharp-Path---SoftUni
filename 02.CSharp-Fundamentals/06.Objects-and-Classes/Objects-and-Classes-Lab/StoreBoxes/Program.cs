using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            List<Box> boxesList = new List<Box>();

            while (inputCommand != "end")
            {
                string[] splitInputCommand = inputCommand.Split(" ").ToArray();

                Box box = new Box();
                box.SerialNumber = splitInputCommand[0];
                box.Item.Name = splitInputCommand[1];
                box.ItemQuantity = int.Parse(splitInputCommand[2]);
                box.Item.Price = double.Parse(splitInputCommand[3]);

                box.PriceForBox = box.ItemQuantity * box.Item.Price;

                boxesList.Add(box);

                inputCommand = Console.ReadLine();
            }

            List<Box> sortedBoxesList = boxesList.OrderByDescending(box => box.PriceForBox).ToList();

            foreach (Box box in sortedBoxesList)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
    }
}
