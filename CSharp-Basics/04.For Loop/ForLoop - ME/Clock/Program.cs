using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;

            do
            {
                Console.WriteLine($"{hours} : {minutes}");
                minutes++;
                if (minutes > 59)
                {
                    hours++;
                    minutes = 0;
                }

            } while (hours <= 23);
        }
    }
}
