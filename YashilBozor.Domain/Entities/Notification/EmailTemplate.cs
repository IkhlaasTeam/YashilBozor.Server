using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Notification;

public class EmailTemplate : Auditable
{
    public string Subject { get; set; }

    public string Body { get; set; }

    public EmailTemplate()
    {
    }

    public EmailTemplate(string subject, string body)
    {
        Subject = subject;
        Body = body;
    }
}