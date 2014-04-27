using CreditCardServices.Core.Models;

namespace CreditCardServices.Core.Services
{
    public class CreditDecisionService
    {
        public DecisionResponse GetDecision(DecisionRequest decisionRequest)
        {
            return new DecisionResponse {Result = DecisionResult.Approved};
        }
    }
}