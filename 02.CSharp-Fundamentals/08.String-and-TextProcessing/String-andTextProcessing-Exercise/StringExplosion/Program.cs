using System;
using System.Linq;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            int strenghtOfExplosion = 0;
            string outputString = String.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '>')
                {
                    strenghtOfExplosion += int.Parse(inputString[i + 1].ToString());

                    outputString += inputString[i];
                }
                else if (strenghtOfExplosion == 0)
                {
                    outputString += inputString[i];
                }
                else
                {
                    strenghtOfExplosion--;
                }
            }

            Console.WriteLine(outputString);
        }
    }
}
