using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            switch (inputString)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine());
                    int result = DataTypeOperations(number);
                    Console.WriteLine(result);
                    break;
                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    double realResult = DataTypeOperations(realNumber);
                    Console.WriteLine($"{realResult:f2}");
                    break;
                case "string":
                    string newString = Console.ReadLine();
                    DataTypeOperations(newString);
                    break;
            }
        }

        static int DataTypeOperations(int number)
        {
            return number * 2;
        }

        static double DataTypeOperations(double realNumber)
        {
            return realNumber * 1.5;
        }

        static void DataTypeOperations(string newString)
        {
            Console.WriteLine($"${newString}$");
        }
    }
}
