namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailManagementService
{
    ValueTask<bool> SendEmailAsync(string senderUserEmail, string receieverUserEmail, Guid templateId, string code = "");
    ValueTask<bool> SendEmailAsync(string senderUserEmail, string receieverUserEmail, string templateCategory, string code="");
}