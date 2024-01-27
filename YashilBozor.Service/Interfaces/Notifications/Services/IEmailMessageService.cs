﻿using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Services.Notifications.Models;

namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailMessageService
{
    ValueTask<EmailMessage> ConvertToMessage(EmailTemplate template, Dictionary<string, string> values, string sender,
        string receiver);
}