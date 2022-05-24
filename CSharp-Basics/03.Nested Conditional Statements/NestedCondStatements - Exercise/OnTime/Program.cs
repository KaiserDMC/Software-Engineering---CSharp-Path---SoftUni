using System;

namespace OnTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            examMinutes = examMinutes + (examHour * 60);
            arrivalMinutes = arrivalMinutes + (arrivalHour * 60);

            string examStatus = string.Empty;
            int difference = 0;
            int diffHour = 0;
            int diffMin = 0;

            if (examMinutes < arrivalMinutes)
            {
                examStatus = "Late";
            }
            else if (examMinutes - arrivalMinutes <= 30)
            {
                examStatus = "On time";
            }
            else if (examMinutes - arrivalMinutes > 30)
            {
                examStatus = "Early";
            }

            Console.WriteLine(examStatus);

            difference = Math.Abs(arrivalMinutes - examMinutes);
            diffHour = difference / 60;
            diffMin = difference % 60;

            if (examStatus == "Late" && diffHour >= 1)
            {
                if (diffMin < 10)
                {
                    Console.WriteLine($"{diffHour}:0{diffMin} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{diffHour}:{diffMin} hours after the start");
                }
            }
            else if (examStatus == "Late")
            {
                Console.WriteLine($"{diffMin} minutes after the start");
            }
            else if (examStatus == "On time" && examMinutes != arrivalMinutes)
            {
                Console.WriteLine($"{diffMin} minutes before the start");
            }
            else if (examStatus == "Early")
            {
                if (diffHour >= 1)
                {
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes before the start");
                }
            }
        }
    }
}
