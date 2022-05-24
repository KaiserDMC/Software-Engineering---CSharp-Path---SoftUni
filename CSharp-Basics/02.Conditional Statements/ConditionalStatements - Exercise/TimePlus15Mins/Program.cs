using System;

namespace TimePlus15Mins
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int timeInMinutes = minutes + hours * 60;
            timeInMinutes = timeInMinutes + 15;

            hours = timeInMinutes / 60;
            minutes = timeInMinutes % 60;

            if (hours >= 24)
            {
                hours = hours - 24;
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }

        }
    }
}
