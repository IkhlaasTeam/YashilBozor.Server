using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.DAL.Repositories.Users;

public class UserCredentialsRepository : Repository<UserCredentials>, IUserCredentialsRepository
{
    public UserCredentialsRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
