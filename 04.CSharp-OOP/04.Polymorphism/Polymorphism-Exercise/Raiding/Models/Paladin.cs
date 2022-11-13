using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Paladin(string name)
        {
            Name = name;
            Power = 100;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
