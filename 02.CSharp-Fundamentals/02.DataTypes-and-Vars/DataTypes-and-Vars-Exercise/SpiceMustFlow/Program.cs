using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());
            double yield = startYield;
            double totalYield = 0;
            int countDays = 0;

            while (yield >= 100)
            {
                totalYield += yield;
                totalYield -= 26;

                if (totalYield < 26)
                {
                    break;
                }

                yield -= 10;
                countDays++;
            }

            if ((yield < 100) && (totalYield > 26))
            {
                totalYield -= 26;
            }

            Console.WriteLine(countDays);
            Console.WriteLine(totalYield);
        }
    }
}
