using System;
using TechTalk.SpecFlow;
using SeleniumPOMUnitTest;

namespace SpecFlowTest
{
    [Binding]
    public class CredentialsSteps
    {
		private UnitTest1 unitTest1 = new UnitTest1();

        [Given(@"I have entered '(.*)' into the userName field")]
        public void GivenIHaveEnteredIntoTheUserNameField(string userName)
        {
			unitTest1.UserNameSpec = userName;
		}
        
        [Given(@"I have entered '(.*)' into the passWord field")]
        public void GivenIHaveEnteredIntoThePassWordField(string passWord)
        {
			unitTest1.PassWordSpec = passWord;
		}
        
        [When(@"I press the log in button")]
        public void WhenIPressTheLogInButton()
        {
			unitTest1.LogInSpec();
		}
        
        [Then(@"I should be able to see my account name '(.*)' on the home page")]
        public void ThenIShouldBeAbleToSeeMyAccountNameOnTheHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
