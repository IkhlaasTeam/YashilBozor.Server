using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Enums;

namespace YashilBozor.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public RoleType RoleType { get; set; }  
    public IEnumerable<Order> Orders { get; set; }
}
