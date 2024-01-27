namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailManagementService
{
    ValueTask<bool> SendEmailAsync(Guid userId, Guid templateId);

    ValueTask<bool> SendEmailAsync(Guid userId, string templateCategory);
}