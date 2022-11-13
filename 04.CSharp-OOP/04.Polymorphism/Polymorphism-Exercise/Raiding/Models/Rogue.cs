using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Rogue(string name)
        {
            this.Name = name;
            this.Power = 80;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
