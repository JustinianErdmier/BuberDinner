// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > AuthenticationController.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.WebUI.Controllers;

[ Route("auth") ]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    /// <inheritdoc />
    public AuthenticationController(ISender mediator) => _mediator = mediator;

    [ HttpPost("register") ]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password));

        return registerResult.Match(result => Ok(MapToAuthResponse(result)),
                                    Problem);
    }

    [ HttpPost("login") ]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(new LoginQuery(request.Email, request.Password));

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: loginResult.FirstError.Description);
        }

        return loginResult.Match(result => Ok(MapToAuthResponse(result)),
                                 Problem);
    }

    private static AuthenticationResponse MapToAuthResponse(AuthenticationResult result)
        => new (result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
}
