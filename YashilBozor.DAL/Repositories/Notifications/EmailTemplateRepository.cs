using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Notifications;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.Domain.Entities.Notification;

namespace YashilBozor.DAL.Repositories.Notifications;

public class EmailTemplateRepository : Repository<EmailTemplate>, IEmailTemplateRepository
{
    public EmailTemplateRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}