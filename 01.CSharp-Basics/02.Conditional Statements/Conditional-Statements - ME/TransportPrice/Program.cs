using System;

namespace TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double taxiCostDay = 0.7 + (0.79 * kilometers);
            double taxiCostNight = 0.7 + (0.90 * kilometers);
            double busCost = 0.09 * kilometers;
            double trainCost = 0.06 * kilometers;

            double cheapestTransport = 0;

            if (timeOfDay == "day" || timeOfDay == "night")
            {
                if (kilometers < 20)
                {
                    if (timeOfDay == "day")
                    {
                        cheapestTransport = taxiCostDay;
                    }
                    else
                    {
                        cheapestTransport = taxiCostNight;
                    }
                }
                else if (kilometers >= 20 && kilometers < 100)
                {
                    cheapestTransport = busCost;
                }
                else if (kilometers >= 100)
                {
                    cheapestTransport = trainCost;
                }

                Console.WriteLine($"{cheapestTransport:f2}");
            }
        }
    }
}
