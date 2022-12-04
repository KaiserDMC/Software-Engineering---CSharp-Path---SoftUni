using System;
using MilitaryElite.IO.Interfaces;

namespace MilitaryElite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string result)
        {
            Console.Write(result);
        }

        public void WriteLine(string result)
        {
            Console.WriteLine(result);
        }
    }
}