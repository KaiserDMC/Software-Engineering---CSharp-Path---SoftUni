using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger[] snowballValue = new BigInteger[numberOfSnowballs];
            int[] bestSnow = new int[numberOfSnowballs];
            int[] bestTime = new int[numberOfSnowballs];
            int[] bestQuality = new int[numberOfSnowballs];

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballValue[i] = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                bestSnow[i] = snowballSnow;
                bestTime[i] = snowballTime;
                bestQuality[i] = snowballQuality;
            }

            BigInteger bestSnowball = long.MinValue;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;

            for (int i = snowballValue.Length - 1; i >= 0; i--)
            {
                if (snowballValue[i] > bestSnowball)
                {
                    bestSnowball = snowballValue[i];
                    bestSnowballSnow = bestSnow[i];
                    bestSnowballTime = bestTime[i];
                    bestSnowballQuality = bestQuality[i];
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowball} ({bestSnowballQuality})");
        }
    }
}
