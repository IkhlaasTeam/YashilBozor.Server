using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Users;

public class AccessTokenRepository : Repository<AccessToken>, IAccessTokenRepository
{
    public AccessTokenRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
