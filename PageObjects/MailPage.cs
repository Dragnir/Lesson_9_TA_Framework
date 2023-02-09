using OpenQA.Selenium;

namespace Lesson_7_PageObject.PageObjects
{
    public class MailPage : BasePage
    {
        private static readonly By LoginLnl = By.XPath("//*[@class='mail-App-Footer-Item']");

        public MailPage() : base(LoginLnl, "© 2001—2023, ") {}

        private readonly BaseElement _userAccount = new BaseElement(By.CssSelector("[class = 'user-account__name']"));
        private readonly BaseElement _writeNewMail = new BaseElement(By.CssSelector("[class = 'Button2 Button2_type_link Button2_view_action Button2_size_m Layout-m__compose--pTDsx qa-LeftColumn-ComposeButton ComposeButton-m__root--fP-o9']"));
        private readonly BaseElement _addressField = new BaseElement(By.XPath("//*[@id='compose-field-1']"));
        private readonly BaseElement _subject = new BaseElement(By.XPath("//*[@id='compose-field-subject-4']"));
        private readonly BaseElement _body = new BaseElement(By.XPath("//*[@id='cke_1_contents']/div"));
        private readonly BaseElement _saveAsDraft = new BaseElement(By.XPath("//*[@class='Button2-Icon new__icon--1nFOX']/ancestor::button"));
        private readonly BaseElement _sendToday = new BaseElement(By.XPath("//*[@class='ComposeTimeOptions-Label']"));
        private readonly BaseElement _closeMail = new BaseElement(By.XPath("//*[@class='Button2 Button2_view_clear Button2_size_xs ControlButtons__root--3tqjs qa-ControlButton qa-ControlButton_button_close']"));
        private readonly BaseElement _draftFolder = new BaseElement(By.XPath("//a[@href='#draft']"));
        private readonly BaseElement _refresh = new BaseElement(By.XPath("//button[@aria-describedby='tooltip-0-2']"));
        public BaseElement _dratedMail = new BaseElement(By.XPath("//*[@title='TestSubject']"));
        public BaseElement _savedMail = new BaseElement(By.XPath("//*[text()='TestBody']"));
        public BaseElement _sendMail = new BaseElement(By.XPath("//button[@aria-disabled='false']"));
        public BaseElement _sendFolder = new BaseElement(By.XPath("//a[@href='#sent']"));
        
        public string GetAccountName()
        {
            return _userAccount.Text;
        }

        public void WriteNewMail(string address, string subject, string body)
        {
            _writeNewMail.Click();
            _addressField.SendKeys(address);
            _subject.WebElementExist();
            _subject.SendKeys(subject);
            _body.SendKeys(body);
        }

        public void SaveMailAsDraft()
        {
            _saveAsDraft.Click();
            _sendToday.WebElementClickable();
            _sendToday.JsClick();
            _closeMail.Click();
        }

        public void GoToDraftFolder()
        {
            _draftFolder.Click();
            _refresh.Click();
        }
    }
}
