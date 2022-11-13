using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
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
