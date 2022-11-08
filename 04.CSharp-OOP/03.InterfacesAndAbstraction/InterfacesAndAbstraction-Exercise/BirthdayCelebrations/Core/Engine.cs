using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private List<IIdentifiable> citizensAndRobots;
        private List<IBirthable> citizensAndPets;

        public Engine()
        {
            this.citizensAndRobots = new List<IIdentifiable>();
            this.citizensAndPets = new List<IBirthable>();
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

                string typeOfEntity = citizenInputs[0];

                switch (typeOfEntity)
                {
                    case "Citizen":

                        this.citizensAndRobots.Add(new Citizen(citizenInputs[1], int.Parse(citizenInputs[2]),
                            citizenInputs[3], citizenInputs[4]));
                        this.citizensAndPets.Add(new Citizen(citizenInputs[1], int.Parse(citizenInputs[2]),
                            citizenInputs[3], citizenInputs[4]));

                        break;
                    case "Pet":

                        this.citizensAndPets.Add(new Pet(citizenInputs[1], citizenInputs[2]));

                        break;
                    case "Robot":

                        this.citizensAndRobots.Add(new Robot(citizenInputs[0], citizenInputs[1]));

                        break;
                }
            }

            //string fakeIDString = this.reader.ReadLine();

            //foreach (var citiORobot in citizensAndRobots)
            //{
            //    if (!string.IsNullOrEmpty(citiORobot.CheckForFakeID(fakeIDString)))
            //    {
            //        this.writer.WriteLine(citiORobot.CheckForFakeID(fakeIDString));
            //    }
            //}

            string dateToCheck = this.reader.ReadLine();

            foreach (var citiOPet in citizensAndPets)
            {
                if (!string.IsNullOrEmpty(citiOPet.CheckBirthdate(dateToCheck)))
                {
                    this.writer.WriteLine(citiOPet.CheckBirthdate(dateToCheck));
                }
            }
        }
    }
}

