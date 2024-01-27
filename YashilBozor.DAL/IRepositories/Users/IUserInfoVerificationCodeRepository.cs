using YashilBozor.DAL.IRepositories.Commons;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.DAL.IRepositories.Users;

public interface IUserInfoVerificationCodeRepository : IRepository<UserInfoVerificationCode>
{
    ValueTask DeactivateAsync(
        Guid codeId, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default);
}
