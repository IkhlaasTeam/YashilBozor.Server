using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.DAL.Repositories.Users;

public class UserCreadentialsRepository : Repository<UserCreadentials>, IUserCredentialsRepository
{
    public UserCreadentialsRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
