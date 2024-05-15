using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
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
