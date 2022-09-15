using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            float availableMoney = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float priceLightsaber = float.Parse(Console.ReadLine());
            float priceRobe = float.Parse(Console.ReadLine());
            float priceBelt = float.Parse(Console.ReadLine());

            float freeBelt = (students / 6) * priceBelt;
            float totalCost = (float)Math.Ceiling(students * 1.1) * priceLightsaber + students * priceBelt + students * priceRobe - freeBelt;

            if (availableMoney >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {Math.Abs(totalCost - availableMoney):f2}lv more.");
            }

        }
    }
}
