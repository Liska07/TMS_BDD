using OpenQA.Selenium;
using SpecFlowProject.Element;

namespace SpecFlowProject.Pages
{
    public class DashboardPage : BasePage
    {
        private static readonly By _addProjectButtonBy = By.Id("sidebar-projects-add");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public Button AddProjectButton() => new Button(driver, _addProjectButtonBy);
    }
}
