using NLog;
using OpenQA.Selenium;
using SpecFlowProject.Pages;

namespace SpecFlowProject.Steps
{
    public class BaseStep
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected readonly Logger logger = LogManager.GetCurrentClassLogger();
        public BaseStep(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
        }
    }
}
