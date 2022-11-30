using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebUI.Controllers;

[ Route("auth") ]
public class AuthenticationController : ApiController
{
    private readonly IMapper _mapper;

    private readonly ISender _mediator;

    /// <inheritdoc />
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper   = mapper;
    }

    [ HttpPost("register") ]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(_mapper.Map<RegisterCommand>(request));

        return registerResult.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                                    Problem);
    }

    [ HttpPost("login") ]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(_mapper.Map<LoginQuery>(request));

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: loginResult.FirstError.Description);

        return loginResult.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                                 Problem);
    }
}
