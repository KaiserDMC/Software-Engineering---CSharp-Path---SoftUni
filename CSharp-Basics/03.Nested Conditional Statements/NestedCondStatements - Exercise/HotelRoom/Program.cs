using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    if (days > 7 && days <= 14)
                    {
                        studioPrice = studioPrice - (studioPrice * 0.05);
                    }
                    else if (days > 14)
                    {
                        studioPrice = studioPrice - (studioPrice * 0.3);
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.1);
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartmentPrice = 68.7;
                    if (days > 14)
                    {
                        studioPrice = studioPrice - (studioPrice * 0.2);
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.1);
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    if (days > 14)
                    {
                        apartmentPrice = apartmentPrice - (apartmentPrice * 0.1);
                    }
                    break;
            }

            double totalStudioPrice = studioPrice * days;
            double totalApartmentPrice = apartmentPrice * days;

            Console.WriteLine($"Apartment: {totalApartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");
        }
    }
}
