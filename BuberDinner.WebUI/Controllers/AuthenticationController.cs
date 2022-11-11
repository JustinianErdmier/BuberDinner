// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lieberman Technologies, LLC. All rights reserved.
// BuberDinner > BuberDinner.WebUI > AuthenticationController.cs
// Created: 11 11, 2022
// Modified: 11 11, 2022
// ---------------------------------------------------------------------------------------------------------------------------------

using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

[ApiController, Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    /// <inheritdoc />
    public AuthenticationController(IAuthenticationService authenticationService) => _authenticationService = authenticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        AuthenticationResult result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        
        var response = new AuthenticationResult(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        AuthenticationResult result = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResult(result.Id, result.FirstName, result.LastName, result.Email, result.Token);

        return Ok(response);
    }
}
