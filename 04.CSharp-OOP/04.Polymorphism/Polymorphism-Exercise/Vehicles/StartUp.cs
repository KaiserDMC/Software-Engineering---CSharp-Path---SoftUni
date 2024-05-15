using System;
using System.IO;
using Vehicles.Core;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles
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
