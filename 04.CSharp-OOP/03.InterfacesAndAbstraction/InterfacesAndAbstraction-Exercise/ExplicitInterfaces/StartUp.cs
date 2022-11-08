using System;
using ExplicitInterfaces.Core;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.IO.Interfaces;

namespace ExplicitInterfaces
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
