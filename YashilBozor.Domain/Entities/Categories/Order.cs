using HHD.Domain.Enums;
using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Entities.Users;

namespace YashilBozor.Domain.Entities.Categories;

public class Order : Auditable
{
    public int Count { get; set; }
    public OrderType OrderType { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}

