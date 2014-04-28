using CreditCardServices.Core.Models;
using CreditCardServices.Core.Services;
using FizzWare.NBuilder;
using Machine.Fakes;
using Machine.Specifications;
using FluentAssertions;
using It = Machine.Specifications.It;

namespace CreditCardServices.Tests.DecisionService
{
    class when_the_applicant_has_excellent_credit : WithSubject<CreditDecisionService>
    {
        Establish context = () =>
            The<ICreditReportService>().WhenToldTo(x => x
            .CheckCreditHistory(Param.IsAny<CreditReportRequest>()))
                .Return(Builder<CreditReport>.CreateNew()
                    .With(x => x.CreditScore = CreditRating.Excellent.LowerBoundary).Build);

        Because of = () => response = Subject.GetDecision(Builder<DecisionRequest>.CreateNew().Build());

        It should_approve_the_applicant = () => response.Result.Should().Be(DecisionResult.Approved);

        static DecisionResponse response;
    }

    class when_the_applicant_has_excellent_credit_and_lives_in_oklahoma : WithSubject<CreditDecisionService>
    {
        Establish context = () =>
            The<ICreditReportService>().WhenToldTo(x => x
            .CheckCreditHistory(Param.IsAny<CreditReportRequest>()))
                .Return(Builder<CreditReport>.CreateNew()
                    .With(x => x.CreditScore = CreditRating.Excellent.LowerBoundary).Build);

        Because of = () => response = Subject.GetDecision(Builder<DecisionRequest>.CreateNew()
            .With(x=>x.HomeAddress.State = "OK").Build());

        It should_deny_the_applicant = () => response.Result.Should().Be(DecisionResult.Declined);

        static DecisionResponse response;
    }

    class when_the_applicant_has_poor_credit : WithSubject<CreditDecisionService>
    {
        Establish context = () =>

            The<ICreditReportService>().WhenToldTo(x => x
            .CheckCreditHistory(Param.IsAny<CreditReportRequest>()))
                .Return(Builder<CreditReport>.CreateNew()
                    .With(x => x.CreditScore = CreditRating.Poor.LowerBoundary).Build);


        Because of = () => response = Subject.GetDecision(Builder<DecisionRequest>.CreateNew().Build());

        It should_decline_the_applicant = () => response.Result.Should().Be(DecisionResult.Declined);

        static DecisionResponse response;
    }
}
