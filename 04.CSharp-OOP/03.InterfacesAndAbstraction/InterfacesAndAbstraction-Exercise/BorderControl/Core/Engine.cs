using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private List<IIdentifiable> citizensAndRobots;

        public Engine()
        {
            this.citizensAndRobots = new List<IIdentifiable>();
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
                string[] citizenInputs = this.reader.ReadLine().Split(" ").ToArray();

                if (citizenInputs[0] == "End")
                {
                    break;
                }

                if (citizenInputs.Length == 3)
                {
                    this.citizensAndRobots.Add(new Citizen(citizenInputs[0], int.Parse(citizenInputs[1]), citizenInputs[2]));
                }
                else
                {
                    this.citizensAndRobots.Add(new Robot(citizenInputs[0], citizenInputs[1]));
                }
            }

            string fakeIDString = this.reader.ReadLine();

            foreach (var citiORobot in citizensAndRobots)
            {
                if (!string.IsNullOrEmpty(citiORobot.CheckForFakeID(fakeIDString)))
                {
                    this.writer.WriteLine(citiORobot.CheckForFakeID(fakeIDString));
                }
            }
        }
    }
}
