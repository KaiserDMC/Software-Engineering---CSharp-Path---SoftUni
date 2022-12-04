using System;
using System.Collections.Generic;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> _privates;
        
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this._privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<IPrivate>)this._privates;
        
        public override string ToString()
        {
            if (_privates.Count > 0)
                return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}"
                       + Environment.NewLine + $"Privates:" +
                       Environment.NewLine + "  " +
                       string.Join(Environment.NewLine + "  ", _privates);
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}"
                   + Environment.NewLine + $"Privates:";
        }
    }
}