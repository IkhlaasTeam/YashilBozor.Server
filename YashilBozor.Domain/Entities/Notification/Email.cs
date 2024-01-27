using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Notification;

public class Email : Auditable
{
    public string SenderAddress { get; set; }
    public string ReceiverAddress { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTimeOffset SentTime { get; set; }
    public bool IsSent { get; set; }
}