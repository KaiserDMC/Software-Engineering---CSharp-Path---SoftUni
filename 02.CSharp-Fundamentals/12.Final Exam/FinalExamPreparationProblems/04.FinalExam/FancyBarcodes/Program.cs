using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string regexPattern = @"(?<surr>@)[#]+(?<code>[A-Z][A-Za-z0-9]{4,}[A-Z])\k<surr>[#]+";

            List<string> allBarCodes = new List<string>();
            List<string> validBarCodes = new List<string>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string code = Console.ReadLine();

                allBarCodes.Add(code);
            }


            foreach (string code in allBarCodes)
            {
                Match barCodeMatch = Regex.Match(code, regexPattern);

                if (barCodeMatch.Success)
                {
                    string productGroup = String.Empty;
                    string currentCode = barCodeMatch.Groups["code"].Value;

                    for (int i = 0; i < currentCode.Length; i++)
                    {
                        char currentChar = currentCode[i];

                        if (char.IsDigit(currentChar))
                        {
                            productGroup += currentChar;
                        }
                    }

                    if (productGroup == String.Empty)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }

            }
        }
    }
}
