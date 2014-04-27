# Cheat Sheet

*Vanilla Machine.Specifications*

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
Specify the subject under test

	public class when_expired_card_was_detected : WithSubject<CardUpdaterService> 

Verify a method gets called on a mock:

   	It should_validate_the_card = () => The<IApiWrapper>().WasToldTo(x => x.IsCardValid(card)).OnlyOnce();

Act

	Because of = () => Subject.DoSomething();

Set a return value on a fake object

	The<IApiWrapper>().WhenToldTo(x => x.IsCardValid(card)).Return(true);

Replace one of the auto-mocked dependencies with a real concrete type.

	Configure(x=>x.For<ICardUpdater>().Use<CardUpdater>());

Use NBuilder in your arrangement to create more expressive tests

	Establish context = () =>
      {      
         The<IBurner>().WhenToldTo(x => x.GetMediumInfo()).Return(Builder<MediumInfo>.CreateNew()
            .With(x => x.FreeSize = 4201929393D)
            .With(x => x.TypeCode = MediumType.DvdPlusRw)
            .With(x=> x.Status = MediumStatus.EmptyDisk)
            .Build()
            );
      };

Intercept the arguments passed into a Mock (using MOQ)

	string input;
    The<IEmailService>().WhenToldTo(x=>x.Send(Param.IsAny<string>)).Callback<string>(y=>input=y);
