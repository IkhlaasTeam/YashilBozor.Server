using YashilBozor.Domain.Entities.Commons;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Domain.Enums;

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

