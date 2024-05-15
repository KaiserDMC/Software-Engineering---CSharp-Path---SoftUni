using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("John", 22);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}