using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double[] kegVolume = new double[input];
            string[] kegs = new string[input];

            for (int i = 0; i < input; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                kegVolume[i] = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;
                kegs[i] = kegModel;
            }

            double maxValue = double.MinValue;
            string maxKeg = string.Empty;

            for (int i = kegVolume.Length - 1; i >= 0; i--)
            {
                if (kegVolume[i] > maxValue)
                {
                    maxValue = kegVolume[i];
                    maxKeg = kegs[i];
                }
            }

            Console.WriteLine(maxKeg);
        }
    }
}
