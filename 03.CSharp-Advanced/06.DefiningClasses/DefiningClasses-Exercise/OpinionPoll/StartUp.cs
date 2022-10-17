using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < inputLines; i++)
            {
                Person currentPerson = new Person();

                string[] personData = Console.ReadLine().Split(" ").ToArray();

                currentPerson.Name = personData[0];
                currentPerson.Age = int.Parse(personData[1]);

                family.AddMember(currentPerson);
            }

            List<Person> toPrint = family.PeopleAboveThirty();

            foreach (var person in toPrint)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}