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
        public DecisionResponse GetDecision(CreditCardApplication application)
        {
            var decision = new DecisionResponse { Result = DecisionResult.Declined };

            if (application.HomeAddress.State == "OK")
            {
                decision.Result = DecisionResult.Declined;
                return decision;
            }
            var creditReport = _creditService.CheckCreditHistory(new CreditCardApplication());

            var isQualified = CreditRating.FromScore(creditReport.CreditScore).Qualified;
            decision.Result = isQualified ? DecisionResult.Approved : DecisionResult.Declined;

            return decision;
        }
    }
}