using FluentValidation;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.Service.Validators.Categories;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(product => product.Description)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(product => product.Count)
            .GreaterThanOrEqualTo(1);
    }
}
