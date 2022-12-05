using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new Exception(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => CalculatedMilitaryPower();
        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var army in Army)
            {
                army.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new Exception(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"Planet: {name}");
            text.AppendLine($"--Budget: {budget} billion QUID");

            if (units.Models.Any())
            {
                text.AppendLine($"--Forces: {string.Join(", ", units.Models.Select(u=>u.GetType().Name))}");
            }
            else
            {
                text.AppendLine($"--Forces: No units");
            }
            
            if (weapons.Models.Any())
            {
                text.AppendLine($"--Combat equipment: {string.Join(", ", weapons.Models.Select(w=>w.GetType().Name))}");
            }
            else
            {
                text.AppendLine($"--Combat equipment: No weapons");
            }

            text.Append($"--Military Power: {MilitaryPower}");

            return text.ToString();
        }

        private double CalculatedMilitaryPower()
        {
            double power = Army.Select(unit => unit.EnduranceLevel).Sum() + Weapons.Select(weapon => weapon.DestructionLevel).Sum();

            power = Army.Any(a => a.GetType() == typeof(AnonymousImpactUnit)) ? power * 1.3 : power;
            power = Weapons.Any(w => w.GetType() == typeof(NuclearWeapon)) ? power * 1.45 : power;

            return Math.Round(power, 3);
        }
    }
}