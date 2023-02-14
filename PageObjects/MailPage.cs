using Lesson_9_TA_FrameWork.BusinesObject;
using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class MailPage : BasePage
    {
        private static readonly By LoginLnl = By.XPath("//*[@class='mail-App-Footer-Item']");

        public MailPage() : base(LoginLnl, "© 2001—2023, ") {}

        private readonly BaseElement userAccount = new BaseElement(By.CssSelector("[class = 'user-account__name']"));
        private readonly BaseElement writeNewMail = new BaseElement(By.CssSelector("[class = 'Button2 Button2_type_link Button2_view_action Button2_size_m Layout-m__compose--pTDsx qa-LeftColumn-ComposeButton ComposeButton-m__root--fP-o9']"));
        private readonly BaseElement addressField = new BaseElement(By.XPath("//*[@id='compose-field-1']"));
        private readonly BaseElement subject = new BaseElement(By.XPath("//*[@id='compose-field-subject-4']"));
        private readonly BaseElement body = new BaseElement(By.XPath("//*[@id='cke_1_contents']/div"));
        private readonly BaseElement saveAsDraft = new BaseElement(By.XPath("//*[@class='Button2-Icon new__icon--1nFOX']/ancestor::button"));
        private readonly BaseElement sendToday = new BaseElement(By.XPath("//*[@class='ComposeTimeOptions-Label']"));
        private readonly BaseElement closeMail = new BaseElement(By.XPath("//*[@class='Button2 Button2_view_clear Button2_size_xs ControlButtons__root--3tqjs qa-ControlButton qa-ControlButton_button_close']"));
        private readonly BaseElement draftFolder = new BaseElement(By.XPath("//a[@href='#draft']"));
        private readonly BaseElement refresh = new BaseElement(By.XPath("//button[@aria-describedby='tooltip-0-2']"));
        public BaseElement dratedMail = new BaseElement(By.XPath("//*[@title='TestSubject']"));
        public BaseElement savedMail = new BaseElement(By.XPath("//*[text()='TestBody']"));
        public BaseElement sendMail = new BaseElement(By.XPath("//button[@aria-disabled='false']"));
        public BaseElement sendFolder = new BaseElement(By.XPath("//a[@href='#sent']"));
        
        public string GetAccountName()
        {
            return userAccount.Text;
        }

        public void WriteNewMail(Mail mail)
        {
            writeNewMail.Click();
            addressField.SendKeys(mail.DataMail[0]);
            this.subject.WebElementExist();
            this.subject.SendKeys(mail.DataMail[1]);
            this.body.SendKeys(mail.DataMail[2]);
        }

        public void SaveMailAsDraft()
        {
            saveAsDraft.Click();
            sendToday.WebElementClickable();
            sendToday.JsClick();
            closeMail.Click();
        }

        public void GoToDraftFolder()
        {
            draftFolder.Click();
            refresh.Click();
        }
    }
}
