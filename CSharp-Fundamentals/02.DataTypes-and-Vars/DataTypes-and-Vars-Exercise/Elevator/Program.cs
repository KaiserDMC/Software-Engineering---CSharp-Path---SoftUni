using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int elevatorCourses = numberOfPeople / elevatorCapacity;

            if (numberOfPeople % elevatorCapacity != 0)
            {
                elevatorCourses += 1;
            }

            Console.WriteLine(elevatorCourses);
        }
    }
}
