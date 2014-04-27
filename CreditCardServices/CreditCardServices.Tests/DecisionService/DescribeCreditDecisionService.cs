using Machine.Specifications;
using FluentAssertions;

namespace CreditCardServices.Tests.DecisionService
{
    class when_the_applicant_has_excellent_credit
    {
        Establish context = () =>
        {
            sut = new CreditDecisionService();
            
        };
        Because of = () => response = sut.GetDecision(decisionRequest);

        It should_approve_the_applicant = () => response.Result.Should().Be(DecisionResult.Approved);

        static CreditDecisionService sut;
        static DecisionResponse response;
        static DecisionRequest decisionRequest;
    }

    internal class CreditDecisionService
    {
        public DecisionResponse GetDecision(DecisionRequest decisionRequest)
        {
            return new DecisionResponse {Result = DecisionResult.Approved};
        }
    }

    internal class DecisionRequest
    {
    }
   
    internal class DecisionResponse
    {
        public DecisionResult Result { get; set; }
    }

    internal enum DecisionResult
    {
        Error, Approved, Declined
    }
}
