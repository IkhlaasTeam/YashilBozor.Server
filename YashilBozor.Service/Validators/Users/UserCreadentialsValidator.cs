using FluentValidation;
using Microsoft.Extensions.Options;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.Commons.Settings;

namespace YashilBozor.Service.Validators.Users;

public class UserCreadentialsValidator : AbstractValidator<UserCreadentials>
{
    public UserCreadentialsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(credentials => credentials.Password)
            .NotEmpty()
            .Matches(validationSettingsValue.PasswordRegexPattern)
            .WithMessage("Password is not valid");
    }
}
