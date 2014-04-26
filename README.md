# Machine Fakes Cheatsheet

## Examples
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

Intercept the arguments passed into a Mock (using MOQ)

	string input;
    The<IEmailService>().WhenToldTo(x=>x.Send(Param.IsAny<string>)).Callback<string>(y=>input=y);
