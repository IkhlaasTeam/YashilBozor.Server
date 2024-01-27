using YashilBozor.Service.Models;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IAuthAggregationService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, string code, CancellationToken cancellationToken = default);

    ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellation = default);
}