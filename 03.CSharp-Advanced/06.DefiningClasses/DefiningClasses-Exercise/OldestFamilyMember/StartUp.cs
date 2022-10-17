using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputMembers = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < inputMembers; i++)
            {
                Person currentMember = new Person();

                string[] memberData = Console.ReadLine().Split(" ").ToArray();

                currentMember.Name = memberData[0];
                currentMember.Age = int.Parse(memberData[1]);

                family.AddMember(currentMember);
            }

            Person eldestPerson = family.GetOldestMember();

            Console.WriteLine($"{eldestPerson.Name} {eldestPerson.Age}");
        }
    }
}