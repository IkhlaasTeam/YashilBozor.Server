using HHD.DAL.DbContexts;
using HHD.DAL.IRepositories.Commons;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using YashilBozor.DAL.Repositories.Common;

namespace YashilBozor.DAL.Repositories.Users;

public class UserCredentialsRepository : Repository<UserCredentials>, IUserCredentialsRepository
{
    public UserCredentialsRepository(HHDDbContext dbContext) : base(dbContext)
    {

    }
}
