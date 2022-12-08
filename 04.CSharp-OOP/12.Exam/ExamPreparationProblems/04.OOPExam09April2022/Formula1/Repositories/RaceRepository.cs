using System.Collections.Generic;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
            => this.models.Remove(model);

        public IRace FindByName(string name)
            => this.models.Find(r => r.RaceName == name);
    }
}