using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Users;

public class UserInfoVerificationCodeRepository : Repository<UserInfoVerificationCode>, IUserInfoVerificationCodeRepository
{
    public UserInfoVerificationCodeRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
