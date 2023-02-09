using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By LoginLnl = By.ClassName("passp-add-account-page-title");

        public LoginPage() : base(LoginLnl, "Log in with Yandex ID to access Yandex.Mail") {}

        private readonly BaseElement loginField = new BaseElement(By.CssSelector("[name = 'login']"));
        private readonly BaseElement setPassword = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        private readonly BaseElement signIn = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        public BaseElement passwordField = new BaseElement(By.XPath("//*[@id='passp-field-passwd']"));
        public BaseElement errorMesage = new BaseElement(By.XPath("//*[text()='Incorrect password']"));

        public void SetLogin(string loginName)
        {
            loginField.JsHighlightElement();
            loginField.SendKeys(loginName);
        }

        public void SetPassword(string loginName)
        {
            setPassword.Click();
            passwordField.WaitForIsVisible();
            passwordField.SendKeys(loginName);
        }

        public void SignIn()
        {
            signIn.JsHighlightElement();
            signIn.Click();
        }
    }
}
