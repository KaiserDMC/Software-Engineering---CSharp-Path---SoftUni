using System;

namespace RefractoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());

            for (int startRange = 2; startRange <= endRange; startRange++)
            {
                bool checkInsideRange = true;

                for (int i = 2; i < startRange; i++)
                {
                    if (startRange % i == 0)
                    {
                        checkInsideRange = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", startRange, checkInsideRange.ToString().ToLower());
            }
        }
    }
}
