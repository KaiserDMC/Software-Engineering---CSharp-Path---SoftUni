using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            int availableSeats;

            int takenSeatsCounter = 0;
            int studentCounter = 0;
            int standardCounter = 0;
            int kidCounter = 0;
            bool getOut = false;
            int ticketsSold = 0;

            while (inputName != "Finish")
            {
                availableSeats = int.Parse(Console.ReadLine());
                string movieName = inputName;

                for (int i = 1; i <= availableSeats; i++)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "student")
                    {
                        takenSeatsCounter++;
                        studentCounter++;
                    }
                    else if (ticketType == "standard")
                    {
                        takenSeatsCounter++;
                        standardCounter++;
                    }
                    else if (ticketType == "kid")
                    {
                        takenSeatsCounter++;
                        kidCounter++;
                    }
                    else if (ticketType == "End")
                    {
                        break;
                    }

                    if (ticketType == "Finish")
                    {
                        getOut = true;
                        break;
                    }
                }

                double percentageFull = (double)takenSeatsCounter / availableSeats * 100.00;
                ticketsSold += takenSeatsCounter;

                Console.WriteLine($"{movieName} - {percentageFull:f2}% full.");

                if (getOut)
                {
                    break;
                }

                inputName = Console.ReadLine();
                takenSeatsCounter = 0;
            }

            double percentageStudent = (double)studentCounter / ticketsSold * 100.00;
            double percentageStandard = (double)standardCounter / ticketsSold * 100.00;
            double percentageKid = (double)kidCounter / ticketsSold * 100.00;

            if (getOut || inputName == "Finish")
            {
                Console.WriteLine($"Total tickets: {ticketsSold}");
                Console.WriteLine($"{percentageStudent:f2}% student tickets.");
                Console.WriteLine($"{percentageStandard:f2}% standard tickets.");
                Console.WriteLine($"{percentageKid:f2}% kids tickets.");
            }
        }
    }
}
