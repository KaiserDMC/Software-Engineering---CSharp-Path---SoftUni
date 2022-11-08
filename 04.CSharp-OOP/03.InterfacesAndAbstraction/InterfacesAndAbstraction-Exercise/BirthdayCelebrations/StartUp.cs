using System;
using BirthdayCelebrations.Core;
using BirthdayCelebrations.IO;
using BirthdayCelebrations.IO.Interfaces;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
