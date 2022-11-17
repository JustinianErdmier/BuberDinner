// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > AuthenticationController.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.WebUI.Controllers;

[ Route("auth") ]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    /// <inheritdoc />
    public AuthenticationController(IAuthenticationService authenticationService) => _authenticationService = authenticationService;

    [ HttpPost("register") ]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return registerResult.Match(result => Ok(MapToAuthResponse(result)),
                                    errors => Problem(errors));
    }

    [ HttpPost("login") ]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = _authenticationService.Login(request.Email, request.Password);

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: loginResult.FirstError.Description);
        }

        return loginResult.Match(result => Ok(MapToAuthResponse(result)),
                                 errors => Problem(errors));
    }

    private static AuthenticationResponse MapToAuthResponse(AuthenticationResult result)
        => new (result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
}
