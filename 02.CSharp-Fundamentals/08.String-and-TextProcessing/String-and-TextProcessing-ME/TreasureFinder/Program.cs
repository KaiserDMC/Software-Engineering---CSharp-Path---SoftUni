using System;
using System.Linq;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keyString = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            while (true)
            {
                string stringToDecrypt = Console.ReadLine();
                int count = 0;

                string decryptedString = String.Empty;

                if (stringToDecrypt == "find")
                {
                    break;
                }


                foreach (char character in stringToDecrypt)
                {
                    decryptedString += (char)(character - keyString[count]);

                    count++;

                    if (count % keyString.Length == 0)
                    {
                        count = 0;
                    }
                }

                string[] treasureType = decryptedString.Split("&");

                int treasureCoordinatesOne = decryptedString.IndexOf('<');
                int treasureCoordinatesTwo = decryptedString.IndexOf('>');

                string coordinates = decryptedString.Substring(treasureCoordinatesOne + 1,
                    treasureCoordinatesTwo - treasureCoordinatesOne - 1);


                Console.WriteLine($"Found {treasureType[1]} at {coordinates}");
            }
        }
    }
}
