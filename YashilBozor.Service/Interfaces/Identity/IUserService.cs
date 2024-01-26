using System.Linq.Expressions;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    //ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}