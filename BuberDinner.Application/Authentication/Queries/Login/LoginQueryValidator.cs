// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > LoginQueryValidator.cs
// Created: 30 11, 2022
// Modified: 30 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

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
