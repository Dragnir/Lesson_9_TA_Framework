using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Lesson_7_PageObject.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            remoteFirefox,
            remoteChrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("no-sandbox");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }

                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var option = new FirefoxOptions();
                        option.AddArgument("--start-maximized");
                        option.AddArgument("disable-infobars");
                        option.SetPreference("intl.accept_languages", "locale-of-choice");
                        service.HideCommandPromptWindow = true;
                        driver = new FirefoxDriver(service, option, TimeSpan.FromSeconds(220));
                        break;
                    }
                case BrowserType.remoteFirefox:
                    {
                        var option = new FirefoxOptions();
                        option.BrowserExecutableLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
                        option.AddArgument("--start-maximized");
                        option.AddArgument("disable-infobars");
                        option.AddArguments("headless");
                        option.SetPreference("security.sandbox.content.level", 5);
                        option.AcceptInsecureCertificates = true;
                        option.PlatformName = "Windows 10";
                        option.BrowserVersion = "109.0.1";

                        option.SetPreference("intl.accept_languages", "locale-of-choice");
                        driver = new RemoteWebDriver(new Uri("http://192.168.100.3:4444"), option.ToCapabilities(), TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.remoteChrome:
                    {
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444"), option.ToCapabilities());
                        break;
                    }
            }

            return driver;

        }
    }
}
