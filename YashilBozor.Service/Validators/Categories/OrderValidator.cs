using FluentValidation;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.Service.Validators.Categories;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Count)
            .GreaterThanOrEqualTo(1);
    }
}
