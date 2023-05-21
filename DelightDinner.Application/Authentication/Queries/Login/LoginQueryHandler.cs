using DelightDinner.Application.Authentication.Common;
using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.UserAggregate;
using DelightDinner.Domain.Common.Errors;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReposetory _userReposetory;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserReposetory userReposetory)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReposetory = userReposetory;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user exist. 
        if (await _userReposetory.GetUserByEmailAsync(query.Email) is not User user)
        {
            return Errors.Authentiacation.InvalidCredentials;
        }

        // 2. Validate the password is correct. 
        if (user.Password != query.Password)
        {
            return Errors.Authentiacation.InvalidCredentials;
        }

        // 3. Create JWT-token.
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}