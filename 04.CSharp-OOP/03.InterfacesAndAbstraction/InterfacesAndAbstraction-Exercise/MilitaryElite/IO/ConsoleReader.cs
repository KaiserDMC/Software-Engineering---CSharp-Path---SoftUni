using System;
using MilitaryElite.IO.Interfaces;

namespace MilitaryElite.IO
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