using System.Text;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Interfaces.Notifications.Services;
using YashilBozor.Service.Models;

namespace YashilBozor.Service.Services.Notifications
{
    public class EmailMessageService : IEmailMessageService
    {
        public ValueTask<EmailMessage> ConvertToMessage(EmailTemplate template, Dictionary<string, string> values, string sender, string receiver)
        {
            var body = new StringBuilder(template.Body);


            foreach (var item in values)
            {
                body = body.Replace(item.Key, item.Value);
            }

            var emailMessage = new EmailMessage(sender, receiver, template.Subject, body.ToString());
            return ValueTask.FromResult(emailMessage);
        }
    }
}
