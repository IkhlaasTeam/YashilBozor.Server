using YashilBozor.Domain.Enums;

namespace YashilBozor.Service.DTOs.Categories.Orders;

public class OrderForCreationDto
{
    public int Count { get; set; }
    public OrderType OrderType { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
