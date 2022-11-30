using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(rc => rc.FirstName).NotEmpty();
        RuleFor(rc => rc.LastName).NotEmpty();
        RuleFor(rc => rc.Email).NotEmpty().EmailAddress();
        RuleFor(rc => rc.Password).NotEmpty().MinimumLength(6);
    }
}
