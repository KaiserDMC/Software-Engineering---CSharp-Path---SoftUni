using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());

            double sumOfAllPeople = 0;
            int musalaPeople = 0;
            int montblandPeople = 0;
            int kilimanjaroPeople = 0;
            int ktwoPeople = 0;
            int everestPeople = 0;


            for (int i = 0; i < numberOfGroups; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());

                sumOfAllPeople += numberOfPeople;

                if (numberOfPeople <= 5)
                {
                    musalaPeople += numberOfPeople;
                }
                else if (numberOfPeople > 5 && numberOfPeople <= 12)
                {
                    montblandPeople += numberOfPeople;
                }
                else if (numberOfPeople > 12 && numberOfPeople <= 25)
                {
                    kilimanjaroPeople += numberOfPeople;
                }
                else if (numberOfPeople > 25 && numberOfPeople <= 40)
                {
                    ktwoPeople += numberOfPeople;
                }
                else
                {
                    everestPeople += numberOfPeople;
                }
            }

            double averagePeopleMusala = (musalaPeople / sumOfAllPeople) * 100;
            double averagePeopleMontbland = (montblandPeople / sumOfAllPeople) * 100;
            double averagePeopleKilimanjaro = (kilimanjaroPeople / sumOfAllPeople) * 100;
            double averagePeopleKTwo = (ktwoPeople / sumOfAllPeople) * 100;
            double averagePeopleEverest = (everestPeople / sumOfAllPeople) * 100;

            Console.WriteLine($"{averagePeopleMusala:f2}%");
            Console.WriteLine($"{averagePeopleMontbland:f2}%");
            Console.WriteLine($"{averagePeopleKilimanjaro:f2}%");
            Console.WriteLine($"{averagePeopleKTwo:f2}%");
            Console.WriteLine($"{averagePeopleEverest:f2}%");
        }
    }
}
