using FluentValidation;
using YashilBozor.Domain.Entities.Categories;

namespace YashilBozor.Service.Validators.Categories;

public class CommentaryValidator : AbstractValidator<Commentary>
{
    public CommentaryValidator()
    {
        RuleFor(comment => comment.Comment)
            .NotEmpty()
            .MinimumLength(3);
    }
}
