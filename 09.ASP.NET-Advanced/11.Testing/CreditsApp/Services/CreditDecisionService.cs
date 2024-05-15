namespace CreditsApp.Services
{
    public class CreditDecisionService
        : ICreditDecisionService
    {
        public string GetDecision(int creditScore)
        {
            if (creditScore < 550)
                return "Declined";
            else if (creditScore < 675)
                return "Maybe";
            else
                return "Absolutely";
        }
    }
}
