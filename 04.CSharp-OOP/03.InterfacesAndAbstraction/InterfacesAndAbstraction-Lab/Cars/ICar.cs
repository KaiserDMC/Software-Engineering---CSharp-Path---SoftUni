using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public string Start() => $"Engine start";

        public string Sto() => $"Breaaak!";
    }
}
