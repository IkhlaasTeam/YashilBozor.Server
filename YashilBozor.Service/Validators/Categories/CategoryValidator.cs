using FluentValidation;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.Service.Validators.Categories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty()
            .MinimumLength(3);
    }
}
