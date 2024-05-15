using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string genderTom = "Male";

        public Tomcat(string name, int age) : base(name, age, genderTom)
        {
        }

        public override string ProduceSound()
        {
            return $"MEOW";
        }
    }
}
