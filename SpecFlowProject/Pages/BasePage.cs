using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
