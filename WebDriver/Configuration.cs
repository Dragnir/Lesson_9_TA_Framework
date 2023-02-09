using System.Configuration;

namespace Lesson_7_PageObject.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");

        public static string Browser => GetEnvironmentVar("Browser", "Chrome");

        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://mail.yandex.com");
    }
}
