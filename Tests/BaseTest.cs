using Lesson_7_PageObject.WebDriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_PageObject.Tests
{
    public class BaseTest
    {
        protected static Browser Browser;

        [SetUp]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
