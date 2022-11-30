using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(lq => lq.Email).NotEmpty().EmailAddress();
        RuleFor(lq => lq.Password).NotEmpty();
    }
}
