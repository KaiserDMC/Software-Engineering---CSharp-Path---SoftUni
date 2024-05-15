using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.IO.Interfaces;

namespace FoodShortage.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
