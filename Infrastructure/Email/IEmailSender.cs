using System.Threading.Tasks;
namespace feed.Infrastructure.Email
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
        Task SendEmailAsync(EmailMessage message);
    }
}