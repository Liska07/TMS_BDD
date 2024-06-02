using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowProject.Utils;
using NLog;

namespace SpecFlowProject.Pages
{
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        protected IWebDriver driver;
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected BasePage(IWebDriver driver, bool openPageByUrl = false)
        {
            this.driver = driver;
            if (openPageByUrl)
            {
                ExecuteLoad();
                Load();
            }
        }

        public abstract string GetEndpoint();

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl(Configurator.ReadConfiguration().TestRailURL + GetEndpoint());
        }
    }
}
