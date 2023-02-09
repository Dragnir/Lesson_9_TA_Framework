using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_PageObject.WebDriver
{
    public class Browser
    {
        private static Browser currentInstance;
        private static IWebDriver driver;
        public static BrowserFactory.BrowserType currentBrowser;
        public static int ImplWait;
        public static double timeoutForElement;
        private static string browser;

        private Browser()
        {
            InitParams();
            driver = BrowserFactory.GetDriver(currentBrowser, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            browser = Configuration.Browser;
            Enum.TryParse(browser, out currentBrowser);
        }

        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());

        public static void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void Quit()
        {
            driver.Quit();
            currentInstance = null;
            driver = null;
            browser = null;
        }
    }
}
