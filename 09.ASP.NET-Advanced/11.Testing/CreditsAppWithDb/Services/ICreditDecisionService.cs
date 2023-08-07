using CreditsAppWithDb.Data;

namespace CreditsAppWithDb.Services
{
    public interface ICreditDecisionService
    {
        CreditDecision GetById(int id);
    }
}
