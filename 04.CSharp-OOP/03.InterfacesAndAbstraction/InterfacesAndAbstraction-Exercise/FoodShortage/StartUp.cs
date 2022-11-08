using System;
using FoodShortage.Core;
using FoodShortage.IO;
using FoodShortage.IO.Interfaces;

namespace FoodShortage
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
