using System;
using System.Collections.Generic;
using System.Text;
using Raiding.IO.Interfaces;

namespace Raiding.IO
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
