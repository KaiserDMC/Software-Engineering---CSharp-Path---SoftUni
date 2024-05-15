using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonCollection personCollection = new PersonCollection();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                if (IsIDUsed(input[1], personCollection.Persons))
                {
                    Person person = personCollection.Persons.Find(p => p.ID == input[1]);
                    person.Name = input[0];
                    person.Age = int.Parse(input[2]);
                }
                else
                {
                    Person person = new Person
                    {
                        Name = input[0],
                        ID = input[1],
                        Age = int.Parse(input[2])
                    };

                    personCollection.Persons.Add(person);
                }
            }

            List<Person> orderedPersons = personCollection.Persons.OrderBy(p => p.Age).ToList();

            foreach (Person person in orderedPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        static bool IsIDUsed(string ID, List<Person> persons)
        {
            bool isIDPresent = false;

            foreach (Person person in persons)
            {
                if (string.Equals(person.ID, ID))
                {
                    isIDPresent = true;
                }
            }

            return isIDPresent;
        }

        class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }

        class PersonCollection
        {
            public PersonCollection()
            {
                this.Persons = new List<Person>();
            }

            public List<Person> Persons { get; set; }
        }
    }
}
