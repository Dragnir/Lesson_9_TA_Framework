using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By LoginLnl = By.ClassName("passp-add-account-page-title");

        public LoginPage() : base(LoginLnl, "Log in with Yandex ID to access Yandex.Mail") {}

        private readonly BaseElement _loginField = new BaseElement(By.CssSelector("[name = 'login']"));
        private readonly BaseElement _setPassword = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        private readonly BaseElement _signIn = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        public BaseElement _passwordField = new BaseElement(By.XPath("//*[@id='passp-field-passwd']"));
        public BaseElement _errorMesage = new BaseElement(By.XPath("//*[text()='Incorrect password']"));

        public void SetLogin(string loginName)
        {
            _loginField.JsHighlightElement();
            _loginField.SendKeys(loginName);
        }

        public void SetPassword(string loginName)
        {
            _setPassword.Click();
            _passwordField.WaitForIsVisible();
            _passwordField.SendKeys(loginName);
        }

        public void SignIn()
        {
            _signIn.JsHighlightElement();
            _signIn.Click();
        }
    }
}
