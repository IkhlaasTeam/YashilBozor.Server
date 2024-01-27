using YashilBozor.Service.Services.Notifications.Models;

namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailSenderService
{
    Task<bool> SendEmailAsync(EmailMessage emailMessage);
}
