using System;
using System.Linq;
using CommonClasses;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputAddress = Console.ReadLine().Split(" ").ToArray();
            string[] inputBeer = Console.ReadLine().Split(" ").ToArray();
            string[] inputNumbers = Console.ReadLine().Split(" ").ToArray();

            Threeuple<string, string, string> personalInformation = new Threeuple<string, string, string>
            {
                Item1 = $"{inputAddress[0]} {inputAddress[1]}",
                Item2 = inputAddress[2],
                Item3 = inputAddress[3]
            };

            if (inputAddress.Length > 4)
            {
                personalInformation.Item3 = $"{inputAddress[3]} {inputAddress[4]}";
            }

            Threeuple<string, int, bool> beerInformation = new Threeuple<string, int, bool>
            {
                Item1 = inputBeer[0],
                Item2 = int.Parse(inputBeer[1]),
                Item3 = inputBeer[2] == "drunk"
            };

            Threeuple<string, double, string> numberInformation = new Threeuple<string, double, string>
            {
                Item1 = inputNumbers[0],
                Item2 = double.Parse(inputNumbers[1]),
                Item3 = inputNumbers[2]
            };

            Console.WriteLine(personalInformation);
            Console.WriteLine(beerInformation);
            Console.WriteLine(numberInformation);
        }
    }
}