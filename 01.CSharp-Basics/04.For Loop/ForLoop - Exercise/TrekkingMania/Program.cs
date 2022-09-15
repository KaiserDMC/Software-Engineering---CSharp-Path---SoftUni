using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int climbersMusala = 0;
            int climbersMonblan = 0;
            int climbersKilimandjaro = 0;
            int climbersK2 = 0;
            int climbersEverest = 0;
            int totalPeople = 0;

            for (int i = 1; i <= numberOfGroups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());


                if (peopleInGroup <= 5)
                {
                    climbersMusala += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    climbersMonblan += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    climbersKilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    climbersK2 += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    climbersEverest += peopleInGroup;
                }

                totalPeople += peopleInGroup;
            }

            double percentMusala = (double)climbersMusala / totalPeople * 100.0;
            double percentMonblan = (double)climbersMonblan / totalPeople * 100.0;
            double percentKilimandjaro = (double)climbersKilimandjaro / totalPeople * 100.0;
            double percentK2 = (double)climbersK2 / totalPeople * 100.0;
            double percentEverest = (double)climbersEverest / totalPeople * 100.0;

            Console.WriteLine($"{percentMusala:f2}%");
            Console.WriteLine($"{percentMonblan:f2}%");
            Console.WriteLine($"{percentKilimandjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");
        }
    }
}
