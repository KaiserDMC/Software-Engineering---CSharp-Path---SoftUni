using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());


            double sumOfPeople = 0;
            int musalaCount = 0;
            int monblanCount = 0;
            int kilimandjaroCount = 0;
            int k2Count = 0;
            int everestCount = 0;

            for (int i = 0; i < numberOfGroups; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());
                sumOfPeople += numberOfPeople;

                if (numberOfPeople <= 5)
                {
                    musalaCount += numberOfPeople;
                }
                else if (numberOfPeople > 5 && numberOfPeople <= 12)
                {
                    monblanCount += numberOfPeople;
                }
                else if (numberOfPeople > 12 && numberOfPeople <= 25)
                {
                    kilimandjaroCount += numberOfPeople;
                }
                else if (numberOfPeople > 25 && numberOfPeople <= 40)
                {
                    k2Count += numberOfPeople;
                }
                else
                {
                    everestCount += numberOfPeople;
                }
            }

            double averageMusala = (musalaCount / sumOfPeople) * 100;
            double averageMonblan = (monblanCount / sumOfPeople) * 100;
            double averageKilimandjaro = (kilimandjaroCount / sumOfPeople) * 100;
            double averageK2 = (k2Count / sumOfPeople) * 100;
            double averageEverest = (everestCount / sumOfPeople) * 100;

            Console.WriteLine($"{averageMusala:f2}%");
            Console.WriteLine($"{averageMonblan:f2}%");
            Console.WriteLine($"{averageKilimandjaro:f2}%");
            Console.WriteLine($"{averageK2:f2}%");
            Console.WriteLine($"{averageEverest:f2}%");
        }
    }
}
