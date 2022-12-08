using System.Collections.Generic;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public bool Remove(IFormulaOneCar model)
            => this.models.Remove(model);

        public IFormulaOneCar FindByName(string name)
            => this.models.FirstOrDefault(c => c.Model == name);
    }
}