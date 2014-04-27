using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardServices.Core.Models;
using FluentAssertions;
using Machine.Fakes;
using Machine.Specifications;

namespace CreditCardServices.Tests.DecisionService
{
    class when_user_has_credit_score_of_500 : WithSubject<CreditRating>
    {
        It should_be_considered_very_poor = () => CreditRating.FromScore(500).Should().Be(CreditRating.VeryPoor);
    }
    class when_user_has_credit_score_of_580 : WithSubject<CreditRating>
    {
        It should_be_considered_very_poor = () => CreditRating.FromScore(580).Should().Be(CreditRating.Poor);
    }
    class when_user_has_credit_score_of_620 : WithSubject<CreditRating>
    {
        It should_be_considered_very_poor = () => CreditRating.FromScore(620).Should().Be(CreditRating.Fair);
    }

    class when_user_has_credit_score_of_660 : WithSubject<CreditRating>
    {
        It should_be_considered_good = () => CreditRating.FromScore(660).Should().Be(CreditRating.Good);
    }

    class when_user_has_credit_score_of_700 : WithSubject<CreditRating>
    {
        It should_be_considered_very_good = () => CreditRating.FromScore(700).Should().Be(CreditRating.VeryGood);
    }

    class when_user_has_credit_score_of_760 : WithSubject<CreditRating>
    {
        It should_be_considered_excellent = () => CreditRating.FromScore(760).Should().Be(CreditRating.Excellent);
    }
   
}
