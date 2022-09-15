using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int overtimeWorkers = int.Parse(Console.ReadLine());

            double actualDays = days - (days * 0.1);
            double regularHours = actualDays * 8;
            double overtimeHours = 2 * overtimeWorkers * days;

            double totalHours = regularHours + overtimeHours;
            double difference = Math.Floor(totalHours) - hours;

            if(difference>=0)
            {
                Console.WriteLine($"Yes!{difference} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Abs(difference)} hours needed.");
            }

        }
    }
}
