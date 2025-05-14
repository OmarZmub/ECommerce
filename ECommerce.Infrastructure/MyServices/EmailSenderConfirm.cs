using System.Net;
using System.Net.Mail;
using Castle.Core.Smtp;

namespace ECommerce.MyServices
{
    public class EmailSenderConfirm : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "AhmedE-commerce@outlook.com";
            var fPassword = "ahmed2025ahmed";

            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            var smtpClint = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 587
            };

            smtpClint.Send(theMsg);
        }
        public void Send(string from, string to, string subject, string messageText)
        {
            throw new NotImplementedException();
        }

        public void Send(MailMessage message)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<MailMessage> messages)
        {
            throw new NotImplementedException();
        }
    }
}
