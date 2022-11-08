using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core
{
    class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private List<IIdentifiable> citizensAndRobots;
        private List<IBirthable> citizensAndPets;
        private List<IBuyer> citizensAndRebels;

        private int totalFood;

        public Engine()
        {
            this.citizensAndRobots = new List<IIdentifiable>();
            this.citizensAndPets = new List<IBirthable>();
            this.citizensAndRebels = new List<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numberOfInputs = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] citizenInputs = this.reader.ReadLine().Split(" ").ToArray();

                if (citizenInputs.Length == 4)
                {
                    this.citizensAndRebels.Add(new Citizen(citizenInputs[0], int.Parse(citizenInputs[1]),
                        citizenInputs[2], citizenInputs[3]));
                }
                else
                {
                    this.citizensAndRebels.Add(new Rebel(citizenInputs[0], int.Parse(citizenInputs[1]),
                        citizenInputs[2]));
                }
            }

            while (true)
            {
                string nameOfBuyer = this.reader.ReadLine();

                if (nameOfBuyer == "End")
                {
                    break;
                }

                if (citizensAndRebels.Any(cor => cor.Name == nameOfBuyer))
                {
                    IBuyer citizOrRebel = citizensAndRebels.Find(cor => cor.Name == nameOfBuyer);

                    totalFood += citizOrRebel.BuyFood();
                }
            }

            this.writer.WriteLine(totalFood.ToString());

            //while (true)
            //{
            //    string[] citizenInputs = this.reader.ReadLine().Split(" ").ToArray();

            //    if (citizenInputs[0] == "End")
            //    {
            //        break;
            //    }

            //    string typeOfEntity = citizenInputs[0];

            //    switch (typeOfEntity)
            //    {
            //        case "Citizen":

            //            this.citizensAndRobots.Add(new Citizen(citizenInputs[1], int.Parse(citizenInputs[2]),
            //                citizenInputs[3], citizenInputs[4]));
            //            this.citizensAndPets.Add(new Citizen(citizenInputs[1], int.Parse(citizenInputs[2]),
            //                citizenInputs[3], citizenInputs[4]));

            //            break;
            //        case "Pet":

            //            this.citizensAndPets.Add(new Pet(citizenInputs[1], citizenInputs[2]));

            //            break;
            //        case "Robot":

            //            this.citizensAndRobots.Add(new Robot(citizenInputs[0], citizenInputs[1]));

            //            break;
            //    }
            //}


            //string fakeIDString = this.reader.ReadLine();

            //foreach (var citiORobot in citizensAndRobots)
            //{
            //    if (!string.IsNullOrEmpty(citiORobot.CheckForFakeID(fakeIDString)))
            //    {
            //        this.writer.WriteLine(citiORobot.CheckForFakeID(fakeIDString));
            //    }
            //}

            //string dateToCheck = this.reader.ReadLine();

            //foreach (var citiOPet in citizensAndPets)
            //{
            //    if (!string.IsNullOrEmpty(citiOPet.CheckBirthdate(dateToCheck)))
            //    {
            //        this.writer.WriteLine(citiOPet.CheckBirthdate(dateToCheck));
            //    }
            //}
        }
    }
}