# Cheat Sheet

**Nuget Packages**

	PM>install-package machine.fakes.moq
	PM>install-package FluentAssertions
	PM>install-package NBuilder

**Vanilla Machine.Specifications**
```csharp
[Subject("CreditDecisionService")]
class when_the_applicant_has_excellent_credit
{
	Establish context = () =>
    {
    	sut = new CreditDecisionService();
    };
    Because of = () => response = sut.GetDecision(decisionRequest);

    It should_approve_the_applicant = () =>
			response.Result.Should().Be(DecisionResult.Approved);

    static CreditDecisionService sut;
    static DecisionResponse response;
    static DecisionRequest decisionRequest;
}
```

**Example of a test using Machine.Fakes**
```csharp
class when_the_applicant_has_excellent_credit :
	WithSubject<CreditDecisionService>
{
Establish context = () =>
	The<ICreditReportService>().WhenToldTo(x => x
	.CheckCreditHistory(Param.IsAny<CreditCardApplication>()))
	.Return(Builder<CreditReport>.CreateNew()
	.With(x => x.CreditScore
	CreditRating.Excellent.LowerBoundary).Build);

Because of = () =>
	response = Subject.GetDecision(
	Builder<CreditCardApplication>.CreateNew().Build());

It should_approve_the_applicant = () =>
	response.Result.Should().Be(DecisionResult.Approved);

static DecisionResponse response;
}
```

**Specify the subject under test**
```csharp
class when_expired_card_was_detected : WithSubject<CardUpdaterService>
```

**Verify a method gets called on a mock**
```csharp
It should_validate_the_card = () =>
The<IApiWrapper>().WasToldTo(x => x.IsCardValid(card)).OnlyOnce();
```

**Act**
```csharp
Because of = () => Subject.DoSomething();
```

**Set a return value on a fake object**
```csharp
The<IApiWrapper>().WhenToldTo(x => x.IsCardValid(card)).Return(true);
```

**Replace one of the auto-mocked dependencies with a real concrete type**
```csharp
Configure(x=>x.For<ICardUpdater>().Use<CardUpdater>());
```
**Use NBuilder in your arrangement to create more expressive tests**
```csharp
var address = Builder<Address>.CreateNew()
    .With(x => x.Street = "123 Main St")
    .With(x => x.City = "Dallas")
    .With(x => x.State = "TX").Build();
```

**Use NBuilder to quickly generate a list with some common values**
```csharp
Builder<Address>.CreateListOfSize(10).All()
 	.With(x => x.City = "Dallas")
    .With(x => x.State = "TX").Build();
```

**Intercept the arguments passed into a Mock (using MOQ)**
```csharp
string input;
The<IEmailService>().WhenToldTo(x=>x.Send(Param.IsAny<string>))
	.Callback<string>(y=>input=y);
```

**Get direct access to the underlying mock object and verify a property using MOQ**
```csharp
It should_set_the_burn_device = () =>
	Mock.Get(The<IBurner>())
	.VerifySet(x => x.BurnDevice = device);
```

**Verify property was set using Machine.Fakes (preferred over the method above)**
```csharp
It should_set_the_burn_device = () =>
	The<IBurner>()
	.BurnDevice.ShouldBe(device);
```
**Force a fake to throw an exception**
```csharp
	The<IApiWrapper>().WhenToldTo(x => x.DoSomething())
    .Throw(new Exception("Kaboom!"));
```
**Verify a method was not called**
```csharp
It should_not_lookup_the_applicants_credit_score = () =>
	The<ICreditReportService>()
    .WasNotToldTo(x => x
		.CheckCreditHistory(Param.IsAny<CreditCardApplication>()));
```
**Verify a method was only called once**
```csharp
It should_lookup_the_applicants_credit_score = () =>
	The<ICreditReportService>()
	.WasToldTo(x => x.CheckCreditHistory(Param.IsAny<CreditCardApplication>()))
	.OnlyOnce();
```
**Get at the underlying mock and raise an event when a method is called on the mock**

``` csharp
Mock.Get(The<IBurner>()).Setup(x => x.Burn())
	.Callback(() => Mock.Get(The<IBurner>())
    .Raise(d => d.BurnCompleted += null, new BurnDoneEventArgs("done")));
```

**Use AutoFixture to create deep object graphs**
```csharp
var fixture = new Fixture();
fixture.Behaviors.Add(new OmitOnRecursionBehavior());
_config = fixture.Create<FooConfiguration>();
```
