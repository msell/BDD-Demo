using CreditCardServices.Core.Models;
using CreditCardServices.Core.Services;
using Machine.Specifications;
using FluentAssertions;

namespace CreditCardServices.Tests.DecisionService
{
    [Subject("CreditDecisionService")]
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
}
