﻿using OpenQA.Selenium;
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
        private string _endPoint = "";

        public LoginPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
        }
        public UiElement UserNameField() => new UiElement(driver, _userNameFieldBy);
        public string GetUserNameErrorMessage() => new Message(driver, _userNameErrorMessageBy).Text.Trim();
        public UiElement PasswordFeld() => new UiElement(driver, _passwordFeldBy);
        public string GetPasswordErrorMessage() => new Message(driver, _passwordErrorMessageBy).Text.Trim();
        public Button LoginButton() => new Button(driver, _loginButtonBy);
        public string GetTopErrorMessage() => new Message(driver, _topErrorMessageBy).Text.Trim();
        public string GetLoginErrorMessage() => new Message(driver, _loginErrorMessageBy).Text.Trim();

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                return LoginButton().Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
