using Lesson_7_PageObject.PageObjects;
using NUnit.Framework;
using System.Threading;

namespace Lesson_7_PageObject.Tests
{
    public class MailTests : BaseTest
    {
        private HomePage _homePage;
        private LoginPage _loginPage;
        private MailPage _mailPage;
        private string userName = "vadim.kuryan.vka";
        private string password = "Vka_6463296";

        [Test]
        public void SendDraftedMailTest()
        {
            _homePage = new HomePage();
            _homePage.GoToLogin();
            _loginPage = new LoginPage();
            _loginPage.SetLogin(userName);
            _loginPage.SetPassword(password);
            _loginPage.SignIn();
            _mailPage = new MailPage();
            _mailPage.WriteNewMail("dragnir@tut.by", "TestSubject", "TestBody");
            _mailPage.SaveMailAsDraft();
            _mailPage.GoToDraftFolder();
            Assert.IsTrue(_mailPage._dratedMail.WebElementExist());
            _mailPage._dratedMail.Click();
            Assert.IsTrue(_mailPage._savedMail.WebElementExist());
            _mailPage._sendMail.Click();
            _mailPage._sendFolder.Click();
            Assert.IsTrue(_mailPage._savedMail.WebElementExist());
        }

        [Test]
        public void WrongPasswordTest()
        {
            _homePage = new HomePage();
            _homePage.GoToLogin();
            _loginPage = new LoginPage();
            _loginPage.SetLogin(userName);
            _loginPage.SetPassword("incorrectPassword");
            _loginPage.SignIn();
            Assert.IsTrue(_loginPage._errorMesage.WebElementExist());
        }

        [Test]
        public void SendMailTest()
        {
            _homePage = new HomePage();
            _homePage.GoToLogin();
            _loginPage = new LoginPage();
            _loginPage.SetLogin(userName);
            _loginPage.SetPassword(password);
            _loginPage.SignIn();
            _mailPage = new MailPage();
            _mailPage.WriteNewMail("dragnir@tut.by", "TestSubject", "TestBody");
            _mailPage._sendMail.ActionClick();
            _mailPage._sendFolder.ActionClick();
            Assert.IsTrue(_mailPage._savedMail.WebElementExist());
        }
    }
}
