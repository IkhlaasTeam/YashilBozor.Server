using System.Linq.Expressions;
using YashilBozor.Domain.Entities.Notification;

namespace YashilBozor.Service.Interfaces.Notifications.Services;

public interface IEmailService
{
    IQueryable<Email> Get(
        Expression<Func<Email, bool>>? predicate = default,
        bool asNoTracking = false);

    ValueTask<Email?> GetByIdAsync(
        Guid emailId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<Email> CreateAsync(
        Email emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<Email> UpdateAsync(
        Email email,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}