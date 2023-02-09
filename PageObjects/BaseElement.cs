﻿using Lesson_7_PageObject.WebDriver;
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
        private IWebDriver _driver = Browser.GetDriver();
        protected string _name;
        protected By _locator;
        protected IWebElement _element;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return _element.Text;
        }

        public IWebElement GetWebElement()
        {
            return _element = Browser.GetDriver().FindElement(_locator);
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                var elementToBeDisplayed = _driver.FindElement(_locator);
                return elementToBeDisplayed.Displayed;
            });
        }

        public void WebElementClickable()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_locator));
        }

        public bool WebElementExist()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(_locator)).Enabled; 
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void ActionClick()
        {
            WaitForIsVisible();
            new Actions(_driver).Click(this.GetWebElement()).Build().Perform();
        }

        public void ActionSendKeys(string text)
        {
            WaitForIsVisible();
            new Actions(_driver).SendKeys(this.GetWebElement(), text).Build().Perform();
        }

        public void JsClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", this.GetWebElement());
        }

        public void JsHighlightElement()
        {
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", this.GetWebElement());
        }


        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
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
