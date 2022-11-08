using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly List<Citizen> citizens;

        public Engine()
        {
            this.citizens = new List<Citizen>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputCommands = this.reader.ReadLine().Split(" ").ToArray();

                if (inputCommands[0] == "End")
                {
                    break;
                }

                citizens.Add(new Citizen(inputCommands[0], inputCommands[1], int.Parse(inputCommands[2])));
            }

            foreach (var citiz in citizens)
            {
                this.writer.WriteLine((citiz as IPerson).GetName());
                this.writer.WriteLine((citiz as IResident).GetName());
            }
        }
    }
}
