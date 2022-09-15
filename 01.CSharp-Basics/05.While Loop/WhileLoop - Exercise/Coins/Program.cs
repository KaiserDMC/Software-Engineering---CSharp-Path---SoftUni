using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double changeToReturn = double.Parse(Console.ReadLine()) * 100;
            int count = 0;

            do
            {
                if (changeToReturn >= 200)
                {
                    changeToReturn -= 200;
                    count++;
                }
                else if (changeToReturn >= 100)
                {
                    changeToReturn -= 100;
                    count++;
                }
                else if (changeToReturn >= 50)
                {
                    changeToReturn -= 50;
                    count++;
                }
                else if (changeToReturn >= 20)
                {
                    changeToReturn -= 20;
                    count++;
                }
                else if (changeToReturn >= 10)
                {
                    changeToReturn -= 10;
                    count++;
                }
                else if (changeToReturn >= 5)
                {
                    changeToReturn -= 5;
                    count++;
                }
                else if (changeToReturn >= 2)
                {
                    changeToReturn -= 2;
                    count++;
                }
                else if (changeToReturn >= 1)
                {
                    changeToReturn -= 1;
                    count++;
                }
                else
                {
                    changeToReturn = 0;
                }

            } while (changeToReturn > 0);

            Console.WriteLine(count);
        }
    }
}
