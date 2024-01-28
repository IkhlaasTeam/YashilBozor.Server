using System.Linq.Expressions;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Domain.Enums;

namespace YashilBozor.Service.Interfaces.Verifications;

public interface IUserInfoVerificationCodeService 
{
    IList<string> Generate();

    IQueryable<UserInfoVerificationCode> GetAll(Expression<Func<UserInfoVerificationCode, bool>> predicate);
    ValueTask<(UserInfoVerificationCode Code, bool IsValid)> GetByCodeAsync(string code, CancellationToken cancellationToken = default);

    ValueTask<UserInfoVerificationCode> CreateAsync(VerificationCodeType codeType, Guid userId, CancellationToken cancellationToken = default);

    ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
