using YashilBozor.Service.Services.Notifications.Models;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Interfaces.Notifications.Services;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Exceptions;

namespace YashilBozor.Service.Services.Notifications.Services;

public class EmailManagementService : IEmailManagementService
{
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailPlaceholderService _emailPlaceholderService;
    private readonly IEmailMessageService _emailMessageService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public EmailManagementService(
        IEmailTemplateService emailTemplateService,
        IEmailPlaceholderService emailPlaceholderService,
        IEmailMessageService emailMessageService,
        IEmailSenderService emailSenderService,
        IEmailService emailService,
    IUserService userService
    )
    {
        _emailTemplateService = emailTemplateService;
        _emailPlaceholderService = emailPlaceholderService;
        _emailMessageService = emailMessageService;
        _emailSenderService = emailSenderService;
        _emailService = emailService;
        _userService = userService;
    }

    public async ValueTask<bool> SendEmailAsync(Guid userId, Guid templateId)
    {
        Console.WriteLine(templateId);
        var template = await _emailTemplateService.GetByIdAsync(templateId) ?? throw new CustomException(400, "Email template not found");
        var placeholders = await _emailPlaceholderService.GetTemplateValues(userId, template);

        var user = await _userService.GetByIdAsync(userId) ?? throw new CustomException(400, "User not found");
        
        var appEmailAddress = "sultonbek.rakhimov@gmail.com";

        var message = await _emailMessageService.ConvertToMessage(placeholders.Item1, placeholders.Item2, appEmailAddress, user.EmailAddress);
        var result = await _emailSenderService.SendEmailAsync(message);
        var email = ToEmail(message);
        email.IsSent = result;
        await _emailService.CreateAsync(email);
        return result;
    }

    public async ValueTask<bool> SendEmailAsync(Guid userId, string templateCategory)
    {
        var template = _emailTemplateService.Get(getTemplate => getTemplate.Subject.Equals(templateCategory)).FirstOrDefault() ?? throw new InvalidOperationException();
        var placeholders = await _emailPlaceholderService.GetTemplateValues(userId, template);

        var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        var appEmailAddress = "sultonbek.rakhimov@gmail.com";

        var message = await _emailMessageService.ConvertToMessage(placeholders.Item1, placeholders.Item2, appEmailAddress, user.EmailAddress);
        var result = await _emailSenderService.SendEmailAsync(message);
        var email = ToEmail(message);
        email.IsSent = result;
        await _emailService.CreateAsync(email);
        return result;
    }

    private Email ToEmail(EmailMessage message)
    {
        return new Email()
        {
            SenderAddress = message.SenderAddress,
            ReceiverAddress = message.ReceiverAddress,
            Subject = message.Subject,
            Body = message.Body,
            SentTime = message.SentTime
        };
    }
}