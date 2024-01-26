using System.Linq.Expressions;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IUserCreadentialsService
{
    IQueryable<UserCreadentials> Get(Expression<Func<UserCreadentials, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<UserCreadentials?> GetByUserIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<UserCreadentials> CreateAsync(UserCreadentials userCredentials, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserCreadentials> UpdateAsync(UserCreadentials userCredentials, bool saveChanges = true, CancellationToken cancellationToken = default);
}
