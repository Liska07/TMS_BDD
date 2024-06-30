using OpenQA.Selenium;
using SpecFlowProject.Utils;

namespace SpecFlowProject.Steps
{
    public class UserStep : BaseStep
    {
        public UserStep(IWebDriver driver) : base(driver)
        {
        }

        public void SuccessfulLogin()
        {
            Login(EnvironmentHelper.GetEnvironmentVariableOrThrow("TESTRAIL_USERNAME"),
                EnvironmentHelper.GetEnvironmentVariableOrThrow("TESTRAIL_PASSWORD"));
            logger.Info("Successful login");
        }

        public void UnsuccessfulLogin(string userName = "", string password = "")
        {
            Login(userName, password);
        }

        private void Login(string userName, string password)
        {
            loginPage.UserNameField().SendKeys(userName);
            loginPage.PasswordFeld().SendKeys(password);
            loginPage.LoginButton().Click();
        }
    }
}
