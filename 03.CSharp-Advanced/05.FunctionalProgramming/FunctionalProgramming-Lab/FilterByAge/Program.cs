using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonCollection personCollection = new PersonCollection();

            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(", ").ToArray();

                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);

                personCollection.Persons.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int threshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filterCondition = CreateFilter(condition, threshold);
            Action<Person> printAction = CreatePrinter(format);

            PersonCollection.PrintPeople(personCollection.Persons, filterCondition, printAction);
        }

        private static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return x => Console.WriteLine($"{x.Name} - {x.age}");
                case "name":
                    return x => Console.WriteLine($"{x.Name}");
                case "age":
                    return x => Console.WriteLine($"{x.age}");
                default:
                    return null;
            }
        }

        private static Func<Person, bool> CreateFilter(string condition, int threshold)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.age < threshold;
                case "older":
                    return x => x.age >= threshold;
                default:
                    return null;
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.age = age;
        }

        public string Name { get; set; }
        public int age { get; set; }
    }

    class PersonCollection
    {
        public PersonCollection()
        {
            Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public static void PrintPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (var currPerson in people)
            {
                bool condition = filter(currPerson);

                if (condition)
                {
                    printer(currPerson);
                }
            }
        }
    }
}
