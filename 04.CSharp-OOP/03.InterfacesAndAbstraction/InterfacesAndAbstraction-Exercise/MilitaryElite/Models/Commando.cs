using System;
using System.Collections.Generic;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> _missions;

        public Commando(int id, string firstName, string lastName,
            decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            _missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions
            => (IReadOnlyCollection<IMission>)_missions;

        public override string ToString()
        {
            if (_missions.Count > 0)
                return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}" +
                       Environment.NewLine + $"Corps: {Corps}" +
                       Environment.NewLine + "Missions:" +
                       Environment.NewLine + "  " +
                       string.Join(Environment.NewLine + "  ", _missions);

            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}" +
                   Environment.NewLine + $"Corps: {Corps}" +
                   Environment.NewLine + "Missions:";
        }
    }
}