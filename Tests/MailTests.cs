using Lesson_7_PageObject.PageObjects;
using NUnit.Framework;
using System.Threading;

namespace Lesson_7_PageObject.Tests
{
    public class MailTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private MailPage mailPage;
        private string userName = "vadim.kuryan.vka";
        private string password = "Vka_6463296";

        [Test]
        public void SendDraftedMailTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.SetLogin(userName);
            loginPage.SetPassword(password);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail("dragnir@tut.by", "TestSubject", "TestBody");
            mailPage.SaveMailAsDraft();
            mailPage.GoToDraftFolder();
            Assert.IsTrue(mailPage.dratedMail.WebElementExist());
            mailPage.dratedMail.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
            mailPage.sendMail.Click();
            mailPage.sendFolder.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }

        [Test]
        public void WrongPasswordTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.SetLogin(userName);
            loginPage.SetPassword("incorrectPassword");
            loginPage.SignIn();
            Assert.IsTrue(loginPage.errorMesage.WebElementExist());
        }

        [Test]
        public void SendMailTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.SetLogin(userName);
            loginPage.SetPassword(password);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail("dragnir@tut.by", "TestSubject", "TestBody");
            mailPage.sendMail.ActionClick();
            mailPage.sendFolder.ActionClick();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }
    }
}
