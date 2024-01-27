using System.Linq.Expressions;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailTemplateService
{
    IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default, 
        bool asNoTracking = false);

    ValueTask<EmailTemplate?> GetByIdAsync(
        Guid emailTemplateId, 
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default);

    ValueTask<EmailTemplate> UpdateAsync(
        EmailTemplate emailTemplate, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default);
}