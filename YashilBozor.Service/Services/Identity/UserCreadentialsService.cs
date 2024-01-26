using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.Interfaces.Identity;

namespace YashilBozor.Service.Services.Identity;

public class UserCreadentialsService(IUserCredentialsRepository userCredentialsRepository) : IUserCreadentialsService
{
    public ValueTask<UserCreadentials> CreateAsync(UserCreadentials userCredentials, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userCredentialsRepository.InsertAsync(userCredentials, saveChanges, cancellationToken);
    }

    public IQueryable<UserCreadentials> Get(Expression<Func<UserCreadentials, bool>>? predicate = null, bool asNoTracking = false)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCreadentials?> GetByUserIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserCreadentials> UpdateAsync(UserCreadentials userCreadentials, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userCredentialsRepository.UpdateAsync(userCreadentials, saveChanges, cancellationToken);
    }
}
