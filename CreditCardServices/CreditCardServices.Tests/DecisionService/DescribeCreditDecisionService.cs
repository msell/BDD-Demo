using CreditCardServices.Core.Models;
using CreditCardServices.Core.Services;
using Machine.Specifications;
using FluentAssertions;
using Moq;
using It = Machine.Specifications.It;

namespace CreditCardServices.Tests.DecisionService
{
    [Subject("CreditDecisionService")]
    class when_the_applicant_has_excellent_credit
    {
        Establish context = () =>
        {
            var fakeCreditService = Mock.Of<ICreditReportService>();
            
            Mock.Get(fakeCreditService)
                .Setup(x => x.CheckCreditHistory(Moq.It.IsAny<CreditReportRequest>()))
                .Returns(new CreditReport {CreditScore = 720});

            sut = new CreditDecisionService(fakeCreditService);
        };
        Because of = () => response = sut.GetDecision(decisionRequest);

        It should_approve_the_applicant = () => response.Result.Should().Be(DecisionResult.Approved);

        static CreditDecisionService sut;
        static DecisionResponse response;
        static DecisionRequest decisionRequest;
    }

    class when_the_applicant_has_poor_credit
    {
        Establish context = () =>
        {
            var fakeCreditService = Mock.Of<ICreditReportService>();

            Mock.Get(fakeCreditService)
                .Setup(x => x.CheckCreditHistory(Moq.It.IsAny<CreditReportRequest>()))
                .Returns(new CreditReport { CreditScore = 400 });

            sut = new CreditDecisionService(fakeCreditService);
        };
        
        Because of = () => response = sut.GetDecision(decisionRequest);
        
        It should_decline_the_applicant = () => response.Result.Should().Be(DecisionResult.Declined);
        
        static CreditDecisionService sut;
        static DecisionResponse response;
        static DecisionRequest decisionRequest;
    }
}
