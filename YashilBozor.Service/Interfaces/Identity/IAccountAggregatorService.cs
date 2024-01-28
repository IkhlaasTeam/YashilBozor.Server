using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IAccountAggregatorService
{
    ValueTask<string> CreateUserAsync(User user, UserCreadentials userCreadentials, CancellationToken cancellationToken = default);

    ValueTask<bool> VerifyEmail(string code, Guid userId, CancellationToken cancellationToken);
}