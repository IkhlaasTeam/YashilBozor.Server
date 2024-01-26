using HHD.Domain.Enums;
using System.Text.Json.Serialization;
using YashilBozor.Domain.Entities.Commons;

namespace YashilBozor.Domain.Entities.Users.Auth;


public class Role : Auditable
{
    public RoleType RoleType { get; set; }

    [JsonIgnore]
    public IEnumerable<UserRole> UserRoles { get; set; }
}