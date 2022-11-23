// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > RegisterCommandHandler.cs
// Created: 23 11, 2022
// Modified: 23 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository    = userRepository;
    }

    /// <inheritdoc />
    public Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) is not null) { return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.User.DuplicateEmail); }

        // Create user
        User user = new () { FirstName = command.FirstName, LastName = command.LastName, Email = command.Email, Password = command.Password };

        // Save user
        _userRepository.Add(user);

        // Generate JWT
        string token = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(user, token));
    }
}
