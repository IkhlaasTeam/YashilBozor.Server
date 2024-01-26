namespace YashilBozor.Service.Interfaces;

public interface IVerificationProcessingService
{
    ValueTask<bool> Verify(string code, CancellationToken cancellationToken);
}
