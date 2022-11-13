using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Druid(string name)
        {
            this.Name = name;
            this.Power = 80;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
