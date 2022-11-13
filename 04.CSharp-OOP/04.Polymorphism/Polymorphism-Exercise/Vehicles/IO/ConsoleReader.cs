using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Interfaces;

namespace Vehicles.IO
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
