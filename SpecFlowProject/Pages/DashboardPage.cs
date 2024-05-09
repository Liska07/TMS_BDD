using OpenQA.Selenium;
using SpecFlowProject.Element;

namespace SpecFlowProject.Pages
{
    public class DashboardPage : BasePage
    {
        private static readonly By _addProjectButtonBy = By.Id("sidebar-projects-add");
        private string _endPoint = "index.php?/dashboard";

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public Button AddProjectButton() => new Button(driver, _addProjectButtonBy);
        public override string GetEndpoint()
        {
            return _endPoint;
        }
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                return AddProjectButton().Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
