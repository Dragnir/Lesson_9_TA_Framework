using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly By HomeLnl = By.CssSelector("[class = 'Text Text_typography_headline-l Text_font_wide Text_weight_bold Heading_3bI30R6mTguZO_iUkHjmha']");

        public HomePage() : base(HomeLnl, "Yandex Mail") {}

        private readonly BaseElement _loginButton = new BaseElement(By.XPath("//*[text()='Log in']/ancestor::button"));

        public void GoToLogin()
        {
            _loginButton.Click();
        }
    }
}
