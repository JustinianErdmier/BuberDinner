// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.Application > AuthenticationService.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) => _jwtTokenGenerator = jwtTokenGenerator;

    /// <inheritdoc />
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists
        
        // Create user
        
        // Generate JWT
        Guid userId = Guid.NewGuid();
        
        string token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

    /// <inheritdoc />
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "first", "last", email, "token");
    }
}
