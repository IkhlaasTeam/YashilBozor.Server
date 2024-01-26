using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users.Auth;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users.Auth;

namespace YashilBozor.DAL.Repositories.Users.Auth;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
