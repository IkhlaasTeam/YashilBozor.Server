using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.Domain.Configurations;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.DTOs.Users;
using YashilBozor.Service.Interfaces.Identity;

namespace YashilBozor.Service.Services.Identity;

public class UserService(IUserRepository userRepository, IValidator<User> userValidator, IMapper mapper) : IUserService
{
    public ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(
        PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        var users = userRepository.SelectAll(user => user.DeletedAt == null, asNoTracking)
        .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);

        return new(mapper.Map<IEnumerable<UserForResultDto>>(users));
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
        var userId = await userRepository.SelectAll(user => user.EmailAddress.Equals(emailAddress) && user.DeletedAt == null).Select(user => user.Id).FirstOrDefaultAsync(cancellationToken);
        return userId != Guid.Empty ? userId : default(Guid?);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = userValidator.Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return userRepository.InsertAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<UserForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var user = mapper.Map<User>(userForUpdateDto);
        user.Id = userId;

        var validationResult = userValidator.Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        user.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<UserForResultDto>(await userRepository.UpdateAsync(user, saveChanges, cancellationToken));
    }

    public async ValueTask<UserForResultDto?> DeleteAsync(
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        return mapper.Map<UserForResultDto>(await userRepository.DeleteAsync(userId, saveChanges, cancellationToken));
    }
}