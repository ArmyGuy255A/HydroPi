using System.Threading.Tasks;

namespace HydroPi.Mailing
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
