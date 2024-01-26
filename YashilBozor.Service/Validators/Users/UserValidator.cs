﻿using FluentValidation;
using Microsoft.Extensions.Options;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Service.Commons.Settings;

namespace YashilBozor.Service.Validators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(user => user.EmailAddress)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(64)
            .Matches(validationSettingsValue.EmailRegexPattern)
            .WithMessage("Email address is not valid");


        RuleFor(user => user.FirstName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64)
            .WithMessage("First name is not valid");

        RuleFor(user => user.LastName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64)
            .WithMessage("Last name is not valid");

        RuleFor(user => user.PhoneNumber)
            .NotEmpty()
            .Matches(validationSettingsValue.PhoneNumberRegexPattern)
            .WithMessage("Phone number is not valid");
    }
}
