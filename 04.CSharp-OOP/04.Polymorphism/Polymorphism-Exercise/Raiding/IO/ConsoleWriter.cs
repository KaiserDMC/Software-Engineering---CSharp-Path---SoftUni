using System;
using System.Collections.Generic;
using System.Text;
using Raiding.IO.Interfaces;

namespace Raiding.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
