using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace feed.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConf _emailConf;

        public EmailSender(EmailConf emailConf)
        {
            _emailConf = emailConf;
        }

        private MimeMessage CreateMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.To.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.From.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Body
            };

            return message;
        }

        public void SendEmail(EmailMessage emailMessage)
        {
            var message = CreateMessage(emailMessage);
        
            using var emailClient = new SmtpClient();
            emailClient.Connect(_emailConf.SmtpServer, _emailConf.Port, SecureSocketOptions.StartTls);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.Authenticate(_emailConf.Username, _emailConf.Password);
            emailClient.Send(message);
            emailClient.Disconnect(true);
            emailClient.Dispose();
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var message = CreateMessage(emailMessage);

            using var emailClient = new SmtpClient();
            await emailClient.ConnectAsync(_emailConf.SmtpServer, _emailConf.Port, SecureSocketOptions.StartTls);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            await emailClient.AuthenticateAsync(_emailConf.Username, _emailConf.Password);
            await emailClient.SendAsync(message);
            await emailClient.DisconnectAsync(true);
            emailClient.Dispose();
        }
    }
}