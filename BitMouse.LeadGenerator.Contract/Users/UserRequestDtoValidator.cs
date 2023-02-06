using FluentValidation;
using FluentValidation.Validators;

namespace BitMouse.LeadGenerator.Contract.Users;

public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
{
    public UserRequestDtoValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty().WithErrorCode("User.FirstNameRequired")
            .MaximumLength(50).WithErrorCode("User.FirstNameMaxLength");

        RuleFor(user => user.LastName)
            .NotEmpty().WithErrorCode("User.LastNameRequired")
            .MaximumLength(50).WithErrorCode("User.LastNameMaxLength");

        RuleFor(user => user.Email)
            .NotEmpty().WithErrorCode("User.EmailRequired")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithErrorCode("User.EmailFormat");
    }
}
