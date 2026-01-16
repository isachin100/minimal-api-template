using application.domain.Entities.User;

namespace application.application.Abstractions.Services
{
    public interface IEmailSender
    {
        Task SendAsync(Email to, string subject, string body);
    }
}
