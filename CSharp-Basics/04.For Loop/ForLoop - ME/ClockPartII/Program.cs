using System;

namespace ClockPartII
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            do
            {
                Console.WriteLine($"{hours} : {minutes} : {seconds}");
                seconds++;
                if (seconds > 59)
                {
                    minutes++;
                    seconds = 0;
                }

                if (minutes > 59)
                {
                    hours++;
                    minutes = 0;
                }

            } while (hours <= 23);
        }
    }
}
