using OpenQA.Selenium;
using SpecFlowProject.Element;

namespace SpecFlowProject.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By _userNameFieldBy = By.Name("name");
        private static readonly By _userNameErrorMessageBy = By.XPath("//*[@id='name']//ancestor::div[@class='form-group']/following-sibling::div[contains(@class, 'loginpage-message')]");
        private static readonly By _passwordFeldBy = By.Name("password");
        private static readonly By _passwordErrorMessageBy = By.XPath("//*[@class='display-flex']/descendant::div[contains(@class, 'loginpage-message')]");
        private static readonly By _loginButtonBy = By.Id("button_primary");
        private static readonly By _topErrorMessageBy = By.ClassName("error-on-top");
        private static readonly By _loginErrorMessageBy = By.ClassName("error-text");


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public Field UserNameField() => new Field(driver, _userNameFieldBy);
        public string GetUserNameErrorMessage() => new Message(driver, _userNameErrorMessageBy).Text;
        public Field PasswordFeld() => new Field(driver, _passwordFeldBy);
        public string GetPasswordErrorMessage() => new Message(driver, _passwordErrorMessageBy).Text;
        public Button LoginButton() => new Button(driver, _loginButtonBy);
        public string GetTopErrorMessage() => new Message(driver, _topErrorMessageBy).Text;
        public string GetLoginErrorMessage() => new Message(driver, _loginErrorMessageBy).Text;
    }
}
