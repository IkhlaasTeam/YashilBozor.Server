using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.Interfaces;

namespace YashilBozor.Service.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return userRepository.SelectAll(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.SelectByIdAsync(userId, asNoTracking, cancellationToken);
    }

    //public async ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    //{
    //    return await Get(user => user.Role == RoleType.System, asNoTracking).FirstAsync(cancellationToken);
    //}

    public async Task<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var userId = await Get(user => user.EmailAddress == emailAddress, true).Select(user => user.Id).FirstOrDefaultAsync(cancellationToken);
        return userId != Guid.Empty ? userId : default(Guid?);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.InsertAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }
}