using OpenQA.Selenium;
using SpecFlowProject.Pages;
using SpecFlowProject.Utils;

namespace SpecFlowProject.Steps
{
    public class UserStep : BaseStep
    {
        public UserStep(IWebDriver driver) : base(driver)
        {
        }

        public DashboardPage SuccessfulLogin()
        {
            Login(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);
            return dashboardPage;
        }

        public LoginPage UnsuccessfulLogin(string userName = "", string password = "")
        {
            Login(userName, password);
            return loginPage;
        }
        public void Login(string userName, string password)
        {
            loginPage.UserNameField().SendKeys(userName);
            loginPage.PasswordFeld().SendKeys(password);
            loginPage.LoginButton().Click();
        }
    }
}
