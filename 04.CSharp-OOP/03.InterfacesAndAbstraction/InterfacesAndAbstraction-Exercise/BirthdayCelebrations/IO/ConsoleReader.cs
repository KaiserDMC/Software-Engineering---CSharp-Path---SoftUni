using System;
using System.Collections.Generic;
using System.Text;
using BirthdayCelebrations.IO.Interfaces;

namespace BirthdayCelebrations.IO
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
