using System.Linq.Expressions;
using YashilBozor.DAL.IRepositories.Notifications;
using YashilBozor.Domain.Entities.Notification;
using YashilBozor.Service.Interfaces.Notifications.Services;

namespace YashilBozor.Service.Services.Notifications;

public class EmailService(IEmailRepository emailRepository) : IEmailService
{
    public IQueryable<Email> Get(
        Expression<Func<Email, bool>>? predicate = default,
        bool asNoTracking = false)
    {
        return emailRepository.SelectAll(predicate, asNoTracking);
    }

    public ValueTask<Email?> GetByIdAsync(
        Guid emailId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return emailRepository.SelectByIdAsync(emailId, asNoTracking, cancellationToken);
    }

    public ValueTask<Email> CreateAsync(
        Email email,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return emailRepository.InsertAsync(email, saveChanges, cancellationToken);
    }

    public ValueTask<Email> UpdateAsync(
        Email email,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return emailRepository.UpdateAsync(email, saveChanges, cancellationToken);
    }
}