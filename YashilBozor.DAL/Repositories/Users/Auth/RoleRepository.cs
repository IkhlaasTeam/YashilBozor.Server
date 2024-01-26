using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Users.Auth;
using HHD.Domain.Entities.Users.Auth;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Users.Auth;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
