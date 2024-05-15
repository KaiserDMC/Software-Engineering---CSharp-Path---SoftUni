using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string dateStart = Console.ReadLine();
            string dateEnd = Console.ReadLine();

            DateModifier date = new DateModifier()
            {
                DateStart = dateStart,
                DateEnd = dateEnd
            };

            TimeSpan difference = date.DateDifference(dateStart, dateEnd);

            Console.WriteLine(Math.Abs(difference.Days));
        }
    }
}