using YashilBozor.Domain.Enums;

namespace YashilBozor.Service.Interfaces.Verifications;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
