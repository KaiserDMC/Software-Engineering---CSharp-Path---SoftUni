using System;
using System.Linq;

namespace TupleDuo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPerson = Console.ReadLine().Split(" ").ToArray();
            string[] inputBeer = Console.ReadLine().Split(" ").ToArray();
            string[] inputNumbers = Console.ReadLine().Split(" ").ToArray();

            CommonClasses.Tuple<string, string> personalInformation = new CommonClasses.Tuple<string, string>
            {
                Item1 = $"{inputPerson[0]} {inputPerson[1]}",
                Item2 = inputPerson[2]
            };

            CommonClasses.Tuple<string, int> beerInformation = new CommonClasses.Tuple<string, int>
            {
                Item1 = $"{inputBeer[0]}",
                Item2 = int.Parse(inputBeer[1])
            };

            CommonClasses.Tuple<int, double> numberInformation = new CommonClasses.Tuple<int, double>
            {
                Item1 = int.Parse(inputNumbers[0]),
                Item2 = double.Parse(inputNumbers[1])
            };

            Console.WriteLine(personalInformation);
            Console.WriteLine(beerInformation);
            Console.WriteLine(numberInformation);
        }
    }
}