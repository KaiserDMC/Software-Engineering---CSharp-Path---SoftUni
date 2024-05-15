using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models.Interfaces
{
    public abstract class BaseHero
    {
        public  abstract string Name { get; set; }
        public  abstract int Power { get; set; }

        public abstract string CastAbility();
    }
}
