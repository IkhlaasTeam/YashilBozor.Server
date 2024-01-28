using YashilBozor.Service.Models;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IAuthAggregationService
{
    ValueTask<string> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);

    ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellation = default);
}