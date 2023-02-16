using System;
using System.IO;

namespace WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stageOfTournament = Console.ReadLine();
            string typeOfTicket = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            char pictureTaken = char.Parse(Console.ReadLine());

            double totalPrice = 0;
            int priceOfPicture = 40;

            switch (stageOfTournament)
            {
                case "Quarter final":

                    if (typeOfTicket == "Standard")
                    {
                        totalPrice = ticketCount * 55.5;
                    }
                    else if (typeOfTicket == "Premium")
                    {
                        totalPrice = ticketCount * 105.2;
                    }
                    else
                    {
                        totalPrice = ticketCount * 118.9;
                    }

                    break;
                case "Semi final":

                    if (typeOfTicket == "Standard")
                    {
                        totalPrice = ticketCount * 75.88;
                    }
                    else if (typeOfTicket == "Premium")
                    {
                        totalPrice = ticketCount * 125.22;
                    }
                    else
                    {
                        totalPrice = ticketCount * 300.40;
                    }

                    break;
                case "Final":

                    if (typeOfTicket == "Standard")
                    {
                        totalPrice = ticketCount * 110.10;
                    }
                    else if (typeOfTicket == "Premium")
                    {
                        totalPrice = ticketCount * 160.66;
                    }
                    else
                    {
                        totalPrice = ticketCount * 400;
                    }

                    break;
            }

            if (totalPrice >= 2500 && totalPrice <= 4000)
            {
                totalPrice = totalPrice - totalPrice * 0.1;
            }

            if (totalPrice > 4000)
            {
                totalPrice = totalPrice - totalPrice * 0.25;
                pictureTaken = 'N';
                // priceOfPicture = 0;
            }

            if (pictureTaken == 'Y')
            {
                totalPrice = totalPrice + priceOfPicture * ticketCount;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
