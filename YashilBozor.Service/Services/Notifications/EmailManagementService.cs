using YashilBozor.Service.Services.Notifications;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Interfaces.Notifications.Services;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Exceptions;
using YashilBozor.Domain.Entities.Users;
using AutoMapper;

namespace YashilBozor.Service.Services.Notifications;

public class EmailManagementService : IEmailManagementService
{
    private readonly IMapper _mapper;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailPlaceholderService _emailPlaceholderService;
    private readonly IEmailMessageService _emailMessageService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public EmailManagementService(
        IMapper mapper,
        IEmailTemplateService emailTemplateService,
        IEmailPlaceholderService emailPlaceholderService,
        IEmailMessageService emailMessageService,
        IEmailSenderService emailSenderService,
        IEmailService emailService,
    IUserService userService
    )
    {
        _mapper = mapper;
        _emailTemplateService = emailTemplateService;
        _emailPlaceholderService = emailPlaceholderService;
        _emailMessageService = emailMessageService;
        _emailSenderService = emailSenderService;
        _emailService = emailService;
        _userService = userService;
    }

    public async ValueTask<bool> SendEmailAsync(string senderUserEmail, string receieverUserEmail, Guid templateId, string code="")
    {
        Console.WriteLine(templateId);
        var template = await _emailTemplateService.GetByIdAsync(templateId) ?? throw new CustomException(400, "Email template not found");

        var userId = await _userService.GetIdByEmailAddressAsync(receieverUserEmail) ?? throw new CustomException(400, "User not found");

        var placeholders = await _emailPlaceholderService.GetTemplateValues(userId, template);


        var message = await _emailMessageService.ConvertToMessage(placeholders.Item1, placeholders.Item2, senderUserEmail, receieverUserEmail);
        var result = await _emailSenderService.SendEmailAsync(message);
        var email = _mapper.Map<Email>(message);
        email.IsSent = result;
        await _emailService.CreateAsync(email);
        return result;
    }

    public async ValueTask<bool> SendEmailAsync(string senderUserEmail, string receieverUserEmail, string templateCategory, string code = "")
    {
        var template = _emailTemplateService.Get(getTemplate => getTemplate.Subject.Equals(templateCategory)).FirstOrDefault();//?? throw new InvalidOperationException();

        Console.WriteLine(template is null);

        var userId = await _userService.GetIdByEmailAddressAsync(receieverUserEmail) ?? throw new CustomException(400, "User not found");

        var placeholders = await _emailPlaceholderService.GetTemplateValues(userId, template, code);


        var message = await _emailMessageService.ConvertToMessage(placeholders.Item1, placeholders.Item2, senderUserEmail, receieverUserEmail);
        var result = await _emailSenderService.SendEmailAsync(message);
        var email = _mapper.Map<Email>(message);
        email.IsSent = result;
        await _emailService.CreateAsync(email);
        return result;
    }

}