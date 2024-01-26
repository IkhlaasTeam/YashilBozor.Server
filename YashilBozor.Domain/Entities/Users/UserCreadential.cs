using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Users;

public class UserCreadentials : Auditable
{
    public string Password { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
