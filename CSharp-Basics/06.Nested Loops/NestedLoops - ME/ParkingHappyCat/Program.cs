using System;

namespace ParkingHappyCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double parkingFee = 0;
            double totalParkingFee = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j <= hours; j++)
                    {
                        if (j % 2 != 0)
                        {
                            parkingFee += 2.5;
                        }
                        else
                        {
                            parkingFee += 1;
                        }
                    }
                }
                else
                {
                    for (int j = 1; j <= hours; j++)
                    {
                        if (j % 2 == 0)
                        {
                            parkingFee += 1.25;
                        }
                        else
                        {
                            parkingFee += 1;
                        }
                    }
                }

                Console.WriteLine($"Day: {i} - {parkingFee:f2} leva");
                totalParkingFee += parkingFee;
                parkingFee = 0;
            }

            Console.WriteLine($"Total: {totalParkingFee:f2} leva");
        }
    }
}
