// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > AuthenticationService.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository    = userRepository;
    }

    /// <inheritdoc />
    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;

            // return Result.Fail<AuthenticationResult>(new DuplicateEmailError());

            // return new DuplicateEmailError();

            // throw new DuplicateEmailException();

            // throw new Exception("User with given email already exists");
        }

        // Create user
        User user = new () { FirstName = firstName, LastName = lastName, Email = email, Password = password };

        // Save user
        _userRepository.Add(user);

        // Generate JWT
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    /// <inheritdoc />
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(email) is not { } user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Check if password is correct
        if (! user.Password.Equals(password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Generate JWT
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
