using System;
using System.Collections.Generic;
using System.Text;
using ExplicitInterfaces.IO.Interfaces;

namespace ExplicitInterfaces.IO
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
