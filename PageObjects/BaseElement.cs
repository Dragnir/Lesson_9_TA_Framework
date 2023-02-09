using Lesson_7_PageObject.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Lesson_7_PageObject.PageObjects
{
    public class BaseElement : IWebElement
    {
        private IWebDriver driver = Browser.GetDriver();
        protected string name;
        protected By locator;
        protected IWebElement element;

        public BaseElement(By locator, string name)
        {
            this.locator = locator;
            this.name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return element.Text;
        }

        public IWebElement GetWebElement()
        {
            return element = Browser.GetDriver().FindElement(locator);
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                var elementToBeDisplayed = driver.FindElement(locator);
                return elementToBeDisplayed.Displayed;
            });
        }

        public void WebElementClickable()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool WebElementExist()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator)).Enabled; 
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(locator).Click();
        }

        public void ActionClick()
        {
            WaitForIsVisible();
            new Actions(driver).Click(this.GetWebElement()).Build().Perform();
        }

        public void ActionSendKeys(string text)
        {
            WaitForIsVisible();
            new Actions(driver).SendKeys(this.GetWebElement(), text).Build().Perform();
        }

        public void JsClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", this.GetWebElement());
        }

        public void JsHighlightElement()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", this.GetWebElement());
        }


        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();
    }
}
