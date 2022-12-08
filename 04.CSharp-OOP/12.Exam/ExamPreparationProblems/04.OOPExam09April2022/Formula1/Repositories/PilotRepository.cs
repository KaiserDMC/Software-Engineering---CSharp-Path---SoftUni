using System.Collections.Generic;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models.AsReadOnly();

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPilot model)
            => this.models.Remove(model);

        public IPilot FindByName(string name)
            => this.models.Find(p => p.FullName == name);
    }
}