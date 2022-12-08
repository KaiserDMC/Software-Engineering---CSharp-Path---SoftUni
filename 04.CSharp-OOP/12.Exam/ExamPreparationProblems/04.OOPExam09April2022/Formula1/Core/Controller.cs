using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.F1Cars;
using Formula1.Models.Pilots;
using Formula1.Models.Races;
using Formula1.Repositories;
using Formula1.Utilities;
using Microsoft.VisualBasic;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilotToAdd = pilotRepository.FindByName(fullName);

            if (pilotToAdd != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotToAdd = new Pilot(fullName);
            pilotRepository.Add(pilotToAdd);

            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar carToAdd = carRepository.FindByName(model);

            if (carToAdd != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            switch (type)
            {
                case "Ferrari":
                    carToAdd = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case "Williams":
                    carToAdd = new Williams(model, horsepower, engineDisplacement);
                    break;
            }

            carRepository.Add(carToAdd);

            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace raceToAdd = raceRepository.FindByName(raceName);

            if (raceToAdd != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceToAdd = new Race(raceName, numberOfLaps);
            raceRepository.Add(raceToAdd);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilotToCheck = pilotRepository.FindByName(pilotName);

            if (pilotToCheck == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (pilotToCheck.CanRace)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar carToCheck = carRepository.FindByName(carModel);

            if (carToCheck == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage,
                    carModel));
            }

            pilotToCheck.AddCar(carToCheck);
            carRepository.Remove(carToCheck);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carToCheck.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace raceToCheck = raceRepository.FindByName(raceName);

            if (raceToCheck == null)
            {
                throw new NullReferenceException(
                    String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }


            IPilot pilotToCheck = pilotRepository.FindByName(pilotFullName);

            if (pilotToCheck == null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if (!pilotToCheck.CanRace)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            if (raceToCheck.Pilots.Contains(pilotToCheck))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
                    pilotFullName));
            }

            raceToCheck.AddPilot(pilotToCheck);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace raceToCheck = raceRepository.FindByName(raceName);

            if (raceToCheck == null)
            {
                throw new NullReferenceException(
                    String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (raceToCheck.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (raceToCheck.TookPlace)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            raceToCheck.TookPlace = true;

            int laps = raceToCheck.NumberOfLaps;
            var pilotsInOrder = raceToCheck.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(laps));

            IPilot firstPilot = pilotsInOrder.FirstOrDefault();
            IPilot secondPilot = pilotsInOrder.Skip(1).FirstOrDefault();
            IPilot thirdPilot = pilotsInOrder.Skip(2).FirstOrDefault();
            
            firstPilot.WinRace();

            StringBuilder text = new StringBuilder();

            text.AppendLine($"Pilot {firstPilot.FullName} wins the {raceName} race.");
            text.AppendLine($"Pilot {secondPilot.FullName} is second in the {raceName} race.");
            text.Append($"Pilot {thirdPilot.FullName} is third in the {raceName} race.");

            return text.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder text = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(r => r.TookPlace))
            {
                text.AppendLine(race.RaceInfo());
            }

            return text.ToString().Trim();
        }

        public string PilotReport()
        {
            StringBuilder text = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                text.AppendLine(pilot.ToString());
            }

            return text.ToString().Trim();
        }
    }
}