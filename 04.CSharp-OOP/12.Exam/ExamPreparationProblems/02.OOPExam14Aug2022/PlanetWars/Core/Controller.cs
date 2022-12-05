using System;
using System.Linq;
using System.Text;
using PlanetWars.Core.Contracts;
using PlanetWars.Models;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (!planets.Models.Any(p => p.Name == name))
            {
                IPlanet planet = new Planet(name, budget);
                planets.AddItem(planet);

                return string.Format(OutputMessages.NewPlanet, name);
            }
            else
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "StormTroopers" && unitTypeName != "SpaceForces" &&
                unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (string.IsNullOrEmpty(unitTypeName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.InvalidUnitName));
            }

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit militaryUnit = null;

            switch (unitTypeName)
            {
                case "StormTroopers":
                    militaryUnit = new StormTroopers();
                    break;
                case "SpaceForces":
                    militaryUnit = new SpaceForces();
                    break;
                case "AnonymousImpactUnit":
                    militaryUnit = new AnonymousImpactUnit();
                    break;
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "SpaceMissiles" &&
                weaponTypeName != "NuclearWeapon")
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (string.IsNullOrEmpty(weaponTypeName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.InvalidWeaponName));
            }

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;

            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.FindByName(planetName);

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planetX = planets.FindByName(planetOne);
            IPlanet planetY = planets.FindByName(planetTwo);
            bool winnerOne = false;
            bool winnerTwo = false;

            string message = string.Empty;

            if (planetX.MilitaryPower > planetY.MilitaryPower)
            {
                winnerOne = true;
            }
            else if (planetY.MilitaryPower > planetX.MilitaryPower)
            {
                winnerTwo = true;
            }
            else
            {
                if (planetX.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") &&
                    planetY.Weapons.All(w => w.GetType().Name != "NuclearWeapon"))
                {
                    winnerOne = true;
                }
                else if (planetY.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") &&
                         planetX.Weapons.All(w => w.GetType().Name != "NuclearWeapon"))
                {
                    winnerTwo = true;
                }
            }

            if (!winnerOne && !winnerTwo)
            {
                planetX.Spend(planetX.Budget / 2);
                planetY.Spend(planetY.Budget / 2);

                message = string.Format(OutputMessages.NoWinner);
            }
            else if (winnerOne)
            {
                planetX.Spend(planetX.Budget / 2);
                planetX.Profit(planetY.Budget / 2);
                planetX.Profit(planetY.Army.Sum(u => u.Cost));
                planetX.Profit(planetY.Weapons.Sum(w => w.Price));

                message = string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                planets.RemoveItem(planetTwo);
            }
            else if (winnerTwo)
            {
                planetY.Spend(planetY.Budget / 2);
                planetY.Profit(planetX.Budget / 2);
                planetY.Profit(planetX.Army.Sum(u => u.Cost));
                planetY.Profit(planetX.Weapons.Sum(w => w.Price));

                message = string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                planets.RemoveItem(planetOne);
            }

            return message;
        }

        public string ForcesReport()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                text.AppendLine(planet.PlanetInfo());
            }

            return text.ToString().TrimEnd();
        }
    }
}