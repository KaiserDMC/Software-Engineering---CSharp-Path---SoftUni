using MilitaryElite.Core.Interfaces;
using MilitaryElite.IO.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Enums;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly ICollection<ISoldier> _soldiers;

        public Engine()
        {
            _soldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }

        public void Run()
        {
            string line = _reader.ReadLine();
            
            while (line != "End")
            {
                string[] args = line.Split(" ");
                string type = args[0];
                int id = int.Parse(args[1]);
                string firstName = args[2];
                string lastName = args[3];

                ISoldier soldier;
                
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(args[4]);
                    ICollection<IPrivate> privates = this.FindPrivates(args);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(args[4]);

                    string corpsText = args[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        line = _reader.ReadLine();
                        continue;
                    }

                    ICollection<IRepair> repairs = this.CreateRepairs(args);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(args[4]);

                    string corpsText = args[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, true, out Corps corps);
                    if (!isCorpsValid)
                    {
                        line = _reader.ReadLine();
                        continue;
                    }

                    ICollection<IMission> missions = this.CreateMissions(args);
                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(args[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else
                {
                    line = _reader.ReadLine();
                    continue;
                }

                _soldiers.Add(soldier);
                line = _reader.ReadLine();
            }

            foreach (ISoldier soldier in _soldiers)
            {
                this._writer.WriteLine(soldier.ToString());
            }
        }

        private ICollection<IPrivate> FindPrivates(string[] cmdArgs)
        {
            int[] privatesIds = cmdArgs
                .Skip(5)
                .Select(int.Parse)
                .ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();
            foreach (int privateId in privatesIds)
            {
                IPrivate currPrivate = (IPrivate)this._soldiers
                    .FirstOrDefault(s => s.Id == privateId);

                privates.Add(currPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> CreateRepairs(string[] cmdArgs)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();

            string[] repairsInfo = cmdArgs
                .Skip(6)
                .ToArray();
            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string partName = repairsInfo[i];
                int hoursWorked = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> CreateMissions(string[] cmdArgs)
        {
            ICollection<IMission> missions = new HashSet<IMission>();

            string[] missionsInfo = cmdArgs
                .Skip(6)
                .ToArray();
            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];

                string stateText = missionsInfo[i + 1];
                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }
    }
}