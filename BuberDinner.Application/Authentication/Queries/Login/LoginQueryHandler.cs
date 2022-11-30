using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository    = userRepository;
    }

    /// <inheritdoc />
    public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Check if user exists
        if (_userRepository.GetUserByEmail(query.Email) is not { } user)
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.InvalidCredentials);

        // Check if password is correct
        if (! user.Password.Equals(query.Password))
            return Task.FromResult<ErrorOr<AuthenticationResult>>(Errors.Authentication.InvalidCredentials);

        // Generate JWT
        string token = _jwtTokenGenerator.GenerateToken(user);

        return Task.FromResult<ErrorOr<AuthenticationResult>>(new AuthenticationResult(user, token));
    }
}
