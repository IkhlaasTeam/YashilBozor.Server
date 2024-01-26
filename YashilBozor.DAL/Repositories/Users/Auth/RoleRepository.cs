using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users.Auth;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users.Auth;

namespace YashilBozor.DAL.Repositories.Users.Auth;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
