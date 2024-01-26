using System.Text.Json.Serialization;
using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Enums;

namespace YashilBozor.Domain.Entities.Users.Auth;


public class Role : Auditable
{
    public RoleType RoleType { get; set; }

    [JsonIgnore]
    public IEnumerable<UserRole> UserRoles { get; set; }
}