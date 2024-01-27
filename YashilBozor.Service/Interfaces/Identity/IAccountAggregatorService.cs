using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, UserCreadentials userCreadentials, string code, CancellationToken cancellationToken = default);
}