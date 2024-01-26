using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.DAL.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
