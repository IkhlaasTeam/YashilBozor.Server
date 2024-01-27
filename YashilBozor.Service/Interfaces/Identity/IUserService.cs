using System.Linq.Expressions;
using YashilBozor.Domain.Configurations;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.DTOs.Users;

namespace YashilBozor.Service.Interfaces.Identity;

public interface IUserService
{
    ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(
        PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    //ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto?> DeleteAsync(
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}