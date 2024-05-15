using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            switch (groupType)
            {
                case "Students":
                    if (dayOfWeek == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 9.80;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        price = 10.46;
                    }

                    totalPrice = price * people;

                    if (people >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                    break;
                case "Business":
                    if (dayOfWeek == "Friday")
                    {
                        price = 10.90;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 15.60;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        price = 16;
                    }

                    totalPrice = price * people;

                    if (people >= 100)
                    {
                        totalPrice -= price * 10;
                    }
                    break;
                case "Regular":
                    if (dayOfWeek == "Friday")
                    {
                        price = 15;
                    }
                    else if (dayOfWeek == "Saturday")
                    {
                        price = 20;
                    }
                    else if (dayOfWeek == "Sunday")
                    {
                        price = 22.50;
                    }

                    totalPrice = price * people;

                    if (people >= 10 && people <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                    break;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
