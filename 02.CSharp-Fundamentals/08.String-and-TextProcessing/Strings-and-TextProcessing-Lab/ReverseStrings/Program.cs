using System;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string inputString = Console.ReadLine();

                if (inputString == "end")
                {
                    break;
                }

                char[] charactersFromString = inputString.ToCharArray();
                Array.Reverse(charactersFromString);

                string outputString = new string(charactersFromString);

                Console.WriteLine($"{inputString} = {outputString}");
            }
        }
    }
}
