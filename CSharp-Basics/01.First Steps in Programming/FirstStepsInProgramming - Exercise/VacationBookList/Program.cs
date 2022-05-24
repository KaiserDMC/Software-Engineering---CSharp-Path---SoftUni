using System;

namespace VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            int bookPages = int.Parse(Console.ReadLine());
            int pagesReadPerHour = int.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            int totalTimeToReadBook = bookPages / pagesReadPerHour;
            int neededHoursPerDay = totalTimeToReadBook / numberOfDays;

            Console.WriteLine(neededHoursPerDay);
        }
    }
}
