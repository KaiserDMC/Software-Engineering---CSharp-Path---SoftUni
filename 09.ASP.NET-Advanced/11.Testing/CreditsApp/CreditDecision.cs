using CreditsApp.Services;

namespace CreditsApp
{
    public class CreditDecision
    {
        ICreditDecisionService service;
        public CreditDecision(ICreditDecisionService service)
            => this.service = service;

        public string MakeCreditDecision(int creditScore)
            => service.GetDecision(creditScore);
    }
}
