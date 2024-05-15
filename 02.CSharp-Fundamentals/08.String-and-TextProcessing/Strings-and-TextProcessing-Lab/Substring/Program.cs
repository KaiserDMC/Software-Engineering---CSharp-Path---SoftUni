using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            int indexInSecondString = secondString.IndexOf(firstString);

            string outputString = secondString;

            while (indexInSecondString != -1)
            {
                outputString = outputString.Remove(indexInSecondString, firstString.Length);

                indexInSecondString = outputString.IndexOf(firstString);
            }

            Console.WriteLine(outputString);
        }
    }
}
