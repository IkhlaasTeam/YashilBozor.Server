using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Enums;

namespace YashilBozor.Domain.Entities.Users;

public class VerificationCode : Auditable
{
    public VerificationCodeType CodeType { get; set; }
    public VerificationType Type { get; set; }
    public DateTimeOffset ExpiryTime { get; set; }
    public bool IsActive { get; set; }
    public string Code { get; set; }
    public string VerificationLink { get; set; }
}
