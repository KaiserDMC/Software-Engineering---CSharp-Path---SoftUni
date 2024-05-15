using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out int dataTypeInt))
                    {
                        Console.WriteLine($"{input} is integer type");
                    }
                    else if (double.TryParse(input, out double dataTypeDouble))
                    {
                        Console.WriteLine($"{input} is floating point type");
                    }
                    else if (char.TryParse(input, out char dataTypeChar))
                    {
                        Console.WriteLine($"{input} is character type");
                    }
                    else if (bool.TryParse(input, out bool dataTypeBool))
                    {
                        Console.WriteLine($"{input} is boolean type");
                    }
                    else
                    {
                        Console.WriteLine($"{input} is string type");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
