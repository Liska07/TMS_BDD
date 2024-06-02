using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SpecFlowProject.Pages;
using SpecFlowProject.Steps;


namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefs
    {
        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;
        private UserStep _userStep;

        [BeforeScenario]
        public void BeforeScenario()
        {
            BaseStepDefs.Driver = new ChromeDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BaseStepDefs.Driver.Dispose();
        }

        [Given(@"open Login Page")]
        public void OpenLoginPage()
        {
            _loginPage = new LoginPage(BaseStepDefs.Driver, true);
        }

        [When(@"enter valid user name and password then click Login button")]
        public void EnterValidUserNameAndPasswordThenClickLoginButton()
        {
            _userStep = new UserStep(BaseStepDefs.Driver);
            _userStep.SuccessfulLogin();
        }

        [Then(@"Add Project button is displayed")]
        public void AddProjectButtonIsDisplayed()
        {
            _dashboardPage = new DashboardPage(BaseStepDefs.Driver);
            Assert.That(_dashboardPage.AddProjectButton().Displayed);
        }

        [When(@"enter user name '([^']*)' and password '([^']*)' then click Login button")]
        public void EnterUserNameAndPasswordThenClickLoginButton(string userName, string password)
        {
            _userStep = new UserStep(BaseStepDefs.Driver);
            _userStep.UnsuccessfulLogin(userName, password);
        }

        [Then(@"error message is equal to '([^']*)'")]
        public void ErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage.GetPasswordErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }

        [Then(@"top error message is equal to '([^']*)'")]
        public void TopErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage.GetTopErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }

        [Then(@"login error message is equal to '([^']*)'")]
        public void LoginErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage.GetLoginErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }
    }
}
