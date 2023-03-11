using DelightDinner.Application.Common.Interfaces.Authentication;
using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Common.Errors;
using DelightDinner.Domain.Entities;
using ErrorOr;

namespace DelightDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserReposetory _userReposetory;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserReposetory userReposetory)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userReposetory = userReposetory;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exist. 
        if (_userReposetory.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentiacation.InvalidCredentials;
        }

        // 2. Validate the password is correct. 
        if (user.Password != password)
        {
            return Errors.Authentiacation.InvalidCredentials;
        }

        // 3. Create JWT-token.
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userReposetory.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userReposetory.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token);
    }
}
