using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Channels;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarvesByHatColourAndPhysics =
                new List<Dwarf>();

            Dictionary<string, int> hatColorsDictionary = new Dictionary<string, int>();

            while (true)
            {
                string[] dwarfInputs = Console.ReadLine().Split(" <:> ").ToArray();

                if (dwarfInputs[0] == "Once upon a time")
                {
                    break;
                }

                string dwarfName = dwarfInputs[0];
                string dwarfHatColor = dwarfInputs[1];
                int dwarfPhysics = int.Parse(dwarfInputs[2]);


                if (dwarvesByHatColourAndPhysics.Any(x => x.Name == dwarfName && x.Hat == dwarfHatColor))
                {
                    Dwarf currentDwarf =
                        dwarvesByHatColourAndPhysics.FirstOrDefault(x =>
                            x.Name == dwarfName && x.Hat == dwarfHatColor);

                    int dwarfIndex = dwarvesByHatColourAndPhysics.IndexOf(currentDwarf);

                    if (dwarvesByHatColourAndPhysics[dwarfIndex].Physics < dwarfPhysics)
                    {
                        dwarvesByHatColourAndPhysics[dwarfIndex].Physics = dwarfPhysics;
                    }
                }
                else
                {
                    Dwarf dwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);
                    dwarvesByHatColourAndPhysics.Add(dwarf);
                }
            }

            foreach (var dwarf in dwarvesByHatColourAndPhysics)
            {
                if (!hatColorsDictionary.ContainsKey(dwarf.Hat))
                {
                    hatColorsDictionary[dwarf.Hat] = 0;
                }

                hatColorsDictionary[dwarf.Hat]++;
            }

            foreach (var dwarf in dwarvesByHatColourAndPhysics.OrderByDescending(x => x.Physics).ThenByDescending(x => hatColorsDictionary[x.Hat]))
            {
                Console.WriteLine($"({dwarf.Hat}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    class Dwarf
    {
        public Dwarf(string name, string hat, int physics)
        {
            this.Name = name;
            this.Hat = hat;
            this.Physics = physics;
        }

        public string Name { get; set; }
        public string Hat { get; set; }
        public int Physics { get; set; }
    }
}
