using NUnit.Framework;
using SpecFlowProject.Core;
using SpecFlowProject.Pages;
using SpecFlowProject.Steps;
using SpecFlowProject.Utils;


namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefs
    {
        private LoginPage? _loginPage;
        private DashboardPage? _dashboardPage;
        private UserStep? _userStep;

        [BeforeScenario]
        public void BeforeScenario()
        {
            BaseStepDefs.Driver = new Browser().Driver;
            _loginPage = new LoginPage(BaseStepDefs.Driver);
            _dashboardPage = new DashboardPage(BaseStepDefs.Driver);
            _userStep = new UserStep(BaseStepDefs.Driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BaseStepDefs.Driver.Dispose();
        }

        [Given(@"open Login Page")]
        public void OpenLoginPage()
        {
            BaseStepDefs.Driver.Navigate().GoToUrl(Configurator.GetBaseURL());
        }

        [When(@"enter valid user name and password then click Login button")]
        public void EnterValidUserNameAndPasswordThenClickLoginButton()
        {
            _userStep!.SuccessfulLogin();
        }

        [Then(@"Add Project button is displayed")]
        public void AddProjectButtonIsDisplayed()
        {
            Assert.That(_dashboardPage!.AddProjectButton().Displayed);
        }

        [When(@"enter user name '([^']*)' and password '([^']*)' then click Login button")]
        public void EnterUserNameAndPasswordThenClickLoginButton(string userName, string password)
        {
            _userStep!.UnsuccessfulLogin(userName, password);
        }

        [Then(@"error message is equal to '([^']*)'")]
        public void ErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage!.GetPasswordErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }

        [Then(@"top error message is equal to '([^']*)'")]
        public void TopErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage!.GetTopErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }

        [Then(@"login error message is equal to '([^']*)'")]
        public void LoginErrorMessageIsEqualTo(string expectedErrorMessage)
        {
            Assert.That(_loginPage!.GetLoginErrorMessage(), Is.EqualTo(expectedErrorMessage));
        }
    }
}
