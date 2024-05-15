using System;
using System.Collections.Generic;
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer: SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> _repairs;
        
        public Engineer(int id, string firstName, string lastName,
            decimal salary, Corps corps, ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            _repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs
            => (IReadOnlyCollection<IRepair>)this._repairs;

        public override string ToString()
        {
            if (_repairs.Count > 0)
                return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}" +
                       Environment.NewLine + $"Corps: {Corps}" +
                       Environment.NewLine + $"Repairs:" +
                       Environment.NewLine + "  " +
                       string.Join(Environment.NewLine + "  ", _repairs);
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}" +
                   Environment.NewLine + $"Corps: {Corps}" +
                   Environment.NewLine + $"Repairs:";
        }
    }
}