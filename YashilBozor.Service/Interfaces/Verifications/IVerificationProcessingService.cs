namespace YashilBozor.Service.Interfaces.Verifications;

public interface IVerificationProcessingService
{
    ValueTask<bool> Verify(string code, CancellationToken cancellationToken);
}
