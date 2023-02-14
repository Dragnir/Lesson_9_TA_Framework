
namespace Lesson_9_TA_FrameWork.BusinesObject
{
    public class Mail
    {
        private readonly string mailAdress;
        private readonly string subject;
        private readonly string body;

        public string[] DataMail { get; private set; }

        public Mail(string mailAdress, string subject, string body)
        {
            this.mailAdress = mailAdress;
            this.subject = subject;
            this.body = body;

            DataMail = new[] { this.mailAdress, this.subject, this.body };
        }
    }
}
