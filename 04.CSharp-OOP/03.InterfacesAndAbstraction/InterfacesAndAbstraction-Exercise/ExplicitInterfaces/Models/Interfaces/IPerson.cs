using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }

        string GetName();
    }
}
