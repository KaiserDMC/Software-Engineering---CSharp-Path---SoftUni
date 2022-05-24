using System;

namespace WFp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string weather = Console.ReadLine();
            string sunnyWeather = "It's warm outside!";

            if (!weather.Contains("sunny"))
            {
                Console.WriteLine("It's cold outside!");
            }
            else
            {
                Console.WriteLine(sunnyWeather);
            }

        }
    }
}
