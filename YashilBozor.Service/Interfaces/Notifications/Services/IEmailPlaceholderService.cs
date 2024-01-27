using YashilBozor.Domain.Entities.Notification;

namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailPlaceholderService
{
    ValueTask<(EmailTemplate, Dictionary<string, string>)> GetTemplateValues(Guid userId,
        EmailTemplate template, string code = "");
}
