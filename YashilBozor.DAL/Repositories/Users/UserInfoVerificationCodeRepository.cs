using Microsoft.EntityFrameworkCore;
using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.DAL.Repositories.Users;

public class UserInfoVerificationCodeRepository(AppDbContext dbContext) : Repository<UserInfoVerificationCode>(dbContext), IUserInfoVerificationCodeRepository
{
    public async ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await dbContext.UserInfoVerificationCodes.Where(code => code.Id == codeId)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        if (saveChanges)
            await dbContext.SaveChangesAsync(cancellationToken);
    }
}
