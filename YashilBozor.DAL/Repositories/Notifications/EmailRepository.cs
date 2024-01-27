using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Notifications;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Notification;

namespace YashilBozor.DAL.Repositories.Notifications;

public class EmailRepository : Repository<Email>, IEmailRepository
{
    public EmailRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
