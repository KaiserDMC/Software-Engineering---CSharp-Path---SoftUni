using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLength = int.Parse(Console.ReadLine());
            List<string> productList = new List<string>();

            for (int i = 0; i < inputLength; i++)
            {
                string productName = Console.ReadLine();
                productList.Add(productName);
            }

            productList.Sort();
            for (int j = 0; j < productList.Count; j++)
            {
                Console.WriteLine($"{j + 1}.{productList[j]}");
            }
        }
    }
}
