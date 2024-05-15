using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialList = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string inputString = Console.ReadLine();
            int index = 0;

            while (inputString != "Love!")
            {
                string[] commandInput = inputString.Split(" ").ToArray();
                int jumpLength = int.Parse(commandInput[1]);

                if (index + jumpLength > initialList.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index += jumpLength;
                }

                if (initialList[index] == 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");

                }
                else
                {
                    initialList[index] -= 2;

                    if (initialList[index] == 0)
                    {
                        Console.WriteLine($"Place {index} has Valentine's day.");
                    }
                }


                inputString = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {index}.");

            bool houseHadCupid = false;
            int failedHouseCount = 0;
            int successfullHouseCount = 0;
            for (int i = 0; i < initialList.Length; i++)
            {
                if (initialList[i] == 0)
                {
                    successfullHouseCount++;
                }
                else
                {
                    failedHouseCount++;
                }
            }

            if (successfullHouseCount == initialList.Length)
            {
                houseHadCupid = true;
            }

            if (houseHadCupid)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedHouseCount} places.");
            }
        }

    }
}
