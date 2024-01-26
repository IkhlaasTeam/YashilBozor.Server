using YashilBozor.Service.DTOs.Users.Auth.UserRoles;

namespace YashilBozor.Service.DTOs.Users.Auth.Roles;

public class RoleForResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<UserRoleForResultDto> UserRoles { get; set; }
}
