using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class BasePage
    {
        protected By titleLocator;
        protected string title;
        public static string titleForm;

        protected BasePage(By TitleLocator, string title)
        {
            titleLocator = TitleLocator;
            this.title = titleForm = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(titleLocator, title);
            label.WaitForIsVisible();
        }

    }
}
