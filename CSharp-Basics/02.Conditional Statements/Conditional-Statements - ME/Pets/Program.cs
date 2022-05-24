using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysAway = int.Parse(Console.ReadLine());
            int foodLeftInKg = int.Parse(Console.ReadLine());
            double foodDayDog = double.Parse(Console.ReadLine());
            double foodDayCat = double.Parse(Console.ReadLine());
            double foodDayTortoise = double.Parse(Console.ReadLine());

            double dogFood = daysAway * foodDayDog;
            double catFood = daysAway * foodDayCat;
            double tortoiseFood = daysAway * foodDayTortoise / 1000;
            double totalPetFood = dogFood + catFood + tortoiseFood;

            double difference = totalPetFood - foodLeftInKg;

            if (difference > 0)
            {
                Console.WriteLine($"{Math.Ceiling(difference)} more kilos of food are needed.");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(Math.Abs(difference))} kilos of food left.");
            }

        }
    }
}
