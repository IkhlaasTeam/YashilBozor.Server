using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using YashilBozor.Service.Commons.Settings;
using YashilBozor.Service.Interfaces.Notifications.Services;
using YashilBozor.Service.Models;

namespace YashilBozor.Service.Services.Notifications;

public class EmailSenderService(IOptions<SmtpSettings> options) : IEmailSenderService
{
    public SmtpClient SmtpClientInstance { get; init; }

    public Task<bool> SendEmailAsync(EmailMessage emailMessage)
    {
        return Task.Run(async () =>
        {
            var result = true;
            try
            {
                var smtp = new SmtpClient(options.Value.Host, options.Value.Port);
                smtp.Credentials = new NetworkCredential(options.Value.UserName, options.Value.Password);
                smtp.EnableSsl = true;

                var mail = new MailMessage(options.Value.EmailAddress, emailMessage.ReceiverAddress);
                mail.Subject = emailMessage.Subject;
                mail.Body = emailMessage.Body;

                emailMessage.IsSent = result;
                emailMessage.SentTime = DateTime.UtcNow;

                await smtp.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        });
    }
}
