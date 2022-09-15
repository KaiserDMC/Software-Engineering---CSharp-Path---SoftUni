using System;

namespace SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = string.Empty;
            string shoes = string.Empty;

            switch (timeOfDay)
            {
                case "Morning":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees >= 25)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (degrees >= 25)
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees > 18 && degrees <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees >= 25)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    break;
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
