using System;
using System.ComponentModel.Design;

namespace MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contractPeriod = Console.ReadLine();
            string contractType = Console.ReadLine();
            string mobileData = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            double tax = 0;

            switch (contractType)
            {
                case "Small":
                    if (contractPeriod == "one")
                    {
                        tax = 9.98;
                    }
                    else
                    {
                        tax = 8.58;
                    }

                    break;
                case "Middle":
                    if (contractPeriod == "one")
                    {
                        tax = 18.99;
                    }
                    else
                    {
                        tax = 17.09;
                    }

                    break;
                case "Large":
                    if (contractPeriod == "one")
                    {
                        tax = 25.98;
                    }
                    else
                    {
                        tax = 23.59;
                    }

                    break;
                case "ExtraLarge":
                    if (contractPeriod == "one")
                    {
                        tax = 35.99;
                    }
                    else
                    {
                        tax = 31.79;
                    }

                    break;
            }

            if (mobileData == "yes")
            {
                if (tax <= 10)
                {
                    tax += 5.5;
                }
                else if (tax <= 30)
                {
                    tax += 4.35;
                }
                else if (tax > 30)
                {
                    tax += 3.85;
                }
            }

            tax *= months;
            //tax = tax * months;

            if (contractPeriod == "two")
            {
                tax *= 0.9625;
            }

            Console.WriteLine($"{tax:f2} lv.");
        }
    }
}