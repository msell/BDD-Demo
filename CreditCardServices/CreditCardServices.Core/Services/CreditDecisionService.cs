using CreditCardServices.Core.Models;

namespace CreditCardServices.Core.Services
{
    public class CreditDecisionService
    {
        ICreditReportService _creditService;

        public CreditDecisionService(ICreditReportService creditService)
        {
            _creditService = creditService;
        }
        public DecisionResponse GetDecision(DecisionRequest decisionRequest)
        {
            var creditReport = _creditService.CheckCreditHistory(new CreditReportRequest());
            var decision = new DecisionResponse {Result = DecisionResult.Declined};

            if(creditReport.CreditScore > 600)
                decision.Result = DecisionResult.Approved;

            return decision;
        }
    }
}