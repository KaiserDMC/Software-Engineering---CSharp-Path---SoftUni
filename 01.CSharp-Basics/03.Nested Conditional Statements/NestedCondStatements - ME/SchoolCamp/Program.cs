using System;

namespace SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string vacationType = Console.ReadLine();
            int numberStudents = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            double pricePerNight = 0;
            string sportType = string.Empty;

            switch (season)
            {
                case "Winter":
                    if (vacationType == "boys" || vacationType == "girls")
                    {
                        pricePerNight = 9.60;
                    }
                    else
                    {
                        pricePerNight = 10;
                    }

                    if (vacationType == "girls")
                    {
                        sportType = "Gymnastics";
                    }
                    else if (vacationType == "boys")
                    {
                        sportType = "Judo";
                    }
                    else
                    {
                        sportType = "Ski";
                    }
                    break;
                case "Spring":
                    if (vacationType == "boys" || vacationType == "girls")
                    {
                        pricePerNight = 7.20;
                    }
                    else
                    {
                        pricePerNight = 9.5;
                    }

                    if (vacationType == "girls")
                    {
                        sportType = "Athletics";
                    }
                    else if (vacationType == "boys")
                    {
                        sportType = "Tennis";
                    }
                    else
                    {
                        sportType = "Cycling";
                    }
                    break;
                case "Summer":
                    if (vacationType == "boys" || vacationType == "girls")
                    {
                        pricePerNight = 15;
                    }
                    else
                    {
                        pricePerNight = 20;
                    }

                    if (vacationType == "girls")
                    {
                        sportType = "Volleyball";
                    }
                    else if (vacationType == "boys")
                    {
                        sportType = "Football";
                    }
                    else
                    {
                        sportType = "Swimming";
                    }
                    break;
            }

            double cost = numberStudents * pricePerNight * nights;

            if (numberStudents >= 10 && numberStudents < 20)
            {
                cost -= cost * 0.05;
            }
            else if (numberStudents >= 20 && numberStudents < 50)
            {
                cost -= cost * 0.15;
            }
            else if (numberStudents >= 50)
            {
                cost -= cost * 0.5;
            }

            Console.WriteLine($"{sportType} {cost:f2} lv.");
        }
    }
}
