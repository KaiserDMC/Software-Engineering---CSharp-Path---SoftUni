using System;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; }
        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;

            if (this.EnduranceLevel >= 20)
            {
                this.EnduranceLevel = 20;
                throw new Exception(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}