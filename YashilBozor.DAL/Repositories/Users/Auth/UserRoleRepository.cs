using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Commons;
using HHD.DAL.IRepositories.Users.Auth;
using HHD.Domain.Entities.Users.Auth;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Users.Auth;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
