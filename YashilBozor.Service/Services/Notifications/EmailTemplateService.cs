using System.Linq.Expressions;
using YashilBozor.DAL.IRepositories.Notifications;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Interfaces.Notifications.Services;

namespace YashilBozor.Service.Services.Notifications;

public class EmailTemplateService(IEmailTemplateRepository emailTemplateRepository) : IEmailTemplateService
{
    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false)
    {
        return emailTemplateRepository.SelectAll(predicate, asNoTracking);
    }

    public ValueTask<EmailTemplate?> GetByIdAsync(
        Guid emailTemplateId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return emailTemplateRepository.SelectByIdAsync(emailTemplateId, asNoTracking, cancellationToken);
    }

    public ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return emailTemplateRepository.InsertAsync(emailTemplate, saveChanges, cancellationToken);
    }

    public ValueTask<EmailTemplate> UpdateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return emailTemplateRepository.UpdateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}