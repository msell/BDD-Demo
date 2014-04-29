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

Example of a test using Machine.Fakes

```csharp
class when_the_applicant_has_excellent_credit : WithSubject<CreditDecisionService>
{
    Establish context = () =>
	    The<ICreditReportService>().WhenToldTo(x => x
	    .CheckCreditHistory(Param.IsAny<CreditCardApplication>()))
	    .Return(Builder<CreditReport>.CreateNew()
	    .With(x => x.CreditScore = CreditRating.Excellent.LowerBoundary).Build);

	Because of = () => 
		response = Subject.GetDecision(
			Builder<CreditCardApplication>.CreateNew().Build());

	It should_approve_the_applicant = () => 
		response.Result.Should().Be(DecisionResult.Approved);

	static DecisionResponse response;
}
```

Specify the subject under test

	class when_expired_card_was_detected : WithSubject<CardUpdaterService> 

Verify a method gets called on a mock:

   	It should_validate_the_card = () => The<IApiWrapper>().WasToldTo(x => x.IsCardValid(card)).OnlyOnce();

Act

	Because of = () => Subject.DoSomething();

Set a return value on a fake object

	The<IApiWrapper>().WhenToldTo(x => x.IsCardValid(card)).Return(true);

Replace one of the auto-mocked dependencies with a real concrete type.

	Configure(x=>x.For<ICardUpdater>().Use<CardUpdater>());

Use NBuilder in your arrangement to create more expressive tests
      
	var address = Builder<Address>.CreateNew()
                .With(x => x.Street = "123 Main St")
                .With(x => x.City = "Dallas")
                .With(x => x.State = "TX").Build();
     

Use NBuilder to quickly generate a list with some common values

	Builder<Address>.CreateListOfSize(10).All()
                .With(x => x.City = "Dallas")
                .With(x => x.State = "TX").Build();

Intercept the arguments passed into a Mock (using MOQ)

	string input;
    The<IEmailService>().WhenToldTo(x=>x.Send(Param.IsAny<string>)).Callback<string>(y=>input=y);

Get direct access to the underlying mock object and verify a property using MOQ

	It should_set_the_burn_device = () => Mock.Get(The<IBurner>()).VerifySet(x => x.BurnDevice = device);

Verify property was set using Machine.Fakes (preferred over the method above)

	It should_set_the_burn_device = () => The<IBurner>().BurnDevice.ShouldBe(device);

Force a fake to throw an exception

	The<IApiWrapper>().WhenToldTo(x => x.DoSomething())
    	.Throw(new Exception("Kaboom!"));

Verify a method was not called

	It should_not_lookup_the_applicants_credit_score = () => The<ICreditReportService>()
            .WasNotToldTo(x => x.CheckCreditHistory(Param.IsAny<CreditCardApplication>()));

Verify a method was only called once

	It should_lookup_the_applicants_credit_score = () => The<ICreditReportService>()
            .WasToldTo(x => x.CheckCreditHistory(Param.IsAny<CreditCardApplication>())).OnlyOnce();
