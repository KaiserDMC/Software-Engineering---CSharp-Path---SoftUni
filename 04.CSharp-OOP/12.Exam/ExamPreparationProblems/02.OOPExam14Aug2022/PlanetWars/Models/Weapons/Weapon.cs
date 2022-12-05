using System;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            Price = price;
        }

        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new Exception(ExceptionMessages.TooLowDestructionLevel);
                }

                if (value > 10)
                {
                    throw new Exception(ExceptionMessages.TooHighDestructionLevel);
                }

                destructionLevel = value;
            }
        }

        public double Price { get; }
    }
}