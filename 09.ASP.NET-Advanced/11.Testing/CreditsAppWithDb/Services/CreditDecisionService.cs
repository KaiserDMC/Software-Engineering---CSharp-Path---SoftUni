using CreditsAppWithDb.Data;

namespace CreditsAppWithDb.Services
{
    public class CreditDecisionService : ICreditDecisionService
    {
        private readonly AppDbContext data;

        public CreditDecisionService(AppDbContext data)
         => this.data = data;

        public CreditDecision GetById(int id)
         => this.data.CreditDecisions.Find(id);
    }
}
